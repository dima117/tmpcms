using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;
using tmpcms.Core.ContentTypes;

namespace tmpcms.Core
{
	using AppFunc = Func<IDictionary<string, object>, Task>;


	public class CmsModule
	{
		private readonly Dictionary<string, Type> contentTypes = new Dictionary<string, Type>();
		private readonly Dictionary<string, Guid> routes = new Dictionary<string, Guid>();
		private readonly Dictionary<Guid, ContentItem> contentItems;

		private readonly AppFunc next;

		public CmsModule(AppFunc next)
		{
			if (next == null)
			{
				throw new ArgumentNullException("next");
			}

			this.next = next;

			Initialize();

			// content items
			var basePath = AppDomain.CurrentDomain.BaseDirectory;
			var content = File.ReadAllText(Path.Combine(basePath, "content.json"));
			contentItems = JsonConvert.DeserializeObject<Dictionary<Guid, ContentItem>>(content);
		}

		private void Initialize()
		{
			// init content types
			contentTypes.Add("page", typeof(ContentTypePage));
			contentTypes.Add("html", typeof(ContentTypeHtml));
			contentTypes.Add("news", typeof(ContentTypeNews));
			contentTypes.Add("news-item", typeof(ContentTypeNewsItem));

			// init routes
			routes.Add("/", new Guid("efb3e495662a49308642ddd9a5a4065e"));
			routes.Add("/contacts", new Guid("aaf164cc62b448ed92af845d0b92f6d8"));
			routes.Add("/news", new Guid("900077380c4f4516a642f2ba8d1400e2"));
			routes.Add("/news/{alias}", new Guid("648c94b0f9124483af0b63deac039056"));
		}

		public Task Invoke(IDictionary<string, object> env)
		{
			try
			{
				var request = new OwinRequest(env);
				var path = request.Path.Value;

				if (routes.ContainsKey(path))
				{
					// todo: сделать класс "роутер"
					// todo: сделать класс "контекст запроса": параметры запроса, параметры элемента, dbcontext
					using (var db = new CmsDbContext())
					{
						ContentItem contentItem = contentItems[routes[path]];
						Type contentTypeClass = contentTypes[contentItem.type];
						var item = Activator.CreateInstance(contentTypeClass) as IContentType;

						var result = item.Execute(env, contentItem.parameters, db);

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