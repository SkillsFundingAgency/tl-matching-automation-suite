using System.Configuration;
using Microsoft.EntityFrameworkCore;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories
{
    public class MatchingDbContext : DbContext
    {
        public MatchingDbContext()
            : base(new DbContextOptionsBuilder<MatchingDbContext>()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["MatchingConnection"].ConnectionString).Options)
        {

        }

        public virtual DbSet<Path> Path { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderCourses> ProviderCourses { get; set; }
        public virtual DbSet<RoutePath> RoutePath { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Employer> Employer { get; set; }
    }
}