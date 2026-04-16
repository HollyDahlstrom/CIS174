using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ch04MovieListDahlstrom.TagHelpers
{
    [HtmlTargetElement("submit-button")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public string Text { get; set; } = "Submit";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("class", "btn btn-primary");

            output.Content.SetContent(Text);
        }
    }
}