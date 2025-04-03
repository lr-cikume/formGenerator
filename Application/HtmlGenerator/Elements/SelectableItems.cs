using Domain.Entities.Dto;

namespace Application.HtmlGenerator.Elements
{
    public abstract class SelectableItems : BaseHtmlElement
    {
        public List<ElementOption> Elements { get; set; } = [];
        protected abstract string HtmlType { get; }
        private Label _label;

        public SelectableItems(string checkboxId, string description, bool isRequired, List<ElementOption> elements) : base(checkboxId, isRequired)
        {
            Id = checkboxId;
            Elements = elements;
            _label = new Label(description);
        }

        public override string ToHtmlString()
        {
            //Counter to create a individualId for each element in the Elements collection 
            //so it can be linked with its text
            var counter = 1;

            var stringElements = Elements.Select(e => 
            {
                var individualCheckId = $"{Id}{counter}";
                counter++;

                return "<div>" +
                    GenerateOptionLabel(e.Name, individualCheckId) +

                    $"<input type=\"{HtmlType}\" id=\"{individualCheckId}\" name=\"{Id}\" value=\"{e.Value}\" {Required}/>" +
                "</div>";
            });

            return _label.ToHtmlString() + string.Join("",stringElements);
        }

        private string GenerateOptionLabel(string text, string idToLink)
        {
            return new Label(text).AddLabelFor(idToLink).ToHtmlString();
        }
    }
}
