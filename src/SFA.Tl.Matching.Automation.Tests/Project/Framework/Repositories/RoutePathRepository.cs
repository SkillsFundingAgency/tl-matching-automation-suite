using System.Linq;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories
{
    public class RoutePathRepository
    {
        private readonly MatchingDbContext _dbContext;

        public RoutePathRepository(MatchingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Path> GetPaths()
        {
            return _dbContext.Path;
        }

        public IQueryable<Route> GetRoutes()
        {
            return _dbContext.Route;
        }
    }
}