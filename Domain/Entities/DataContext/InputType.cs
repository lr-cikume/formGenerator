using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext
{
    public class InputType : BaseDataContextModel
    {
        [Column("input")]
        public string Input { get; set; } = "";

        [Column("tag_name")]
        public string TagName { get; set; } = "";

        [Column("data_type")]
        public string DataType { get; set; } = "";

        public List<InputField> InputFields { get; set; } = [];
    }
}
