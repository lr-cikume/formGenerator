using Domain.Entities.Dto;

namespace Application.HtmlGenerator.Elements
{
    public class Checkbox : SelectableItems
    {
        protected override string HtmlType { get => "checkbox"; }

        public Checkbox(string checkboxId, string description, bool isRequired, List<ElementOption> elements) 
            //Adding a silly validation with the elements count, if required attribute is present all the checkboxes have to be selected
            //So for now ommit it, todo-> improve
            : base(checkboxId, description, elements.Count == 1 ? isRequired : false, elements)
        {
        }
    }
}
