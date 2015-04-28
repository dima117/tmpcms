using System.Data.Entity;
using tmpcms.Core.Model.Parameters;

namespace tmpcms.Core.Infrastructure
{
	public class CmsDbContext : DbContext
    {

		public CmsDbContext()
			: base("main")
        {
        }

		public DbSet<HtmlContentParameter> HtmlContents { get; set; }
    }
}