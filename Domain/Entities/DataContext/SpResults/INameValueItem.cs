using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext.SpResults
{
    public interface INameValueItem
    {
        public string Value { get; set; }

        public string Name { get; set; }
    }
}
