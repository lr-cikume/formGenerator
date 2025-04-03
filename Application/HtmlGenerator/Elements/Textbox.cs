namespace Application.HtmlGenerator.Elements
{
    public class Textbox : BaseHtmlElement
    {
        private string _extraAttributes = "";

        public Textbox(string id, bool isRequired) : base(id, isRequired)
        {
        }

        /// <summary>
        /// Adds a special set of attributes so the textbox is not reachable in the UI for a common human
        /// </summary>
        public void MakeItHoneyPot()
        {
            _extraAttributes += "tabindex=\"-1\" autocomplete=\"off\" ";
        }

        public override string ToHtmlString()
        {
            return $"<input type=\"text\" id=\"{Id}\" name=\"{Id}\" {Required}{_extraAttributes}/>";
        }
    }
}
