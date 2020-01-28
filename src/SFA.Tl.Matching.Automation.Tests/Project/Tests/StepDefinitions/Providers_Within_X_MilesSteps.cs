using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class Providers_Within_X_MilesSteps
    {
        [Given(@"I have entered a postcode")]
        public void GivenIHaveEnteredAPostcode()
        {
            ProviderResultsHelper.AllProviders_AllSkillAreas();
        }
     }
}
