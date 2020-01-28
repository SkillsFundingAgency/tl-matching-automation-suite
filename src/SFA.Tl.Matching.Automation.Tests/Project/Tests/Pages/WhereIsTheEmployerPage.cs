using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class WhereIsTheEmployerPage : BasePage
    {
        private static String PAGE_TITLE = "Where is the employer?";
        private By PostcodeField = By.Id("Postcode");
        private By SearchButton = By.Id("tl-search");

        //ErrorMessages
        private By ActualPostcodeError = By.LinkText("You must enter a postcode");

        public WhereIsTheEmployerPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        //Actions
        private void EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
            //ScenarioContext.Current["_SearchPostcode"] = postcode;
        }

        private void ClickSearchButton()
        {
            FormCompletionHelper.ClickElement(SearchButton);
        }

        //Behaviour
        public ProviderResultsOnlyPage EnterPostCodeAndSearch(string postCode)
        {
            EnterPostcode(postCode);
            ClickSearchButton();
            return new ProviderResultsOnlyPage(webDriver);
        }

        public WhereIsTheEmployerPage ClearPostcodeAndSearch()
        {
            FormCompletionHelper.ClearText(PostcodeField);
            ClickSearchButton();
            return new WhereIsTheEmployerPage(webDriver);
        }

        //Assertions
        public void VerifyPostcodeError(string expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, expectedErrorMessage);
        }
    }
}
