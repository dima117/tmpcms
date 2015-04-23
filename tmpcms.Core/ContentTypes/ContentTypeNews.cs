using System.Collections.Generic;
using tmpcms.Core.Infrastructure;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeNews : IContentType
	{
		public object Execute(ItemContext context, Dictionary<string, object> env)
		{
			return "news page content";
		}
	}
}