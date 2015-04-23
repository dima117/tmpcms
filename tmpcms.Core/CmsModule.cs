using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using tmpcms.Core.ContentTypes;
using tmpcms.Core.Infrastructure;

namespace tmpcms.Core
{
	using AppFunc = Func<IDictionary<string, object>, Task>;

	public class CmsModule
	{
		private static readonly Router router = new Router();
		private static readonly TemplateEngine templateEngine = new TemplateEngine();

		private readonly Dictionary<string, Type> contentTypes = new Dictionary<string, Type>();
		private readonly Dictionary<Guid, ContentItem> contentItems;

		private readonly AppFunc next;

		public CmsModule(AppFunc next)
		{
			if (next == null)
			{
				throw new ArgumentNullException("next");
			}

			this.next = next;

			// init content types
			// todo: заменить на фабрики типов с псевдонимами и методами: создать item, инициализировать модель
			// todo: подключать фабрики через атрибуты
			contentTypes.Add("page", typeof(ContentTypePage));
			contentTypes.Add("html", typeof(ContentTypeHtml));
			contentTypes.Add("news", typeof(ContentTypeNews));
			contentTypes.Add("news-item", typeof(ContentTypeNewsItem));

			// content items
			contentItems = Helpers.ReadJsonFile<Dictionary<Guid, ContentItem>>("content.json");
		}

		public Task Invoke(IDictionary<string, object> env)
		{
			try
			{
				var request = new OwinRequest(env);
				var path = request.Path.Value;

				var contentItemId = router.GetContentItemId(path);

				if (contentItemId.HasValue)
				{
					ContentItem contentItem = contentItems[contentItemId.Value];

					using (var context = new ItemContext(templateEngine, request, contentItem.parameters))
					{
						Type contentTypeClass = contentTypes[contentItem.type];
						var item = Activator.CreateInstance(contentTypeClass) as IContentType;

						var result = item == null
							? string.Empty
							: item.Execute(context);

						var response = new OwinResponse(env);
						return response.WriteAsync(result.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				var tcs = new TaskCompletionSource<object>();
				tcs.SetException(ex);
				return tcs.Task;
			}

			return next(env);
		}
	}

	public class ContentItem
	{
		public string type;
		public Dictionary<string, object> parameters;
	}
}