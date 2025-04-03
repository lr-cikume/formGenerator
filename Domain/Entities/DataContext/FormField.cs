using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext
{
    public class FormField : BaseDataContextModel
    {
        [Column("field_name")]
        public string FieldName { get; set; } = "";

        [Column("field_type")]
        public string FieldType { get; set; } = "";

        [Column("table_name")]
        public string TableName { get; set; } = "";
    }
}
