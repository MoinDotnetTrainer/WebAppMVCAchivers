using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppMVCAchivers.Taghelprs
{

    [HtmlTargetElement("button", Attributes = "greet")]
    public class BtnTagHelper : TagHelper
    {
        public string Greet { get; set; }
        public string btnstyle { get; set; }

        public string btntext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var message = string.IsNullOrEmpty(Greet) ? "Hello!" : $"Hello, {Greet}!";

            // Add custom attribute (example)
            output.Attributes.SetAttribute("onclick", $"alert('{message}')");
            output.Attributes.SetAttribute("class", btnstyle);
            output.Content.SetContent(btntext);
        }
    }
}

