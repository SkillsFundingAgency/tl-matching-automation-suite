using System;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class CreateAProvisionGapRecordSteps : BaseTest
    {
        [Then(@"the Check answers screen will display the provision gap details entered")]
        public void ThenTheCheckAnswersScreenWillDisplayTheProvisionGapDetailsEntered()
        {
            CheckAnswersPage checkAnswersPage = new CheckAnswersPage(webDriver);
            checkAnswersPage.VerifyPageHeader();
            checkAnswersPage.VerifyEmployersAnswers();
        }


        [Given(@"I press Confirm and Send on the Check answers page")]
        public void GivenIPressConfirmAndSendOnTheCheckAnswersPage()
        {
            CheckAnswersPage checkAnswersPage = new CheckAnswersPage(webDriver);
            checkAnswersPage.ClickConfirmAndSendutton();

        }

        [Given(@"I press Opt In on the Check answers page")]
        public void GivenIPressOptInOnTheCheckAnswersPage()
        {
            CheckAnswersPage checkAnswersPage = new CheckAnswersPage(webDriver);
            checkAnswersPage.ClickOptIn();
        }



        [Then(@"a Provision gap record will be created")]
        public void ThenAProvisionGapRecordWillBeCreated()
        {
            DonePage donePage = new DonePage(webDriver);
            donePage.VerifyProvisionGapRecordCreated();
            
        }

        [Then(@"the Opportunity record will record OPT IN has been selected")]
        public void ThenTheOpportunityRecordWillRecordOPTINHasBeenSelected()
        {
            DonePage donePage = new DonePage(webDriver);
            donePage.VerifyOptInValueRecorded("True");
        }


        [Then(@"the Opportunity record will record OPT IN has not been selected")]
        public void ThenTheOpportunityRecordWillRecordOPTINHasNotBeenSelected()
        {
            DonePage donePage = new DonePage(webDriver);
            donePage.VerifyOptInValueRecorded("False");
        }



    }

}
