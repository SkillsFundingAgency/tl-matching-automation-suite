using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class AddQualificationPage : BasePage
    {
        private static String PAGE_TITLE = "Add a qualification for B43 6JN";
        private By LarIdSearchField = By.Id("LarId");
        private By ContinueButton = By.ClassName("govuk-button");
        private By ShortTitleTextField = By.Id("ShortTitle");
        private By SkillAreaCheckBox = By.Id("Routes_1__IsSelected");
        private By AddqualificationButton = By.ClassName("govuk-button");

        public AddQualificationPage(IWebDriver webDriver) : base(webDriver)
        {
            if (ScenarioContext.Current.TryGetValue<string>("PostCodeTextFromVenuesTable", out string x))
            {
                PAGE_TITLE = "Add a qualification for " + x;
            }
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public void SearchForLarId(String LarId)
        {
            FormCompletionHelper.EnterText(LarIdSearchField, LarId);
            FormCompletionHelper.ClickElement(ContinueButton);
        }

        public void AutoPopulateFields()
        {
            FormCompletionHelper.EnterText(ShortTitleTextField, "business administration");
            Thread.Sleep(6000);
            FormCompletionHelper.ClickElement(SkillAreaCheckBox);
        }

        public void ClickAddQualification()
        {
            FormCompletionHelper.ClickElement(AddqualificationButton);
        }
    }
}