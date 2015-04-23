using System.Collections.Generic;
using tmpcms.Core.Infrastructure;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeNewsItem : IContentType
	{
		public object Execute(ItemContext context, Dictionary<string, object> env)
		{
			return "news item content";
		}
	}
}