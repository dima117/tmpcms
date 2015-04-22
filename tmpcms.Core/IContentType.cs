using System.Collections.Generic;

namespace tmpcms.Core
{
	interface IContentType
	{
		object Execute(IDictionary<string, object> args);
	}
}
