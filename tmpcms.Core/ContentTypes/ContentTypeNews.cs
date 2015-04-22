using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeNews : IContentType
	{
		public object Execute(IDictionary<string, object> request, Dictionary<string, object> item, DbContext db)
		{
			return "news page content";
		}
	}
}