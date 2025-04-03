using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HtmlGenerator.Elements
{
    public abstract class BaseHtmlElement : IHtmlElement
    {
        public string Id { get; set; } = "";
        public string Required { get => _required ? "required" : string.Empty ; }

        private bool _required;

        protected BaseHtmlElement(string id, bool isRequired)
        {
            Id = id;
            _required = isRequired;
        }

        public abstract string ToHtmlString();
    }
}
