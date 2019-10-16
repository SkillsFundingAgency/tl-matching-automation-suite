using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class PlacementInformationPage : BasePage
    {
        //Page element locators
        private String expectedPageURL = "https://test.industryplacementmatching.education.gov.uk/placement-information/";
        private static String PAGE_TITLE = "Placement information";
        private By NoSuitableStudentCheckBox = By.Id("NoSuitableStudent");
        private By HadBadExperience = By.Id("HadBadExperience");
        private By ProvidersTooFarAway = By.Id("ProvidersTooFarAway");
        private By JobTypeField = By.Name("JobRole");
        private By YesRadioButton = By.Id("placement-location-yes");
        private By PlacementsField = By.Id("Placements");
        private By NoRadioButton = By.Id("placement-location-no");
        private By ContinueButton = By.ClassName("govuk-button");

        //Error message locators
        private By ActualErrorForNoProvidersChosen = By.LinkText("You must tell us why the employer did not choose a provider");
        private By ActualPlacementRadioButtonNotSelected = By.LinkText("You must tell us whether the employer knows how many placements they want at this location");
        private By ActualPlacementNumberNullError = By.LinkText("You must estimate how many students the employer wants for this job at this location");
        private By ActualPlacementsNumberTooSmallError = By.LinkText("The number of students must be 1 or more");
        private By ActualPlacementsNumberTooBigError = By.LinkText("The number of students must be 999 or less");
        private By ActualJobTypeTooShortError = By.LinkText("You must enter a job role using 2 or more characters");
        //Check and delete comment
        //You must enter a job role using 99 characters or less
        private By ActualJobTypeTooLongError = By.LinkText("You must enter a job role that is 100 characters or fewer");
        private By ActualJobTypeNullError = By.LinkText("You must tell us what specific job the placement student would do");                

        public PlacementInformationPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        /*public PlacementInformationPage VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, expectedPageURL);
            return this;
        }     */        

        //Actions
        private void SelectReasonsForNoProviderChosen()
        {
            FormCompletionHelper.ClickElement(NoSuitableStudentCheckBox);
            FormCompletionHelper.ClickElement(HadBadExperience);
            FormCompletionHelper.ClickElement(ProvidersTooFarAway);
        }

        private void EnterJobRole(String jobtype)
        {
            FormCompletionHelper.EnterText(JobTypeField, jobtype);
            ScenarioContext.Current["_provisionGapJobType"] = jobtype;
        }

        private void SelectYesRadioButton()
        {
           FormCompletionHelper.ClickElement(YesRadioButton);
            ScenarioContext.Current["_provisionGapplacementsKnown"] = "True";
            
        }

        private void EnterNumberOfStudents()
        {
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = Constants.noOfPlacementsRequired;
            ScenarioContext.Current["_provisionGapNumberofPlacementsDisplayed"] = Constants.noOfPlacementsRequired;
            FormCompletionHelper.EnterText(PlacementsField, Constants.noOfPlacementsRequired);
           
        }        

        private void EnterInvalidNumberOfStudents(string invalidNumberOfStudents)
        {
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = invalidNumberOfStudents;
            FormCompletionHelper.EnterText(PlacementsField, invalidNumberOfStudents);
        }

        private void SelectNoRadioButton()
        {
            FormCompletionHelper.ClickElement(NoRadioButton);
            ScenarioContext.Current["_provisionGapplacementsKnown"] = "False";
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = "1";
            ScenarioContext.Current["_provisionGapNumberofPlacementsDisplayed"] = "At least 1";
        }        

        private void ClickContinueButton()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
        }               

        //Behaviour
        internal WhoIsTheEmployerPage EnterMandatoryPlacementInformationForNoSuitableProvidersAndContinue(string studentsWanted)
        {
            SelectReasonsForNoProviderChosen();            
            if (studentsWanted == "Yes")
            {
                SelectYesRadioButton();
                EnterNumberOfStudents();
            }
            else
            {
                SelectNoRadioButton();
                ScenarioContext.Current["_provisionGapJobType"] = "None given";
            }
            ClickContinueButton();            
            return new WhoIsTheEmployerPage(webDriver);
        }

        internal WhoIsTheEmployerPage EnterMandatoryPlacementInformationForChosenProvidersAndContinue(string studentsWanted)    //SelectYesContinue    //ClickContinue(No)
        {
            if (studentsWanted == "Yes")
            {
                SelectYesRadioButton();
                EnterNumberOfStudents();
                
            }
            else
            {
                SelectNoRadioButton();
                ScenarioContext.Current["_provisionGapJobType"] = "None given";
            }
            ClickContinueButton();
            return new WhoIsTheEmployerPage(webDriver);
        }

        internal WhoIsTheEmployerPage EnterMandatoryPlacementInformationForNoProvidersAndContinue(string studentsWanted)    //SelectYesContinue    //ClickContinue(No)
        {
            if (studentsWanted == "Yes")
            {
                SelectYesRadioButton();
                EnterNumberOfStudents();
            }
            else
            {
                SelectNoRadioButton();
                ScenarioContext.Current["_provisionGapJobType"] = "None given";
            }
            ClickContinueButton();
            return new WhoIsTheEmployerPage(webDriver);
        }

        internal PlacementInformationPage EnterNoPlacementInformationAndContinue()    //SelectYesContinue    //ClickContinue(No)
        {            
            ClickContinueButton();
            return this;
        }


        internal PlacementInformationPage EnterValidJobRole(string JobRole)
        {
            EnterJobRole(JobRole);
            ScenarioContext.Current["_provisionGapJobType"] = Constants.jobTitle;
            return this;
        }

        internal PlacementInformationPage EnterInvalidJobRoleAndContinue(string invalidJobRole)
        {
            EnterJobRole(invalidJobRole);
            ClickContinueButton();
            return this;
        }

        internal PlacementInformationPage EnterInvalidNumberOfStudentsAndContinue(string p0)
        {
            SelectYesRadioButton();
            EnterInvalidNumberOfStudents(p0);
            ClickContinueButton();
            return this;
        }
                
        internal void SelectRadioButtonToVerifyNumberOfStudentsFieldDisplay(string studentsWanted)
        {
            if (studentsWanted == "Yes")
            {
                SelectYesRadioButton();
                EnterNumberOfStudents();
            }
            else
            {
                SelectNoRadioButton();
                ScenarioContext.Current["_provisionGapJobType"] = "None given";
            }
        }

        public ReferralCheckAnswersPage EnterPlacementInformationClickContinueMoreThanOneOpportunityExists()
        {
            FormCompletionHelper.EnterText(JobTypeField, Constants.jobTitle);
            SelectNoRadioButton();
            ScenarioContext.Current["_provisionGapJobType"] = "None given";
            FormCompletionHelper.ClickElement(ContinueButton);
            return new ReferralCheckAnswersPage(webDriver);
        }

        //Assertions        
        public bool VerifyNumberOfPLacementsIsVisibile()
        {
            return PageInteractionHelper.IsElementDisplayed(PlacementsField);
        }
        //    bool Displayed = PageInteractionHelper.IsElementDisplayed(PlacementsField);
        //    Console.WriteLine(Displayed);

        //    if (Displayed == false)
        //    {
        //        throw new Exception("Element verification failed: "
        //       + "\n Expected element to be visible: " );              
        //    }
        //}

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

        public void VerifyErrorForNoProvidersChosen(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualErrorForNoProvidersChosen, expectedError);
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

        public bool VerifyErrorJobRoleTooShort(string expectedError)
        {
            return FormCompletionHelper.VerifyText(ActualJobTypeTooShortError, expectedError);            
        }
    }
}
