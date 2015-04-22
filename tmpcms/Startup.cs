using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using tmpcms.Core;

namespace tmpcms
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.Use<CmsModule>();
		}
	}
}