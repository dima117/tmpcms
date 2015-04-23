using System;
using System.Linq;
using tmpcms.Core.Infrastructure;
using tmpcms.Core.Model;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeHtml : IContentType
	{
		public object Execute(ItemContext context)
		{
			Guid id = new Guid(context.Options["id"].ToString());

			var htmlContent = context.Database.Set<HtmlContent>().FirstOrDefault(x => x.Id == id);
			return htmlContent != null ? htmlContent.Html : string.Empty;
		}
	}
}