using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;


namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class ProviderResultsOnlyPage : BasePage
    {
        private static String PAGE_TITLE = "Providers within 30 miles of";
        private By ProviderResultsCount = By.Id("tl-search-count");
        private By Filter_AgricultureRoute = By.Id("Filters_0__IsSelected");
        private By Filter_BusinessRoute = By.Id("Filters_1__IsSelected");
        private By Filter_CateringRoute = By.Id("Filters_2__IsSelected");
        private By Filter_ConstructionRoute = By.Id("Filters_3__IsSelected");
        private By Filter_CreativeRoute = By.Id("Filters_4__IsSelected");
        private By Filter_DigitalRoute = By.Id("Filters_5__IsSelected");
        private By Filter_EducationRoute = By.Id("Filters_6__IsSelected");
        private By Filter_EngineeringRoute = By.Id("Filters_7__IsSelected");
        private By Filter_HairAndBeautyRoute = By.Id("Filters_8__IsSelected");
        private By Filter_HealthRoute = By.Id("Filters_9__IsSelected");
        private By Filter_LegalRoute = By.Id("Filters_10__IsSelected");
        private By FilterResultsButton = By.Id("tl-filter");
        
        private By ActualResultHeadingDisplayed = By.XPath("//*[@id='main-content']/div/div[2]/p[1]");
        private By ActualResultHeadingDisplayedForZeroResults = By.XPath("//*[@id='main-content']/div/div/p[1]");

        public ProviderResultsOnlyPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        //Actions
        private void SelectRoute(string route)
        {
            switch(route)
            {
                case "Agriculture, environmental and animal care":
                    FormCompletionHelper.ClickElement(Filter_AgricultureRoute);
                    break;
                case "Business and administration":
                    FormCompletionHelper.ClickElement(Filter_BusinessRoute);
                    break;
                case "Catering and hospitality":
                    FormCompletionHelper.ClickElement(Filter_CateringRoute);
                    break;
                case "Construction":
                    FormCompletionHelper.ClickElement(Filter_ConstructionRoute);
                    break;
                case "Creative and design":
                    FormCompletionHelper.ClickElement(Filter_CreativeRoute);
                    break;
                case "Digital":
                    FormCompletionHelper.ClickElement(Filter_DigitalRoute);
                    break;
                case "Education and childcare":
                    FormCompletionHelper.ClickElement(Filter_EducationRoute);
                    break;
                case "Engineering and manufacturing":
                    FormCompletionHelper.ClickElement(Filter_EngineeringRoute);
                    break;
                case "Hair and beauty":
                    FormCompletionHelper.ClickElement(Filter_HairAndBeautyRoute);
                    break;
                case "Health and science":
                    FormCompletionHelper.ClickElement(Filter_HealthRoute);
                    break;
                case "Legal, financial and accounting":
                    FormCompletionHelper.ClickElement(Filter_LegalRoute);
                    break;
            }
        }

        private void ClickOnFilterResults()
        {
            FormCompletionHelper.ClickElement(FilterResultsButton);
        }

        //Behaviour
        public ProviderResultsOnlyPage SelectRouteAndFilterResults(string skillArea)
        {
            SelectRoute(skillArea);
            ClickOnFilterResults();
            return new ProviderResultsOnlyPage(webDriver);
        }

        //Assertions
        public void VerifyProviderResultsReturnedAreCorrect(int res)
        {
            PageInteractionHelper.VerifyText(ProviderResultsCount, res);
        }

        public void VerifyZeroResultsCount()
        {
            int expResultsCount = 0;
            PageInteractionHelper.VerifyText(ProviderResultsCount, expResultsCount);
        }

        public void VerifyOneResultCount()
        {
            int expResultsCount = 1;
            PageInteractionHelper.VerifyText(ProviderResultsCount, expResultsCount);
        }       

        public void VerifysHeadingShowsResultsForZeroResults()
        {
            String ExpectedResultsHeading = "results";
            String ActualResultHeading = webDriver.FindElement(ActualResultHeadingDisplayedForZeroResults).Text;
            PageInteractionHelper.VerifyText(ActualResultHeading, ExpectedResultsHeading);
        }

        public void VerifysHeadingShowsResults()
        {
            String ExpectedResultsHeading = "results";
            String ActualResultHeading = webDriver.FindElement(ActualResultHeadingDisplayed).Text;
            PageInteractionHelper.VerifyText(ActualResultHeading, ExpectedResultsHeading);
        }

        public void VerifysHeadingShowsResultFor()
        {
            String ExpectedResultsHeading = "result for";
            String ActualResultHeading = webDriver.FindElement(ActualResultHeadingDisplayed).Text;
            PageInteractionHelper.VerifyText(ActualResultHeading, ExpectedResultsHeading);
        }

        public void VerifysHeadingShowsResultsFor()
        {
            String ExpectedResultsHeading = "results for";
            String ActualResultHeading = webDriver.FindElement(ActualResultHeadingDisplayed).Text;
            PageInteractionHelper.VerifyText(ActualResultHeading, ExpectedResultsHeading);
        }       

        public void VerifySkillsetDisplayed(String expectedJobType)
        {
            String ActualSkillsetDisplayed = webDriver.FindElement(ActualResultHeadingDisplayed).Text;
            FormCompletionHelper.VerifyText(ActualSkillsetDisplayed, expectedJobType);
        }        
    }
}
