using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext.SpResults
{
    public class LstActnSpResult : INameValueItem
    {
        private string? _value;

        [NotMapped]
        public string Value { get => lst_id.ToString(); set => _value = value; }

        [Column("lst_id")]
        public int lst_id { get; set; }

        [Column("lac_action")]
        public string Name { get; set; } = "";
    }
}
