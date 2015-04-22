using System.Collections.Generic;
using System.Data.Entity;

namespace tmpcms.Core
{
	interface IContentType
	{
		object Execute(IDictionary<string, object> request, Dictionary<string, object> item, DbContext db);
	}
}
