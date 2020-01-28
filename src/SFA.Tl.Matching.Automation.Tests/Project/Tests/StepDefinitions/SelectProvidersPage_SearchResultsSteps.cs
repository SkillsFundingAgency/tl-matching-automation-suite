using System;
using System.Threading;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class SelectProvidersPage_SearchResultsSteps : BaseTest
    {
        [Then(@"I have run the method to return all providers within (.*) miles")]
        public void ThenIHaveRunTheMethodToReturnAllProvidersWithinMiles(int p0)
        {
            ProviderResultsHelper.ValidateProvidersDisplayed();
        }

        [Given(@"I entered new search criteria and press Search again button on the Select Providers Page")]
        public void GivenIenteredNewSearchAndPressSearch()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
                .EnterNewOpportunityDetailsAndSearchAgain(Constants.skillArea, Constants.postCode);
        }

        [When(@"I have filled in the search form on the Search Providers page with criteria which returns no results")]
        public void WhenIHaveFilledInTheSearchFormOnTheSearchProvidersPageWithCriteriaWhichWillReturnNoResults()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
                .EnterNewOpportunityDetailsAndSearchAgain(Constants.skillAreaNoResults, Constants.postcodeNoResults);
        }

        [When(@"I have filled in the search form on the Search Providers page with criteria which returns no results in only selected skill area")]
        public void WhenIHaveFilledInTheSearchFormOnTheSearchProvidersPageWithCriteriaWhichReturnsNoResultsInOnlySelectedSkillArea()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
               .EnterNewOpportunityDetailsAndSearchAgain(Constants.skillAreaNoResult, Constants.postCodeNoResultInSpecifiedRoute);
        }


        //some
        [When(@"I have filled in the search form on the Search Providers page with criteria which returns some results")]
        public void WhenIHaveFilledInTheSearchFormOnTheSearchProvidersPageWithCriteriaWhichWillReturnSomeResults()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
                .EnterNewOpportunityDetailsAndSearchAgain(Constants.skillArea, Constants.postCode);
        }

        //one
        [When(@"I have filled in the search form on the Search Providers page with criteria which returns (.*) result")]
        public void WhenIHaveFilledInTheSearchFormOnTheSearchProvidersPageWithCriteriaWhichWillReturnResult(String p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
                .EnterNewOpportunityDetailsAndSearchAgain(Constants.oneResultskillArea, Constants.oneResultpostCode);
        }

        [Then(@"the Select Providers page will display the postcode and skill area selected on the Find Providers page")]
        public void ThenTheSelectProvidersPageWillDisplayThePostcodeAndSkillAreaSelectedOnTheFindProvidersPage()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.postCode);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.skillArea);
            //selectProvidersPage.VerifySearchRadius(Constants.radius);
        }
        
        [Then(@"the Select Providers page will display (.*) results, skill area, postcode and radius in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayResultsSkillAreaPostcodeAndRadiusInTheHHeading(int p0, int p1)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.postCode);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.postCode);
            selectProvidersPage.VerifyZeroResultsCount();
            //selectProvidersPage.VerifySearchRadius(Constants.postCode);
        }

        
        [Then(@"the Select Providers page will display a H2 heading for zero results")]
        public void ThenTheSelectProvidersPageWillDisplayAHHeadingForZeroResults()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.postcodeNoResults);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.expectedskillAreaForNoResultsInAnySkillset);
            //selectProvidersPage.VerifySearchRadius(Constants.radiusNoResults);
            selectProvidersPage.VerifyZeroResultsCount();
            selectProvidersPage.VerifysHeadingShowsResults();
        }

        [Then(@"the Select Providers page will display a H2 heading for zero results for the selected skill area")]
        public void ThenTheSelectProvidersPageWillDisplayAHHeadingForZeroResultsForTheSelectedSkillArea()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.postCodeNoResultInSpecifiedRoute);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.skillAreaNoResult);
            //selectProvidersPage.VerifySearchRadius(Constants.radiusNoResults);
            selectProvidersPage.VerifyZeroResultsCount();
            selectProvidersPage.VerifysHeadingShowsResults();
        }


        [Then(@"the Select Providers page will display the count, skill area, postcode and radius in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeAndRadiusInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.postCode);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.skillArea);
            //selectProvidersPage.VerifySearchRadius(Constants.radius);
            selectProvidersPage.VerifyResultsCount();
            selectProvidersPage.VerifysHeadingShowsResults();
        }

        [Then(@"the Select Providers page will display the count, skill area, postcode, radius and text result in in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeRadiusAndTextResultInInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.oneResultpostCode);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.oneResultskillArea);
            //selectProvidersPage.VerifySearchRadius(Constants.oneResultradius);
            selectProvidersPage.VerifysHeadingShowsResult();
        }

        //need this one
        [Given(@"the Select Providers page will display the count, skill area, postcode and radius in the H(.*) heading")]
        public void GivenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeAndRadiusInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.oneResultpostCode);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.oneResultskillArea);
            //selectProvidersPage.VerifySearchRadius(Constants.oneResultradius);
            selectProvidersPage.VerifysHeadingShowsResult();
        }

        [Then(@"the Select Providers page will display the count, skill area, postcode and radius and text result in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeAndRadiusAndTextResultInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeDisplayed(Constants.postCode);
            selectProvidersPage.VerifySkillsetDisplayed(Constants.skillArea);
            selectProvidersPage.VerifyResultsCount();
            //selectProvidersPage.VerifySearchRadius(Constants.radius);
            selectProvidersPage.VerifysHeadingShowsResult();
        }

        [Then(@"the provider results returned will match the expected values")]
        public void ThenTheProviderResultsReturnedWillMatchTheExpectedValues()
        {
            //checks the providers returned by the SQL match the providers displayed on screen
            ProviderResultsHelper.ValidateProvidersDisplayed();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyResultsCount();           
        }       

        [Given(@"I select a provider and continue to placement information page")]
        public void GivenISelectSomeProvidersAndClickContinue()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.SelectProvidersAndContinue();
            Thread.Sleep(5000);
        }

        [When(@"I press Continue without selecting Providers")]
        public void WhenIPressContinueWithoutSelectingProviders()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ContinueWithoutSelectingProviders();
        }

        [Given(@"I clear the postcode field on the Select providers page and Search Again")]
        public void GivenIClearThePostcodeFieldOnTheSelectProvidersPageAndSearchAgain()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClearPostCodeAndSearchAgain();
        }

        [Then(@"I am shown an error for blank postcode stating ""(.*)""")]
        public void Iamshownanerrorforblankpostcodestating(string expectedErrorMessage)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeError(expectedErrorMessage);
        }

        [Then(@"I am shown an error for no provider selected stating ""(.*)""")]
        public void ThenIAmShownAnErrorForNoProviderSelectedStating(string expectedErrorMessage)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyProviderNotSelectedError(expectedErrorMessage);
        }

        [Given(@"I enter an invalid postcode on the Select providers page and Search again")]
        public void GivenIEnterAnInvalidPostcodeOnTheSelectProvidersPageAndSearchAgain()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.EnterInvalidPostCodeAndSearchAgain();
        }

        [Then(@"I am shown an error for invalid postcode stating ""(.*)""")]
        public void ThenIAmShownAnErrorForInvalidPostcodeStating(string expectedErrorMessage)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyInvalidPostcodeError(expectedErrorMessage);
        }
    }
}
