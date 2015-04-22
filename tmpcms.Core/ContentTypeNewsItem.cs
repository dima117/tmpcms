using System;
using System.Collections.Generic;

namespace tmpcms.Core
{
	public class ContentTypeNewsItem : IContentType
	{
		public object Execute(IDictionary<string, object> args)
		{
			return "news item content";
		}
	}
}