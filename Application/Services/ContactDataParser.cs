using Domain.Entities.DataContext;
using System.Reflection;

namespace Application.Services
{
    /// <summary>
    /// Parser to <see cref="ContactData"/>
    /// </summary>
    public static class ContactDataParser
    {
        /// <summary>
        /// Parses the elements in <see cref="formKeyValues"/> into the equivalent property in <see cref="ContactData"/> 
        /// searching the key as the property name and assigning value to its value
        /// If a element don´t have a matching property then is skipped
        /// </summary>
        public static ContactData ToContactData(this List<KeyValuePair<string, string>> formKeyValues)
        {
            var result = new ContactData();
            var bindingAttributes = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

            foreach (var item in formKeyValues)
            {
                var propertyInfo = result.GetType().GetProperty(item.Key, bindingAttributes);

                if (propertyInfo == null)
                {
                    //Log or something
                    continue;
                }

                var convertedType = ConvertToType(item.Value, propertyInfo.PropertyType);
                propertyInfo.SetValue(result, convertedType);
            }

            return result;
        }

        /// <summary>
        /// Converts <see cref="value"/> into the type of <see cref="conversion"/> 
        /// if <see cref="conversion"/> is a nullable type and the value is not null then converts it to the underlying type 
        /// if the value is empty or null returns null
        /// </summary>
        private static object ConvertToType(object value, Type conversionType)
        {
            var t = conversionType;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
    }
}
