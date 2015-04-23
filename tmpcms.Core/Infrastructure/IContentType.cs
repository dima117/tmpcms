using System.Collections.Generic;

namespace tmpcms.Core.Infrastructure
{
	interface IContentType
	{
		object Execute(ItemContext context, Dictionary<string, object> options);
	}
}
