using Application.HtmlGenerator.Builder;
using Application.HtmlGenerator.Elements;
using Domain.Entities;
using Domain.Entities.Dto;

namespace Application.HtmlGenerator
{
    /// <summary>
    /// Factory to create instances of IHtmlElement
    /// </summary>
    public class HtmlFactory
    {
        private InputBuilder _inputBuilder;

        public HtmlFactory(InputBuilder inputBuilder)
        {
            _inputBuilder = inputBuilder;
        }

        public enum SupportedFieldTypes
        {
            Varchar,
            Datetime,
            //Decimal and Int are quite the same
            //Decimal need to handle step="0.XX1", so change x instead of the numbers of decimal positions
            Decimal,
            Int,            
        }

        /// <summary>
        /// Parses a <see cref="FormElement"/> into its <see cref="IHtmlElement"/> equivalent (if available)
        /// </summary>
        public IHtmlElement ParseElement(FormElement rawElement)
        {
            var elementType = rawElement.ElementType;

            elementType = ValidateInputType(elementType, rawElement.ElementFieldType);

            return elementType switch
            {
                SupportedHtmlElements.Select => new Dropdown(rawElement.IdElement, rawElement.DisplayText, rawElement.Required, rawElement.ElementOptions),
                SupportedHtmlElements.Checkbox => new Checkbox(rawElement.IdElement, rawElement.DisplayText, rawElement.Required, rawElement.ElementOptions),
                SupportedHtmlElements.Radio => new RadioButton(rawElement.IdElement, rawElement.DisplayText, rawElement.Required, rawElement.ElementOptions),
                SupportedHtmlElements.Textarea => new Textarea(rawElement.IdElement, rawElement.DisplayText, rawElement.Required),

                SupportedHtmlElements.Text => _inputBuilder.GenerateInput(rawElement, InputTypesEnum.Text),
                SupportedHtmlElements.Number => _inputBuilder.GenerateInput(rawElement, InputTypesEnum.Number),
                SupportedHtmlElements.Email => _inputBuilder.GenerateInput(rawElement, InputTypesEnum.Email),
                SupportedHtmlElements.Password => _inputBuilder.GenerateInput(rawElement, InputTypesEnum.Password),
                SupportedHtmlElements.Date => _inputBuilder.GenerateInput(rawElement, InputTypesEnum.Date),

                SupportedHtmlElements.Invalid => _inputBuilder.GenerateInput(new FormElement { IdElement = rawElement.IdElement, DisplayText = $"Error parsing field {rawElement.IdElement}" }, InputTypesEnum.Text),
            
                _ => throw new InvalidCastException($"Unsupported type: {rawElement.ElementType}")
            };
        }

        /// <summary>
        /// Temporal hack to validate that the elementType matches the fieldTypeString
        /// </summary>
        public SupportedHtmlElements ValidateInputType(SupportedHtmlElements elementType, string fieldTypeString)
        {
            if (elementType == SupportedHtmlElements.Select)
            {
                //Cross fingers that the select value matches the input type
                return SupportedHtmlElements.Select;
            }

            if (!Enum.TryParse<SupportedFieldTypes>(fieldTypeString, true, out var fieldType))
            {
                return SupportedHtmlElements.Invalid;
            }

            if (elementType == SupportedHtmlElements.Text && (fieldType == SupportedFieldTypes.Decimal || fieldType == SupportedFieldTypes.Int))
            {
                return SupportedHtmlElements.Number;
            }

            if (elementType == SupportedHtmlElements.Text && fieldType == SupportedFieldTypes.Datetime)
            {
                return SupportedHtmlElements.Date;
            }

            return elementType;
        }
    }
}
