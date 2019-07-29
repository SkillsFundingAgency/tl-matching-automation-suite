using System;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
namespace SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories.Data
{
    public class Employer
    {
        public int Id { get; set; }
        public Guid CrmId { get; set; }
        public string CompanyName { get; set; }
        public string AlsoKnownAs { get; set; }
        public string PrimaryContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PostCode { get; set; }
        public string Owner { get; set; }
    }
}