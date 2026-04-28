using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppMVCAchivers.Taghelprs
{
    [HtmlTargetElement("greet")]

    public class WelcomeTagHelper : TagHelper
    {
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h1";
            output.Content.SetContent($"Welcome- {Name}");
        }
    }
}
