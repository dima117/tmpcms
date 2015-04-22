using System;
using System.Collections.Generic;

namespace tmpcms.Core
{
	public class ContentTypePage : IContentType
	{
		public object Execute(IDictionary<string, object> args)
		{
			return "static page content";
		}
	}
}