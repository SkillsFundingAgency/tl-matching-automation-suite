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
        private By StartANewOpportunityLink = By.PartialLinkText("Create and refer new opportunities");
        private By ShowAllProvidersLink = By.PartialLinkText("Show all providers in an area");
        private By ViewSavedOpportunitiesLink = By.PartialLinkText("View saved opportunities");
        private By ManageProviderDataLink = By.Id("tl-dash-manageprovider");
        private By EditQualificationsLink = By.Id("tl-dash-editquals");
        private By UploadLink = By.Id("tl-dash-uploaddata");
        private By TakeServiceOfflineLink = By.Id("tl-dash-takeoffline");
        private By PutServiceBackOnlineLink = By.Id("tl-dash-takeoffline");
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

        //Actions
        private void ClickCreateNewOpportunityLink()
        {
            FormCompletionHelper.ClickElement(StartANewOpportunityLink);
        }

        private void ClickShowAllProvidersLink()
        {
            FormCompletionHelper.ClickElement(ShowAllProvidersLink);
        }

        private void ClickViewSavedOpportunitiesLink()
        {
            FormCompletionHelper.ClickElement(ViewSavedOpportunitiesLink);
        }

        private void ClickManageProviderDataLink()
        {
            FormCompletionHelper.ClickElement(ManageProviderDataLink);
        }

        private void ClickEditQualificationsLink()
        {
            FormCompletionHelper.ClickElement(EditQualificationsLink);
        }

        private void ClickUploadLink()
        {
            FormCompletionHelper.ClickElement(UploadLink);
        }

        private void ClickTakeServiceOfflineLink()
        {
            FormCompletionHelper.ClickElement(TakeServiceOfflineLink);
        }

        private void ClickPutServiceBackOnlineLink()
        {
            FormCompletionHelper.ClickElement(PutServiceBackOnlineLink);
        }

        private void SignOut()
        {
            FormCompletionHelper.ClickElement(SignOutLink);
        }

        //Behaviour        
        public FindLocalProvidersPage StartANewOpportunity()
        {
            ClickCreateNewOpportunityLink();
            return new FindLocalProvidersPage(webDriver);
        }
                
        public WhereIsTheEmployerPage ShowAllProviders()
        {
            ClickShowAllProvidersLink();
            return new WhereIsTheEmployerPage(webDriver);
        }

        /*public  ViewSavedOpportunities()
        {
            ClickViewSavedOpportunitiesLink();
            return new FindLocalProvidersPage(webDriver);
        }*/

        public FindAProviderPage StartAddingProviderData()
        {
            ClickManageProviderDataLink();
            return new FindAProviderPage(webDriver);
        }

        /*public  EditQualifications()
        {
            ClickEditQualificationsLink();
            return new FindLocalProvidersPage(webDriver);
        }*/

        public FileUploadPage StartUploadingEmployerOrProviderData()
        {
            ClickUploadLink();
            return new FileUploadPage(webDriver);
        }

        /*public  TakeServiceOffline()
        {
            ClickTakeServiceOfflineLink();
            return new FindLocalProvidersPage(webDriver);
        }

        public  PutServiceBackOnline()
        {
            ClickPutServiceBackOnlineLink();
            return new FindLocalProvidersPage(webDriver);
        }
        */       

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
