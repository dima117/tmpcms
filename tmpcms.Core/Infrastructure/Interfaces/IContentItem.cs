using System.Collections.Generic;

namespace tmpcms.Core.Infrastructure.Interfaces
{
	public interface IContentItem
	{
		object Execute(ItemContext context, IDictionary<string, object> options);
	}
}
