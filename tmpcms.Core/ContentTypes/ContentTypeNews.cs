using tmpcms.Core.Infrastructure;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeNews : IContentType
	{
		public object Execute(ItemContext context)
		{
			return "news page content";
		}
	}
}