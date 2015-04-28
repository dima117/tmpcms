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
		private static readonly ContentManager contentManager;

		private static readonly Dictionary<string, Type> contentTypes = new Dictionary<string, Type>();

		private readonly AppFunc next;

		static CmsModule()
		{
			// init content types
			// todo: заменить на фабрики типов с псевдонимами и методами: создать item, инициализировать модель
			// todo: подключать фабрики через атрибуты
			contentTypes.Add("html", typeof(ContentItemHtml));
			contentTypes.Add("layout", typeof(ContentItemLayout));

			contentManager = new ContentManager(contentTypes);			
		}

		public CmsModule(AppFunc next)
		{
			if (next == null)
			{
				throw new ArgumentNullException("next");
			}

			this.next = next;
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
					using (var context = new ItemContext(templateEngine, request, contentManager))
					{
						var result = context.ExecuteItem(contentItemId.Value, env);
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
}