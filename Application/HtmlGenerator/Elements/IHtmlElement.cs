namespace Application.HtmlGenerator.Elements
{
    public interface IHtmlElement
    {
        public string Id { get; set; }


        public string ToHtmlString();
    }
}
