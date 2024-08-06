using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AKS.Demo.Areas.Identity.Data;

public class AksDemoContext : IdentityDbContext<ApplicationUser>
{
	public virtual DbSet<ApplicationUser> AspNetUser { get; set; }

	public AksDemoContext(DbContextOptions<AksDemoContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		// Customize the ASP.NET Identity model and override the defaults if needed.
		// For example, you can rename the ASP.NET Identity table names and more.
		// Add your customizations after calling base.OnModelCreating(builder);
	}
}
