using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport
{
    public class Constants
    {
        public const String postCode = "B43 6JN";
        public const String skillArea = "Construction";
        public const String radius = "25 miles";
        public const String jobTitle = "Builder";
        public const String employerName = "Abacus Childrens Nurseries";
        public const String testEmployerNameForVerification = "Test Account DO NOT USE";
        public const String testName = "Shalini 123";
        public const String testEmail = "testEmail@fhgygy.com";
        public const String testPhoneNumber = "01234567890";
        public const String NoofPlacements = "at least 1";
        public const String expectedCount = "1";
        public const String ProvisionGapOptInFalse = "False";
        public const String ProvisionGapOptInNo = "Null";
        public const String NoofPlacementEntered = "at least 1";
        public const String InvalidUser = "InvalidUser";
        public const String InvalidPass = "InvalidPass";
        public const String postcodeNoResults = "G63 0AR";
        public const String skillAreaNoResults = "Agriculture, environmental and animal care";
        public const String expectedskillAreaForNoResultsInAnySkillset = "any skill area";
        public const String radiusNoResults = "5 miles" ;
        public const String oneResultpostCode = "B43 6JN";
        public const String oneResultskillArea = "Protective services";
        public const String oneResultradius = "5 miles";
        public const String queryToGetQualificationMappedToService = "SELECT LarId FROM LearningAimReference lar LEFT JOIN Qualification q ON lar.LarID = q.LarsID WHERE q.LarsID = lar.LarId";
        public const String queryToGetQualificationNotMappedToService = "SELECT LarId FROM LearningAimReference lar LEFT JOIN Qualification q ON lar.LarID=q.LarsID WHERE q.LarsID IS NULL order by lar.Id desc";
        public const String Opportunity1Postcode = "B43 6JN";
        public const String Opportunity1JobRole = "None given";
        public const String Opportunity1StudentsWanted = "at least 1";
        public const String Opportunity1Providers = "1";
        public const String opportunity2Postcode = "B43 6JN";
        public const String opportunity2JobRole = "None given";
        public const String opportunity2StudentsWanted = "at least 1";
        public const String opportunity2Providers = "1";
        public const String opportunity2SkillArea = "Care services";

    }
}
