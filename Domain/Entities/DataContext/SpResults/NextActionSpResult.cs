using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext.SpResults
{
    public class NextActionSpResult : INameValueItem
    {
        [Column("nxt_action")]
        public string Value { get; set; } = "";

        [Column("nxt_action")]
        public string Name { get; set; } = "";
    }
}
