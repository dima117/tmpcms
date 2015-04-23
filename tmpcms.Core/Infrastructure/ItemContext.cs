using System;
using System.Collections.Generic;
using Microsoft.Owin;

namespace tmpcms.Core.Infrastructure
{
	public class ItemContext : IDisposable
	{
		public readonly TemplateEngine Templates;
		public readonly OwinRequest Request;
		public readonly CmsDbContext Database;

		private readonly Dictionary<string, Type> contentTypes;
		private readonly Dictionary<Guid, ContentItem> contentItems;

		public ItemContext(
			TemplateEngine templates, 
			OwinRequest request, 
			//Dictionary<string, object> options, 
			Dictionary<string, Type> contentTypes,
			Dictionary<Guid, ContentItem> contentItems)
		{
			Templates = templates;
			Request = request;
			this.contentTypes = contentTypes;
			this.contentItems = contentItems;
			Database = new CmsDbContext();
		}

		// todo: сделать типизированные методы получения параметров

		public void Dispose()
		{
			Database.Dispose();
		}

		public object ExecuteItem(Guid contentItemId)
		{
			ContentItem contentItem = contentItems[contentItemId];
			Type contentTypeClass = contentTypes[contentItem.type];
			var item = Activator.CreateInstance(contentTypeClass) as IContentType;

			var result = item == null
				? string.Empty
				: item.Execute(this, contentItem.parameters);

			return result;
		}
	}
}