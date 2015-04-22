using System;
using System.Collections.Generic;

namespace tmpcms.Core
{
	public class ContentTypeNews : IContentType
	{
		public object Execute(IDictionary<string, object> args)
		{
			return "news page content";
		}
	}
}