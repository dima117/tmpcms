using System.Collections.Generic;
using tmpcms.Core.Infrastructure;
using tmpcms.Core.Infrastructure.Interfaces;
using tmpcms.Core.Model.Parameters;

namespace tmpcms.Core.ContentTypes
{
	public class ContentItemLayout : IContentItem
	{
		public ItemLinkParameter Body { get; set; }

		public object Execute(ItemContext context, IDictionary<string, object> env)
		{
			var bodyHtml = Body != null ? context.ExecuteItem(Body.LinkedItemId, env) : string.Empty;

			var template = context.Templates.GetTemplate("layout");
			template.Add("body", bodyHtml);

			return template.Render();
		}
	}
}