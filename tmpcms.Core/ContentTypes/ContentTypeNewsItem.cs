using System.Data.Entity;
using System.Collections.Generic;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeNewsItem : IContentType
	{
		public object Execute(IDictionary<string, object> request, Dictionary<string, object> item, DbContext db)
		{
			return "news item content";
		}
	}
}