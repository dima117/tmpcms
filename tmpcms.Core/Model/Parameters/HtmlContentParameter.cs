using System;
using tmpcms.Core.Infrastructure.Interfaces;

namespace tmpcms.Core.Model.Parameters
{
	public class HtmlContentParameter : IContentItemParameter
	{
		public Guid Id { get; set; }

		public Guid ItemId { get; set; }

		public string Name { get; set; }

		public string Html { get; set; }
	}
}