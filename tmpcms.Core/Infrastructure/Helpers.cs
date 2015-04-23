using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace tmpcms.Core.Infrastructure
{
	public class Helpers
	{
		public static string BasePath
		{
			get
			{
				return AppDomain.CurrentDomain.BaseDirectory;
			}
		}

		public static string GetServerPath(string relativePath)
		{
			return Path.Combine(BasePath, relativePath);
		}

		public static TResult ReadJsonFile<TResult>(string relativePath)
		{
			var filePath = GetServerPath(relativePath);
			var content = File.ReadAllText(filePath);
			return JsonConvert.DeserializeObject<TResult>(content);
		}
	}
}