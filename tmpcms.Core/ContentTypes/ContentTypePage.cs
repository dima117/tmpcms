using System.Collections.Generic;
using tmpcms.Core.Infrastructure;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypePage : IContentType
	{
		public object Execute(ItemContext context, Dictionary<string, object> env)
		{
			return "static page content";
		}
	}
}