using System.Text;
using Antlr4.StringTemplate;

namespace tmpcms.Core.Infrastructure
{
	public class TemplateEngine
	{
		private readonly TemplateGroup templateGroup;
		
		public TemplateEngine()
		{
			var path = Helpers.GetServerPath("templates");
			templateGroup = new TemplateGroupDirectory(path, Encoding.UTF8, '$', '$');
		}

		public Template GetTemplate(string alias)
		{
			return templateGroup.GetInstanceOf(alias);
		}
	}
}