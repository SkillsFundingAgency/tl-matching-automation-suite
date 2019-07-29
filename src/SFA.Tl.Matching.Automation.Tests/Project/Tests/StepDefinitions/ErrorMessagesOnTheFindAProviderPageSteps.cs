using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class ErrorMessagesOnTheFindAProviderPageSteps : BaseTest
    {             

        [Given(@"I navigate to the FindProviders page")]
        public void GivenINavigateToTheFindProvidersPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
        }
        
        [Given(@"I clear the postcode field")]
        public void GivenIClearThePostcodeField()
        {
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.ClearPostcode();
        }
        
        [Given(@"I press Continue on the Find a Provider page")]
        public void GivenIPressContinueOnTheFindAProviderPage()
        {
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.ClickSearchButton();
        }
        
        [Then(@"the Find a Provider page will show an error stating ""(.*)""")]
        public void ThenTheFindAProviderPageWillShowAnErrorStating(string postcodeError)
        {
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.VerifyPostcodeError(postcodeError);
        }
    }
}
