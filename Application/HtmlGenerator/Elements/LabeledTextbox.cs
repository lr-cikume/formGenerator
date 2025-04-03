namespace Application.HtmlGenerator.Elements
{
    public class LabeledTextbox : BaseHtmlElement
    {
        private Label _label;
        private Textbox _textbox;

        public LabeledTextbox(string text, string textboxId, bool isRequired) : base(textboxId, isRequired)
        {
            Id = textboxId;
            _label = new Label(text);
            _textbox = new Textbox(textboxId, isRequired);

            _label.AddLabelFor(textboxId);
        }

        public override string ToHtmlString()
        {
            return _label.ToHtmlString() + _textbox.ToHtmlString();
        }
    }
}
