using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class StartPage : BasePage
    {
        private static String PAGE_TITLE = "Match employers with providers for industry placements";
        private By UserName = By.Id("username");
        private By Password = By.Id("password");
        private By StartNowButton = By.Id("tl-start-now");
        private By LogoffButton = By.LinkText("Sign out");
        private By UploadLink = By.Id("tl-upload-link");
        String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/Start";

        public StartPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public void VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, ExpectedPageURL);
        }

        public FindLocalProvidersPage ClickStartButton()
        {
           FormCompletionHelper.ClickElement(StartNowButton);
            return new FindLocalProvidersPage(webDriver);
        }

        public void ClickUploadLink()
        {
            FormCompletionHelper.ClickElement(UploadLink);
        }

        public void Logoff()
        {
            FormCompletionHelper.ClickElement(LogoffButton);
        }

        public void VerifyLinkPresent(String expectedLinkText)
        {
            PageInteractionHelper.VerifyLinkIsPresent(UploadLink, expectedLinkText);
        }

        public Boolean VerifyElementNotPresent()
        {
            Boolean Displayed = PageInteractionHelper.IsElementPresent(UploadLink);
            Console.WriteLine(Displayed);
            return Displayed;
        }
    }
}
