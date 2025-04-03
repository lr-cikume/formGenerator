using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext.SpResults
{
    public class MailSpResult : INameValueItem
    {
        //[Column("mai_cuser")]
        [Column("mai_desc")]
        public string Value { get; set; } = "";

        [Column("mai_desc")]
        public string Name { get; set; } = "";
    }
}
