namespace Application.HtmlGenerator.Elements
{
    public class Input : BaseHtmlElement
    {
        private string _extraAttributes = "";
        private InputTypesEnum _inputType;

        public Input(string id, bool isRequired, InputTypesEnum type) : base(id, isRequired)
        {
            _inputType = type;
        }

        /// <summary>
        /// Adds a special set of attributes so the textbox is not reachable in the UI for a common human
        /// </summary>
        public void MakeItHoneyPot()
        {
            _extraAttributes += "tabindex=\"-1\" autocomplete=\"off\" ";
        }

        public void SetMinLength(int minlength)
        {
            _extraAttributes += $"minlength=\"{minlength}\" ";
        }

        public void SetMaxLength(int maxlength)
        {
            _extraAttributes += $"maxlength=\"{maxlength}\" ";
        }

        public void SetPlaceholder(string placeholder)
        {
            _extraAttributes += $"placeholder=\"{placeholder}\" ";
        }

        public override string ToHtmlString()
        {
            return $"<input type=\"{_inputType.ToString().ToLowerInvariant()}\" id=\"{Id}\" name=\"{Id}\" {Required} {_extraAttributes}/>";
        }
    }
}
