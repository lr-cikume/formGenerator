using Application.HtmlGenerator.Builder;
using Application.HtmlGenerator.Elements;
using Domain.ConfigOptions;
using Domain.Entities.Dto;
using Domain.Interfaces.Builders;
using Domain.Interfaces.Repositories;

namespace Application.HtmlGenerator
{
    /// <summary>
    /// Service to recover the contact information form 
    /// </summary>
    public class HtmlGeneratorService
    {
        private readonly HtmlFactory _htmlFactory;
        private readonly IFormElementRepository _formElementRepository;
        private readonly IConnectionStringDirector _connectionStringDirector;

        public HtmlGeneratorService(HtmlFactory htmlFactory, IConnectionStringDirector connectionStringDirector, IFormElementRepository formElementRepository)
        {
            _htmlFactory = htmlFactory;
            _connectionStringDirector = connectionStringDirector;
            _formElementRepository = formElementRepository;
        }

        /// <summary>
        /// Recovers the contact information form for the specified tenant
        /// and convertes it to a html string
        /// </summary>
        public async Task<string> GenerateForm(Guid tenantId, string baseUrl)
        {
            var protoHtmlElements = new List<FormElement>();

            try
            {
                var connectionString = await _connectionStringDirector.ConstructTenantDbConnection(tenantId);
                _formElementRepository.SetDataConnection(connectionString);

                protoHtmlElements = await _formElementRepository.GetElements();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new ApplicationException("An error occurred while getting form elements.", ex);
            }

            var htmlElements = protoHtmlElements.OrderBy(e => e.Position)
                                    .Select(_htmlFactory.ParseElement)
                                    .ToList();

            htmlElements.Add(new SubmitButton("SubmitBtn", "Send somewhere"));

            var formBuilder = new FormBuilder($"{baseUrl}{HtmlGeneratorOptions.ActionEndpoint}{tenantId}", HtmlGeneratorOptions.HoneyPotFieldId, htmlElements);

            return formBuilder.GenerateHtmlString();
        }
    }
}
