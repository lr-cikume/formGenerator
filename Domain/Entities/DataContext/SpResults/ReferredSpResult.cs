using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext.SpResults
{
    public class ReferredSpResult : INameValueItem
    {
        //[Column("rfd_cuser")]
        [Column("rfr_by")]
        public string Value { get; set; } = "";

        [Column("rfr_by")]
        public string Name { get; set; } = "";
    }
}
