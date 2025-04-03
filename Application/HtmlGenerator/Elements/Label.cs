namespace Application.HtmlGenerator.Elements
{
    public class Label : IHtmlElement
    {
        public string Text { get; set; } = "";
        public string Id { get; set; } = "";

        private string _extraAttributes = "";


        public Label(string text)
        {
            Text = text;
        }


        public Label AddLabelFor(string forIndicator)
        {
            _extraAttributes += $" for=\"{forIndicator}\"";
            return this;
        }

        public Label AddId(string id)
        {
            _extraAttributes += $" id=\"{id}\"";
            return this;
        }

        public string ToHtmlString()
        {
            return $"<label {_extraAttributes}>{Text}</label>";
        }
    }
}
