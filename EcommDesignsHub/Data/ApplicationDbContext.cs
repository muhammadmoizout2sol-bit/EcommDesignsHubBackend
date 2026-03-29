using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommDesignsHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.ProjectModel> Projects { get; set; }
        public DbSet<Models.ProjectCategory> Categories { get; set; }
        public DbSet<Models.Job> Jobs{ get; set; }
        public DbSet<Models.Application> Applications { get; set; }

    }


}
