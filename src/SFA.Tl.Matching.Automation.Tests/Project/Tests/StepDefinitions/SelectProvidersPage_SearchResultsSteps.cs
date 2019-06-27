using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class SelectProvidersPage_SearchResultsSteps : BaseTest
    {
        [Given(@"Given I have entered new Skill Area as ""(.*)""")]
        public SelectProvidersPage GivenIHaveEnteredNewSkillAreaAs(string skillArea)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver).SelectSkillArea(Constants.skillArea);            
            return selectProvidersPage;
        }

        [Given(@"I have entered new Skill Area in dropdown")]
        public void GivenIHaveEnteredNewSkillAreaInDropdown()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .SelectSkillArea(Constants.skillArea);
        }


        [Given(@"I entered new search criteria and press Search again button on the Select Providers Page")]
        public void GivenIenteredNewSearchAmdPressSearch()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver).SelectSearchAgain();
            
        }

        [Given(@"I have filled in the search form on the Search Providers page with criteria which will return no results")]
        public void GivenIHaveFilledInTheSearchFormOnTheSearchProvidersPageWithCriteriaWhichWillReturnNoResults()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .EnterPostcode(Constants.postcodeNoResults)
            .SelectPostcodeRadius(Constants.radiusNoResults)
            .SelectSkillArea(Constants.skillAreaNoResults);
        }

        [Given(@"Employer postcode as ""(.*)""")]
        public SelectProvidersPage GivenEmployerPostcodeAs(string postcode)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .EnterPostcode(Constants.postCode);
            return selectProvidersPage;
        }

        //[Given(@"Employer postcode1 as ""(.*)""")]
        //public void GivenEmployerPostcodeAs(int p0, string p1)
        //{
        //    ScenarioContext.Current.Pending();
        //}

        //some
        [Given(@"I have filled in the search form on the Search Providers page with criteria which will return some results")]
        public void GivenIHaveFilledInTheSearchFormOnTheSearchProvidersPageWithCriteriaWhichWillReturnSomeResults()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
                .EnterPostcode(Constants.postCode)
                .SelectSkillArea(Constants.skillArea)
                .SelectPostcodeRadius(Constants.radius);
               
        }

        //one
        [Given(@"I have filled in the search form on the Search Providers page with criteria which will return (.*) result")]
        public void GivenIHaveFilledInTheSearchFormOnTheSearchProvidersPageWithCriteriaWhichWillReturnResult(String p0)
        {
           SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
          .EnterPostcode(Constants.oneResultpostCode)
          .SelectSkillArea(Constants.oneResultskillArea)
          .SelectPostcodeRadius(Constants.oneResultradius);
        }


        [Given(@"Providers within as ""(.*)""")]
        public SelectProvidersPage GivenProvidersWithinAs(string postcodeRadius)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver).SelectPostcodeRadius(Constants.radius);
            return selectProvidersPage;
        }

        [Then(@"the Select Providers page will display the postcode and skill area selected on the Find Providers page")]
        public void ThenTheSelectProvidersPageWillDisplayThePostcodeAndSkillAreaSelectedOnTheFindProvidersPage()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .VerifyPostcodeDisplayed(Constants.postCode)
            .VerifySkillsetDisplayed(Constants.skillArea)
            .VerifySearchRadius(Constants.radius);
        }
        
        [Then(@"the Select Providers page will display (.*) results, skill area, postcode and radius in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayResultsSkillAreaPostcodeAndRadiusInTheHHeading(int p0, int p1)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .VerifyPostcodeDisplayed(Constants.postCode)
            .VerifySkillsetDisplayed(Constants.postCode)
            .VerifyZeroResultsCount()
            .VerifySearchRadius(Constants.postCode);
        }

        //maybe redundant
        [Then(@"the Select Providers page will display a H(.*) heading for zero results")]
        public void ThenTheSelectProvidersPageWillDisplayAHHeadingForZeroResults(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .VerifyPostcodeDisplayed(Constants.postcodeNoResults)
            .VerifySkillsetDisplayed(Constants.skillAreaNoResults)
            .VerifySearchRadius(Constants.radiusNoResults)
            .VerifyZeroResultsCount()
            .VerifysHeadingShowsResults();
        }

        [Then(@"the Select Providers page will display the count, skill area, postcode and radius in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeAndRadiusInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .VerifyPostcodeDisplayed(Constants.postCode)
            .VerifySkillsetDisplayed(Constants.skillArea)
            .VerifySearchRadius(Constants.radius)
            .VerifyResultsCount()
            .VerifysHeadingShowsResults();
        }

        [Given(@"the Select Providers page will display the count, skill area, postcode, radius and text result in in the H(.*) heading")]
        public void GivenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeRadiusAndTextResultInInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
              .VerifyPostcodeDisplayed(Constants.oneResultpostCode)
              .VerifySkillsetDisplayed(Constants.oneResultskillArea)
              .VerifySearchRadius(Constants.oneResultradius)
              .VerifysHeadingShowsResult();
        }


        //need this one
        [Given(@"the Select Providers page will display the count, skill area, postcode and radius in the H(.*) heading")]
        public void GivenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeAndRadiusInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
              .VerifyPostcodeDisplayed(Constants.oneResultpostCode)
              .VerifySkillsetDisplayed(Constants.oneResultskillArea)
              .VerifySearchRadius(Constants.oneResultradius)
              .VerifysHeadingShowsResult();
        }


        [Then(@"the Select Providers page will display the count, skill area, postcode and radius and text result in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountSkillAreaPostcodeAndRadiusAndTextResultInTheHHeading(int p0)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
               .VerifyPostcodeDisplayed(Constants.postCode)
               .VerifySkillsetDisplayed(Constants.skillArea)
               .VerifyResultsCount()
               .VerifySearchRadius(Constants.radius)
               .VerifysHeadingShowsResult();
        }



        [Then(@"the provider results returned will match the expected values")]
        public void ThenTheProviderResultsReturnedWillMatchTheExpectedValues()
        {
            //checks the providers returned by the SQL match the providers displayed on screen
            ProviderResultsHelper.ValidateProvidersDisplayed();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .VerifyResultsCount();           
        }

        [Given(@"I select some providers")]
        public void GivenISelectSomeProviders()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver)
            .SelectProviders();
            Thread.Sleep(5000);
        }  

        [Given(@"I select a provider and continue to placement information page")]
        public void GivenISelectSomeProvidersAndClickContinue()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.SelectProviders().ClickContinue();   
            Thread.Sleep(5000);

        }

        [When(@"I press the Continue button")]
        public void WhenIPressTheContinueButton()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickContinue();
            
        }

        [Given(@"I clear the postcode field on the Select providers page")]
        public void GivenIClearThePostcodeFieldOnTheSelectProvidersPage()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClearPostcode();
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
        }

        [Given(@"I enter an invalid postcode on the Select providers page")]
        public void GivenIEnterAnInvalidPostcodeOnTheSelectProvidersPage()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.EnterPostcode("B98");
        }

        [Then(@"I am shown an error for invalid postcode stating ""(.*)""")]
        public void ThenIAmShownAnErrorForInvalidPostcodeStating(string expectedErrorMessage)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyInvalidPostcodeError(expectedErrorMessage); 
        }
    }
}
