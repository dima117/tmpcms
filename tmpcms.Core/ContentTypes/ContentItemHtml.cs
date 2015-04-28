using System.Collections.Generic;
using tmpcms.Core.Infrastructure;
using tmpcms.Core.Infrastructure.Interfaces;
using tmpcms.Core.Model.Parameters;

namespace tmpcms.Core.ContentTypes
{
	public class ContentItemHtml : IContentItem
	{
		public HtmlContentParameter Content { get; set; }

		public object Execute(ItemContext context, IDictionary<string, object> env)
		{
			return Content != null ? Content.Html : string.Empty;
		}
	}
}