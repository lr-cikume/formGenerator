using Domain.Entities.Dto;
using Domain.Entities.DataContext.SpResults;

namespace Infrastructure.Services
{
    public static class NameValueItemExtensions
    {
        /// <summary>
        /// Parses the elements from <see cref="nameValueItems"/> parameter into <see cref="ElementOption"/> 
        /// so it can be used as options in a select input
        /// </summary>
        public static List<ElementOption> ToElementOption(this IEnumerable<INameValueItem> nameValueItems)
        {
            return [.. nameValueItems.Select(e => new ElementOption
            {
                Name = e.Name,
                Value = e.Value
            })];
        }
    }
}
