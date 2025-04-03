using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext.SpResults
{
    public class SalesPersonSpResult : INameValueItem
    {
        //[Column("sal_id")]
        [Column("sal_pers")]
        public string Value { get; set; } = "";

        [Column("sal_pers")]
        public string Name { get; set; } = "";
    }
}
