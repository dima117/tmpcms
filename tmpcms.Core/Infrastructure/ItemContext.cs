using System;
using System.Collections.Generic;
using Microsoft.Owin;

namespace tmpcms.Core.Infrastructure
{
	public class ItemContext : IDisposable
	{
		public readonly TemplateEngine Templates;
		public readonly OwinRequest Request;
		public readonly Dictionary<string, object> Options;
		public readonly CmsDbContext Database;

		public ItemContext(TemplateEngine templates, OwinRequest request, Dictionary<string, object> options)
		{
			Templates = templates;
			Request = request;
			Options = options;
			Database = new CmsDbContext();
		}

		// todo: сделать типизированные методы получения параметров

		public void Dispose()
		{
			Database.Dispose();
		}
	}
}