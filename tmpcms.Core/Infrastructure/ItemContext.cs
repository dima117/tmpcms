using System;
using System.Collections.Generic;
using Microsoft.Owin;
using tmpcms.Core.Infrastructure.Interfaces;

namespace tmpcms.Core.Infrastructure
{
	public class ItemContext : IDisposable
	{
		public readonly TemplateEngine Templates;
		public readonly OwinRequest Request;
		public readonly CmsDbContext Database;
		public readonly ContentManager ContentManager;

		public ItemContext(
			TemplateEngine templates, 
			OwinRequest request, 
			ContentManager contentManager)
		{
			Templates = templates;
			Request = request;
			ContentManager = contentManager;
			Database = new CmsDbContext();
		}

		// todo: сделать типизированные методы получения параметров

		public void Dispose()
		{
			Database.Dispose();
		}

		public object ExecuteItem(Guid itemId, IDictionary<string, object> env)
		{
			var item = ContentManager.LoadContentItem(itemId);

			var result = item == null
				? string.Empty
				: item.Execute(this, env);

			return result;
		}
	}
}