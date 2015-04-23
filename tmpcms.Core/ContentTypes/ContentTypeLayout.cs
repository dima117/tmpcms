using System;
using System.Collections.Generic;
using tmpcms.Core.Infrastructure;

namespace tmpcms.Core.ContentTypes
{
	public class ContentTypeLayout : IContentType
	{
		public object Execute(ItemContext context, Dictionary<string, object> env)
		{
			var bodyId = new Guid(env["bodyid"].ToString());
			var bodyHtml = context.ExecuteItem(bodyId);

			var template = context.Templates.GetTemplate("layout");
			template.Add("body", bodyHtml);

			return template.Render();
		}
	}
}