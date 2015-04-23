using Antlr4.StringTemplate;

namespace tmpcms.Core.Infrastructure
{
	public class TemplateEngine
	{
		private readonly TemplateGroup templateGroup;
		
		public TemplateEngine()
		{
			templateGroup = new TemplateGroupDirectory("/templates");
		}

		public Template GetTemplate(string alias)
		{
			return templateGroup.GetInstanceOf(alias);
		}
	}
}