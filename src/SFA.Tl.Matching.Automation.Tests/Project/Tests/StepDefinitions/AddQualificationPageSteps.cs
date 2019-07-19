using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;
using TechTalk.SpecFlow;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddQualificationPageSteps : BaseTest
    {
        [When(@"I add a Qualification that is already mapped to the service")]
        public void WhenIAddAQualificationThatIsAlreadyMappedToTheService()
        {
            VenueAndQualificationsDetailsPage VenueAndQualificationsDetailsPage = new VenueAndQualificationsDetailsPage(webDriver);
            String QualId = VenueAndQualificationsDetailsPage.GetQualificationId(Constants.queryToGetQualificationMappedToService);
            ScenarioContext.Current["MappedQualificationId"] = QualId;
            VenueAndQualificationsDetailsPage.ClickAddQualificationLink();
            AddQualificationPage AddQualificationPage = new AddQualificationPage(webDriver);
            AddQualificationPage.SearchForLarId(QualId);
        }

        [When(@"I add a Qualification that is Not mapped to the service")]
        public void WhenIAddAQualificationThatIsNotMappedToTheService()
        {
            VenueAndQualificationsDetailsPage VenueAndQualificationsDetailsPage = new VenueAndQualificationsDetailsPage(webDriver);
            String QualId = VenueAndQualificationsDetailsPage.GetQualificationId(Constants.queryToGetQualificationNotMappedToService);
            ScenarioContext.Current["MappedQualificationId"] = QualId;
            VenueAndQualificationsDetailsPage.ClickAddQualificationLink();
            AddQualificationPage AddQualificationPage = new AddQualificationPage(webDriver);
            AddQualificationPage.SearchForLarId(QualId);
            AddQualificationPage.AutoPopulateFields();
            AddQualificationPage.ClickAddQualification();
        }
    }
}
