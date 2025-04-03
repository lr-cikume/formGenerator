using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext
{
    public class FormDesign : BaseDataContextModel
    {
        [Column("name")]
        public string Name { get; set; } = "";

        [Column("description")]
        public string Description { get; set; } = "";

        public List<InputField> InputFields { get; set; } = [];
    }
}
