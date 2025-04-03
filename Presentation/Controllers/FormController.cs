using Application.HtmlGenerator;
using Application.Services;
using Domain.ConfigOptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class FormController : ControllerBase
{
    private readonly HtmlGeneratorService _htmlGeneratorService;
    private readonly IContactDataService _contactDataService;
    private readonly ISourceDbRepository _sourceDbRepository;

    public FormController(IContactDataService contactDataService, HtmlGeneratorService htmlGeneratorService, ISourceDbRepository sourceDbRepository)
    {
        _contactDataService = contactDataService;
        _htmlGeneratorService = htmlGeneratorService;        
        _sourceDbRepository = sourceDbRepository;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GenerateScriptForm(string name)
    {
        // Retrieve the UuId for the given form name
        var UuId = await _sourceDbRepository.GetUuIdByNameAsync(name);
        if (string.IsNullOrEmpty(UuId))
        {
            return NotFound("Form not found");
        }

        // Construct the base URL from the request
        var baseUrl = $"{Request.Scheme}://{Request.Host}";

        // Create the HTML content with the embedded script
        var htmlContent = $@"<!-- Step 1: Div where the form will be rendered -->
        <div id=""myForm""></div>

        <!-- Step 2: Embedded script -->
        <script src=""{baseUrl}/formEmbed.js"" data-uuid=""{UuId}"" data-target=""myForm"">
        </script>

        <!-- Step 3: Add some basic style -->
        <link href='https://fonts.googleapis.com/css?family=Source Sans 3' rel='stylesheet'>
        <link href=""{baseUrl}/formEmbed.css"" rel='stylesheet'>";

        // Return the HTML with the proper content type
        return Content(htmlContent, "text/html");
    }

    [EnableCors(PresentationConstants.CorsPolicyName)]
    [HttpGet("generate/{tenantId}")]
    public async Task<IActionResult> GenerateContactForm(Guid tenantId)
    {
        // Construct the base URL from the request
        var baseUrl = $"{Request.Scheme}://{Request.Host}";

        var elements = await _htmlGeneratorService.GenerateForm(tenantId, baseUrl);   
        return Ok(elements);
    }

    [EnableCors(PresentationConstants.CorsPolicyName)]
    [HttpPost("saveData/{tenantId}")]
    public async Task<IActionResult> SaveContactData(Guid tenantId, IOptions<HtmlGeneratorOptions> generatorOptions)
    {
        var bodyStr = "";

        var form = await Request.ReadFormAsync();

        var honeyPotfield = form.FirstOrDefault(e => e.Key == HtmlGeneratorOptions.HoneyPotFieldId);
        if (!string.IsNullOrEmpty(honeyPotfield.Value))
        {
            //Log, ban ip, etc
            return BadRequest("I caught you Mr. Roboto! ~~(O_o)~~ ");
        }

        //var formKv = form.Select(e => new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>(e.Key, e.Value)).ToList();
        var formKv = form.Select(e => new KeyValuePair<string, string>(e.Key, e.Value)).ToList();

        var result = await _contactDataService.SaveDataAsync(formKv.ToContactData(), tenantId);

        //Send keyValue variable (or recolected form as a list) to the validation / save service
        foreach (var keyValue in form)
        {
            Console.WriteLine($"Field: {keyValue.Key}, Value: {keyValue.Value}");
            bodyStr += $" {keyValue.Key}:  {keyValue.Value}";
        }

        return Ok($"Data received: {bodyStr}");
    }
}