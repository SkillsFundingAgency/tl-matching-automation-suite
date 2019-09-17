using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class StartPage : BasePage
    {
        String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/Start";
        private static String PAGE_TITLE = "Match employers with providers for industry placements";
        private By StartANewOpportunityButton = By.Id("tl-start-now");        
        private By UploadLink = By.Id("tl-upload-link");
        private By AddOrEditProviderDataLink = By.Id("tl-Add-edit-provider-link");
        private By SignOutLink = By.LinkText("Sign out");

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

        private void ClickUploadLink()
        {
            FormCompletionHelper.ClickElement(UploadLink);
        }        

        private void ClickAddOrEditProviderDataLink()
        {
            FormCompletionHelper.ClickElement(AddOrEditProviderDataLink);
        }

        private void SignOut()
        {
            FormCompletionHelper.ClickElement(SignOutLink);
        }

        //Behaviour        
        public FindLocalProvidersPage StartANewOpportunity()
        {
            FormCompletionHelper.ClickElement(StartANewOpportunityButton);
            return new FindLocalProvidersPage(webDriver);
        }

        public FileUploadPage StartUploadingEmployerOrProviderData()
        {
            ClickUploadLink();
            return new FileUploadPage(webDriver);
        }

        public FindAProviderPage StartAddingProviderData()
        {
            ClickAddOrEditProviderDataLink();
            return new FindAProviderPage(webDriver);
        }        

        //Assertions
        public void VerifyLinkPresent(String expectedLinkText)
        {
            PageInteractionHelper.VerifyLinkIsPresent(UploadLink, expectedLinkText);
        }

        public Boolean VerifyElementNotPresent()
        {
            Boolean Displayed = PageInteractionHelper.IsElementPresent(UploadLink);
            Console.WriteLine(Displayed);
            Assert.False(Displayed);
            return Displayed;
        }
    }
}
