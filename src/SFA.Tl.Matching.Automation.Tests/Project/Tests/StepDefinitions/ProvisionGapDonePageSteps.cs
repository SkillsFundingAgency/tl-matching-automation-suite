using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProvisionGapDonePageSteps : BaseTest
    {
        [Then(@"the Provision Gap Done page is displayed")]
        public void ThenTheProvisionGapDonePageIsDisplayed()
        {
            DonePage donePage = new DonePage(webDriver);
            donePage.ClickFinishbutton();
        }
    }
}
