namespace Domain.Entities.Dto;

public class FormElement
{
    public string IdElement { get; set; } = "";
    public int Position { get; set; }
    public string DisplayText { get; set; } = "";
    /// <summary>
    /// Type of the input as extracted in the db (string)
    /// </summary>
    public string ElementTypeString { get; set; } = "";
    public SupportedHtmlElements ElementType { 
        get {

            return Enum.TryParse<SupportedHtmlElements>(ElementTypeString, true, out var parsedValue) ? parsedValue : SupportedHtmlElements.NotProvided;
        } 
    }
    /// <summary>
    /// Type of the column where the value is going to be saved 
    /// (it should match with ElementType but as the test data is not like that using this to generate the field type)
    /// </summary>
    public string ElementFieldType { get; set; } = "";
    /// <summary>
    /// Column that contains the source to obtain the options for a dropdown
    /// </summary>
    public string? DataSource { get; set; }
    public bool Required { get; set; }
    /// <summary>
    /// Place holder that is going to be shown in the field
    /// </summary>
    public string PlaceHolder { get; set; }
    public int? MaxLength { get; set; }
    

    //relationship for ElementOption
    public List<ElementOption> ElementOptions { get; set; } = new List<ElementOption>();
}