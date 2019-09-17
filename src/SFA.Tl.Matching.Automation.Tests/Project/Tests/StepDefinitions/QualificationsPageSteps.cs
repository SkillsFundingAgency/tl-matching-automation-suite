using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;


namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class QualificationsPageSteps : BaseTest
    {
        [Given(@"I am on the Qualification Details Page (.*)")]
        public void GivenIAmOnTheQualificationDetailsPage(String UkprnNumber)
        {
            FindAProviderPage FindAProviderPage = new FindAProviderPage(webDriver);
            FindAProviderPage.SearchForAProviderUkprn(UkprnNumber);
            FindAProviderPage.ClickProviderEditLink();
            ProviderAndVenuesDetailsPage ProviderAndVenuesDetailsPage = new ProviderAndVenuesDetailsPage(webDriver);
            var PostCode = ProviderAndVenuesDetailsPage.GetPostCodeFromVenues();            
            ScenarioContext.Current["PostCodeTextFromVenuesTable"] = PostCode;
            ProviderAndVenuesDetailsPage.ClickVenueEditLink();
        }

        [Then(@"the Qualification should be added successfully")]
        public void ThenTheQualificationShouldBeAddedSuccessfully()
        {
            String mappedQualId = (String)ScenarioContext.Current["MappedQualificationId"];
            VenueAndQualificationsDetailsPage VenueAndQualificationsDetailsPage = new VenueAndQualificationsDetailsPage(webDriver);
            VenueAndQualificationsDetailsPage.VerifyQualificationIsAdded(mappedQualId);
        }
    }
}
