using System;
using System.Collections.Generic;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data
{
    public class RoutePath
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public int RoutePathLookupId { get; set; }
        public string Summary { get; set; }
        public string Keywords { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Path Path { get; set; }
    }
}