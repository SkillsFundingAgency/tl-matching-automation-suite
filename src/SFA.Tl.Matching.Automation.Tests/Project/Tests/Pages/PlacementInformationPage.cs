using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class PlacementInformationPage : BasePage
    {
        private static String PAGE_TITLE = "Placement information";
        private By ContinueButton = By.ClassName("govuk-button");
        private By JobTypeField = By.Name("JobTitle");
        private By YesRadioButton = By.Id("placement-location-yes");
        private By NoRadioButton = By.Id("placement-location-no");
        private By PlacementsField = By.Id("Placements");

        //Error message locators
        private By ActualPlacementRadioButtonNotSelected = By.LinkText("You must tell us whether the employer knows how many placements they want at this location");
        private By ActualPlacementNumberNullError = By.LinkText("You must estimate how many placements the employer wants at this location");
        private By ActualPlacementsNumberTooSmallError = By.LinkText("The number of placements must be 1 or more");
        private By ActualPlacementsNumberTooBigError = By.LinkText("The number of placements must be 999 or less");
        private By ActualJobTypeTooShortError = By.LinkText("You must enter a job role using 2 or more characters");
        private By ActualJobTypeTooLongError = By.LinkText("You must enter a job role using 99 characters or less");
        private By ActualJobTypeNullError = By.LinkText("You must tell us what specific job the placement student would do");
        private String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/provider-results";
        private String expectedPageURL = "https://test.industryplacementmatching.education.gov.uk/placement-information/";

        public PlacementInformationPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public PlacementInformationPage VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, expectedPageURL);
            return this;
        }

        public WhoIsTheEmployerPage ClickContinueButton()
        {
           FormCompletionHelper.ClickElement(ContinueButton);
           return new WhoIsTheEmployerPage(webDriver);
        }

        public PlacementInformationPage ClickContinueExpectingErrors()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
            return this;
        }

        public void ClearJobField()
        {
            FormCompletionHelper.ClearText(JobTypeField);
        }

        public void VerifyErrorNoJobPlacementEntered(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualJobTypeNullError, expectedError);
        }

        public void VerifyErrorNoPlacementsSelected(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementNumberNullError, expectedError);
        }

        public void VerifyError_PlacementRadioButtonNotSelected(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementRadioButtonNotSelected, expectedError);
        }

        public void VerifyErrorJobRoleTooLong(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualJobTypeTooLongError, expectedError);
        }

        public void VerifyErrorJobRoleTooShort(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualJobTypeTooShortError, expectedError);
        }
        
        public void AutoPopulateFields()
        {
            FormCompletionHelper.EnterText(JobTypeField, "Mechanic");
            FormCompletionHelper.ClickElement(NoRadioButton);
        }

        public PlacementInformationPage SelectNoRadioButton()
        {
           FormCompletionHelper.ClickElement(NoRadioButton);
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = "at least 1";
            return this;
        }

        public void SelectYesRadioButton()
        {
           FormCompletionHelper.ClickElement(YesRadioButton);       
        }

        public void VerifyNumberOfPLacementsIsVisibile()
        {
            bool Displayed = PageInteractionHelper.IsElementDisplayed(PlacementsField);
            Console.WriteLine(Displayed);

            if (Displayed == false)
            {
                throw new Exception("Element verification failed: "
               + "\n Expected element to be visible: " );              
            }            
        }

        public void VerifyNumberOfPLacementsIsNotVisibile()
        {
            bool Displayed = PageInteractionHelper.IsElementDisplayed(PlacementsField);
            Console.WriteLine(Displayed);

            if (Displayed == true)
            {
                throw new Exception("Element verification failed: "
               + "\n Expected element to be visible: ");
            }
        }

        public PlacementInformationPage EnterJobRole(String jobtype)
        {
            FormCompletionHelper.EnterText(JobTypeField, jobtype);
            ScenarioContext.Current["_provisionGapJobType"] = jobtype;
            return new PlacementInformationPage(webDriver);
        }


        public WhoIsTheEmployerPage SelectYesContinue()
        {
            FormCompletionHelper.EnterText(JobTypeField, Constants.jobTitle);
            FormCompletionHelper.ClickElement(YesRadioButton);
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = Constants.NoofPlacementEntered;
            FormCompletionHelper.EnterText(PlacementsField, Constants.NoofPlacementEntered);
            FormCompletionHelper.ClickElement(ContinueButton);
            return new WhoIsTheEmployerPage(webDriver);
        }

        public WhoIsTheEmployerPage ClickContinue()
        {
            FormCompletionHelper.EnterText(JobTypeField, Constants.jobTitle);
            FormCompletionHelper.ClickElement(NoRadioButton);
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = Constants.NoofPlacements;
            FormCompletionHelper.ClickElement(ContinueButton);
            return new WhoIsTheEmployerPage(webDriver);
        }

        public void EnterNumberOfPlacements(int Number)
        {
            String ConvertNumbertoString = Number.ToString();
            FormCompletionHelper.EnterText(PlacementsField, ConvertNumbertoString);
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = ConvertNumbertoString;
        }

        public void VerifyErrorPlacementNumberTooSmall(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementsNumberTooSmallError, expectedError);
        }

        public void VerifyErrorPlacementNumberTooBig(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementsNumberTooBigError, expectedError);
        }

        public void VerifyErrorPlacementNumberIsNull(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementNumberNullError, expectedError);
        }
    }
}
