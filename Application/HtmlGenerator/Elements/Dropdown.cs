using Domain.Entities.Dto;

namespace Application.HtmlGenerator.Elements
{
    public class Dropdown : BaseHtmlElement
    {
        public string Description { get; set; } = "";
        public List<ElementOption> Elements { get; set; } = [];
        private Label _label;


        public Dropdown(string id, string description, bool isRequired, List<ElementOption> elements) : base(id, isRequired)
        {
            Id = id;
            Elements = elements;
            _label = new Label(description);
        }

        public override string ToHtmlString()
        {
            var options = Elements.Select(e =>
                $"<option value=\"{e.Value}\">{e.Name}</option>"
            );

            var stringElements = _label.ToHtmlString() +
                $"<select id=\"{Id}\" name=\"{Id}\" {Required}>" +
                    "<option value=\"\">--Please choose an option--</option>" +
                    string.Join(string.Empty, options) +
                "</select>";

            return stringElements;
        }
    }
}
