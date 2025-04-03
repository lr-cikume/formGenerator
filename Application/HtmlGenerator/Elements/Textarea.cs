namespace Application.HtmlGenerator.Elements
{
    public class Textarea : BaseHtmlElement
    {
        private Label _label;

        public Textarea(string id, string description, bool isRequired) : base(id, isRequired)
        {
            _label = new Label(description);
            _label.AddLabelFor(id);
        }

        public override string ToHtmlString()
        {
            //Might want ot add rows=\"5\" cols=\"33\"
            return _label.ToHtmlString() + $"<textarea id=\"{Id}\" name=\"{Id}\" {Required}></textarea>";
        }
    }
}
