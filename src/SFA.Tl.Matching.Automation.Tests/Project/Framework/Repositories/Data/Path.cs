using System;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data
{
    public class Path
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public string Summary { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Route Route { get; set; }
    }
}