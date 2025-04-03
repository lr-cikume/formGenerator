namespace Application.HtmlGenerator.Elements
{
    public class LabeledInput : BaseHtmlElement
    {
        public Input Input { get; }
        private Label _label;

        public LabeledInput(string inputId, string text, bool isRequired, InputTypesEnum type = InputTypesEnum.Text) : base(inputId, isRequired)
        {
            Id = inputId;
            _label = new Label(text);
            Input = new Input(inputId, isRequired, type);

            _label.AddLabelFor(inputId);
        }

        public override string ToHtmlString()
        {
            return _label.ToHtmlString() + Input.ToHtmlString();
        }
    }
}
