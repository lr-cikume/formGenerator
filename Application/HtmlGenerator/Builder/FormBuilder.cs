using Application.HtmlGenerator.Elements;

namespace Application.HtmlGenerator.Builder
{
    /// <summary>
    /// Builder for an html form
    /// </summary>
    public class FormBuilder
    {
        public string FormAction { get; set; } = "";
        public string HoneyPotId { get; set; } = "";
        public IEnumerable<IHtmlElement> HtmlElements { get; set; } = [];


        public FormBuilder(string formAction, string honeyPotId, IEnumerable<IHtmlElement> htmlElements)
        {
            FormAction = formAction;
            HoneyPotId = honeyPotId;
            HtmlElements = htmlElements;
        }

        /// <summary>
        /// Creates a form (returned as a string) with the fields in <see cref="HtmlElements"/>
        /// and the action from <see cref="FormAction"/>
        /// </summary>
        public string GenerateHtmlString()
        {
            var listedElements = HtmlElements.Select(e =>
                "<div>" +
                    e.ToHtmlString() +
                "</div>"
                ).ToList();

            var banner = GenerateBannerDiv();
            var honeyPotField = GenerateHoneyPotField();

            listedElements.Add(honeyPotField);

            var htmlStringElements = string.Join(string.Empty, listedElements);

            var formString = $"{banner}<form action=\"{FormAction}\" method=\"post\" class=\"form-example\">{htmlStringElements}</form>";

            return formString;
        }

        /// <summary>
        /// Creates a fake input (HoneyPot) to catch submits from robots
        /// </summary>
        private string GenerateHoneyPotField()
        {
            var text = "&nbsp;";
            var isRequired = false;

            var textbox = new LabeledInput(HoneyPotId, text, isRequired);

            return $"<div class=\"{HoneyPotId}\">" +
                textbox.ToHtmlString() +
            "</div>"
            + GenerateHoneyPotCss();
        }

        /// <summary>
        /// Returns a simple implementation with css to hide the HoneyPot input
        /// </summary>
        private string GenerateHoneyPotCss()
        {
            return $"<style>.{HoneyPotId} {{position: absolute;left: -50000px;}}</style>";
        }

        private string GenerateBannerDiv()
        {
            return "<div class=\"banner\"><img src=\"https://cdn.bfldr.com/USU033TH/at/6xx8jnxw5csz2n3mcwxm84z/Elecate_pri_wtag.eps?auto=webp&format=png\" width=\"100px\" height=\"75px\" /></div>";
        }
    }
}
