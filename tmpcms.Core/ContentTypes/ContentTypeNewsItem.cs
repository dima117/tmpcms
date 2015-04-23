using tmpcms.Core.Infrastructure;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeNewsItem : IContentType
	{
		public object Execute(ItemContext context)
		{
			return "news item content";
		}
	}
}