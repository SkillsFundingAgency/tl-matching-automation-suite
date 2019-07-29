using System;

namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data
{
    public class ProviderCourses
    {
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }
        public Guid CourseId { get; set; }
        public virtual Provider Provider { get; set; }
    }
}