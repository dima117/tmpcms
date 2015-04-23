using tmpcms.Core.Infrastructure;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypePage : IContentType
	{
		public object Execute(ItemContext context)
		{
			return "static page content";
		}
	}
}