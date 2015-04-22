using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using tmpcms.Core.Model;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeHtml : IContentType
	{
		public object Execute(IDictionary<string, object> request, Dictionary<string, object> item, DbContext db)
		{
			Guid id = new Guid(item["id"].ToString());

			return db.Set<HtmlContent>().Single(x => x.Id == id).Html;
		}
	}
}