using Application.HtmlGenerator.Elements;
using Domain.Entities.Dto;

namespace Application.HtmlGenerator.Builder
{
    public class InputBuilder
    {
        public IHtmlElement GenerateInput(FormElement rawElement, InputTypesEnum inputType)
        {
            var labeledInput = new LabeledInput(rawElement.IdElement, rawElement.DisplayText, rawElement.Required, inputType);

            if (rawElement.MaxLength != null)
            {
                labeledInput.Input.SetMaxLength(rawElement.MaxLength.Value);
            }

            if (!string.IsNullOrEmpty(rawElement.PlaceHolder))
            {
                labeledInput.Input.SetPlaceholder(rawElement.PlaceHolder);
            }

            //TODO -> set extra attributes for validation (possible depending on the input type)

            return labeledInput;
        }
    }
}
