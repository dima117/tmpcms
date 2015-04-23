using System;
using System.Collections.Generic;

namespace tmpcms.Core.Infrastructure
{
	public class Router
	{
		private readonly Dictionary<string, Guid> routes;

		public Router()
		{
			routes = Helpers.ReadJsonFile<Dictionary<string, Guid>>("routes.json");
		}

		public Guid? GetContentItemId(string path)
		{
			return routes.ContainsKey(path) ? routes[path] : (Guid?)null;
		}
	}
}