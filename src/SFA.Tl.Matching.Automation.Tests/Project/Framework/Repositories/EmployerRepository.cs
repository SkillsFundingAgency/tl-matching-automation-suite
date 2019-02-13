using System.Linq;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories
{
    public class EmployerRepository
    {
        private readonly MatchingDbContext dbContext;

        public EmployerRepository(MatchingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Employer employer)
        {
            dbContext.Employer.Add(employer);

            dbContext.SaveChanges();
        }

        public Employer GetById(int id)
        {
           return dbContext.Employer.Single(t => t.Id == id);
        }

        public Employer GetByName(string name)
        {
            return dbContext.Employer.SingleOrDefault(employer => employer.CompanyName == name);
        }
    }
}