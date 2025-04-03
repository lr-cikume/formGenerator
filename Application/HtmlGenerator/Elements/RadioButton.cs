using Domain.Entities.Dto;

namespace Application.HtmlGenerator.Elements
{
    public class RadioButton : SelectableItems
    {
        protected override string HtmlType { get => "radio"; }

        public RadioButton(string radioId, string description, bool isRequired, List<ElementOption> elements) : base(radioId, description, isRequired, elements)
        {
        }
    }
}
