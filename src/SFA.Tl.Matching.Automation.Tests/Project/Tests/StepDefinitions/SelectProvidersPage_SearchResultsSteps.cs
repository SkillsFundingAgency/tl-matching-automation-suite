using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class SelectProvidersPage_SearchResultsSteps : BaseTest
    {
        [Given(@"I have entered new Skill Area as ""(.*)""")]
        public void GivenIHaveEnteredNewSkillAreaAs(string Skillset)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.SelectSkillset(Skillset);
        }
        
        [Given(@"Employer postcode as ""(.*)""")]
        public void GivenEmployerPostcodeAs(string postcode)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.EnterPostcode(postcode);
        }
        
        [Given(@"Providers within as ""(.*)""")]
        public void GivenProvidersWithinAs(string postcodeRadius)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.SelectPostcodeRadius(postcodeRadius);
        }
        
        [Then(@"the Select Providers page will display the postcode and skill area selected on the Find Providers page")]
        public void ThenTheSelectProvidersPageWillDisplayThePostcodeAndSkillAreaSelectedOnTheFindProvidersPage()
        {

            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed();
            selectProvidersPage.VerifySkillsetDisplayed();
        }
        
        [Then(@"the Select Providers page will display the skill area, postcode and radius in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheSkillAreaPostcodeAndRadiusInTheHHeading(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
