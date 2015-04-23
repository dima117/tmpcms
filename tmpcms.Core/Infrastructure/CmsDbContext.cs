using System.Data.Entity;
using tmpcms.Core.Model;

namespace tmpcms.Core.Infrastructure
{
	public class CmsDbContext : DbContext
    {

		public CmsDbContext()
			: base("main")
        {
        }

		public DbSet<HtmlContent> HtmlContents { get; set; }
    }
}