using System;
using System.Collections.Generic;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ukprn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<ProviderCourses> ProviderCourses { get; set; }
    }
}