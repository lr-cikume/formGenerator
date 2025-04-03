using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext.SpResults
{
    public class CustomerTypeSpResult : INameValueItem
    {
        //[NotMapped]
        //public string Value
        //{
        //    get { return IntId.ToString(); }
        //    set { }
        //}

        //[Column("ctp_id")]
        //public int IntId { get; set; }

        [Column("ctp_text")]
        public string Value { get; set; } = "";
        
        [Column("ctp_text")]
        public string Name { get; set; } = "";
    }
}
