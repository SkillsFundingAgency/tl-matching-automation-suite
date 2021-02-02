using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ShowAllProviderResultsSteps : BaseTest
    {
        [When(@"I navigate to show all Providers page which returns many results")]
        public void WhenINavigateToShowAllProvidersPageWhichReturnsManyResults()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ShowAllProviders().EnterPostCodeAndSearch(Constants.postCode);
        }

        [Then(@"I should see provider results in all routes")]
        public void ThenIShouldSeeProviderResultsInAllRoutes()
        {
            ProviderResultsHelper.AllProviders_AllSkillAreas();
            int providerResultsReturned = ScenarioContext.Current.Get<int>("SearchResultsCount");
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver);
            providerResultsOnlyPage.VerifyProviderResultsReturnedAreCorrect(providerResultsReturned);
        }

        [When(@"I Filter Provider results for One route")]
        public void WhenIFilterProviderResultsForOneRoute()
        {
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver)
                .SelectRouteAndFilterResults("Agriculture, environmental and animal care");
        }

        [When(@"I Filter Provider results for One more route")]
        public void WhenIFilterProviderResultsForOneMoreRoute()
        {
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver)
                .SelectRouteAndFilterResults("Business and administration");
        }

        [Then(@"I should see provider results displayed only for One route")]
        public void ThenIShouldSeeProviderResultsDisplayedOnlyForOneRoute()
        {
            ProviderResultsHelper.AllProviders_OneSkillArea();
            int providerResultsReturned = ScenarioContext.Current.Get<int>("SearchResultsCount");
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver);
            providerResultsOnlyPage.VerifyProviderResultsReturnedAreCorrect(providerResultsReturned);
        }        

        [Then(@"the Select Providers page will display the count and result in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountAndResultInTheHHeading(int p0)
        {
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver);
            providerResultsOnlyPage.VerifysHeadingShowsResults();
        }

        [Then(@"the Select Providers page will display the count, result and route in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountResultAndRouteInTheHHeading(int p0)
        {
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver);
            providerResultsOnlyPage.VerifysHeadingShowsResultsFor();
            providerResultsOnlyPage.VerifySkillsetDisplayed(Constants.skillAreaFilter1);
        }

        [Then(@"the Select Providers page will display the count, result and routes in the H(.*) heading")]
        public void ThenTheSelectProvidersPageWillDisplayTheCountResultAndRoutesInTheHHeading(int p0)
        {
            ProviderResultsHelper.AllProviders_TwoSkillArea();
            int providerResultsReturned = ScenarioContext.Current.Get<int>("SearchResultsCount");
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver);
            providerResultsOnlyPage.VerifyProviderResultsReturnedAreCorrect(providerResultsReturned);
            providerResultsOnlyPage.VerifysHeadingShowsResultsFor();
            providerResultsOnlyPage.VerifySkillsetDisplayed(Constants.skillAreaFilter1 + " and " + Constants.skillAreaFilter2);
        }

        [When(@"I navigate to Provider results page with no results")]
        public void WhenINavigateToProviderResultsPageWithNoResults()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ShowAllProviders().EnterPostCodeAndSearch(Constants.postcodeNoResults);
        }

        [Then(@"the Providers page will display zero results for the H(.*) heading")]
        public void ThenTheProvidersPageWillDisplayZeroResultsForTheHHeading(int p0)
        {
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver);
            providerResultsOnlyPage.VerifyZeroResultsCount();
            providerResultsOnlyPage.VerifysHeadingShowsResultsForZeroResults();
        }

        [When(@"I navigate to Provider results page with only one result")]
        public void WhenINavigateToProviderResultsPageWithOnlyOneResult()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ShowAllProviders().EnterPostCodeAndSearch(Constants.oneResultpostCode)
                .SelectRouteAndFilterResults(Constants.oneResultskillArea);
        }

        [Then(@"the Providers page will display the count and text result in the H(.*) heading")]
        public void ThenTheProvidersPageWillDisplayTheCountAndTextResultInTheHHeading(int p0)
        {
            ProviderResultsOnlyPage providerResultsOnlyPage = new ProviderResultsOnlyPage(webDriver);
            providerResultsOnlyPage.VerifyOneResultCount();
            providerResultsOnlyPage.VerifysHeadingShowsResultFor();
            providerResultsOnlyPage.VerifySkillsetDisplayed(Constants.oneResultskillArea);
        }
    }
}
