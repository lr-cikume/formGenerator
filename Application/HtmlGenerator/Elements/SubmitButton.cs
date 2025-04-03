namespace Application.HtmlGenerator.Elements
{
    public class SubmitButton : BaseHtmlElement
    {
        public string Text { get; set; } = "";

        public SubmitButton(string id, string text) : base(id, false)
        {
            Text = text;
        }

        public override string ToHtmlString()
        {
            return $"<input type=\"submit\" id=\"{Id}\" value=\"{Text}\"/>";
        }
    }
}
