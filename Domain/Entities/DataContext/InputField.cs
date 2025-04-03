using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext
{
    public class InputField : BaseDataContextModel
    {
        [Column("form_design_id")]
        public Guid FormDesignId { get; set; }
        
        [Column("input_type_id")]
        public Guid InputTypeId { get; set; }
        
        [Column("field_id")]
        public Guid FieldId { get; set; }

        [Column("display_name")]
        public string DisplayName { get; set; } = "";
    
        [Column("display_order")]
        public int DisplayOrder { get; set; }
    
        [Column("description")]
        public string Description { get; set; } = "";
    
        [Column("name_input")]
        public string NameInput { get; set; } = "";
    
        [Column("default_value")]
        public string DefaultValue { get; set; } = "";
    
        [Column("data_source")]
        public string? DataSource { get; set; } = "";
    
        [Column("required")]
        public bool Required { get; set; }
    
        [Column("min_value")]
        public int MinValue { get; set; }

        [Column("max_value")]
        public int MaxValue { get; set; }
    
        [Column("input_mask")]
        public string InputMask { get; set; } = "";
    
        [Column("input_pattern")]
        public string InputPattern { get; set; } = "";
    
        [Column("pattern_invalid_title")]
        public string PatternInvalidTitle { get; set; } = "";
    
        [Column("max_lenght")]
        public int? MaxLenght { get; set; }

        public FormDesign FormDesign { get; set; } = new();
        public InputType InputType { get; set; } = new();
        public FormField Field { get; set; } = new();
    }
}
