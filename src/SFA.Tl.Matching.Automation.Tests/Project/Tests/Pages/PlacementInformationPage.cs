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
        private By ActualJobTypeTooLongError = By.LinkText("You must enter a job role using 99 characters or less");
        private By ActualJobTypeNullError = By.LinkText("You must tell us what specific job the placement student would do");        
        private String expectedPageURL = "https://test.industryplacementmatching.education.gov.uk/placement-information/";

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
        private void SelectReasonsForNoProviderChosen()  //PlacementInformationPage
        {
            FormCompletionHelper.ClickElement(NoSuitableStudentCheckBox);
            FormCompletionHelper.ClickElement(HadBadExperience);
            FormCompletionHelper.ClickElement(ProvidersTooFarAway);
            //return this;
        }

        private void EnterJobRole(String jobtype)   //PlacementInformationPage
        {
            FormCompletionHelper.EnterText(JobTypeField, jobtype);
            ScenarioContext.Current["_provisionGapJobType"] = jobtype;
            //return new PlacementInformationPage(webDriver);
        }

        private void SelectYesRadioButton()  //PlacementInformationPage
        {
           FormCompletionHelper.ClickElement(YesRadioButton);
           //return this;
        }

        private void EnterNumberOfStudents()   //PlacementInformationPage
        {
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = Constants.NoofPlacementEntered;
            FormCompletionHelper.EnterText(PlacementsField, Constants.NoofPlacementEntered);           
            //return this;
        }

        private void EnterInvalidNumberOfStudents(string invalidNumberOfStudents)   //PlacementInformationPage
        {
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = invalidNumberOfStudents;
            FormCompletionHelper.EnterText(PlacementsField, invalidNumberOfStudents);
            //return this;
        }

        private void SelectNoRadioButton()  //PlacementInformationPage
        {
            FormCompletionHelper.ClickElement(NoRadioButton);
            ScenarioContext.Current["_provisionGapNumberofPlacements"] = "at least 1";
            //return this;
        }        

        private void ClickContinueButton()   //WhoIsTheEmployerPage
        {
            FormCompletionHelper.ClickElement(ContinueButton);
            //return new WhoIsTheEmployerPage(webDriver);
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
            }
            ClickContinueButton();
            return new WhoIsTheEmployerPage(webDriver);
        }

        internal PlacementInformationPage EnterNoPlacementInformationAndContinue()    //SelectYesContinue    //ClickContinue(No)
        {            
            ClickContinueButton();
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
            }
        }

        //Assertions        
        public PlacementInformationPage VerifyNumberOfPLacementsIsVisibile()
        {
            bool Displayed = PageInteractionHelper.IsElementDisplayed(PlacementsField);
            Console.WriteLine(Displayed);

            if (Displayed == false)
            {
                throw new Exception("Element verification failed: "
               + "\n Expected element to be visible: " );              
            }

            return this;
        }

        public PlacementInformationPage VerifyNumberOfPLacementsIsNotVisibile()
        {
            bool Displayed = PageInteractionHelper.IsElementDisplayed(PlacementsField);
            Console.WriteLine(Displayed);

            if (Displayed == true)
            {
                throw new Exception("Element verification failed: "
               + "\n Expected element to be visible: ");
            }
            return this;
        }               

        public PlacementInformationPage VerifyErrorForNoProvidersChosen(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualErrorForNoProvidersChosen, expectedError);
            return this;
        }

        public PlacementInformationPage VerifyErrorPlacementNumberTooSmall(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementsNumberTooSmallError, expectedError);
            return this;
        }

        public PlacementInformationPage VerifyErrorPlacementNumberTooBig(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementsNumberTooBigError, expectedError);
            return this;
        }

        public PlacementInformationPage VerifyErrorPlacementNumberIsNull(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementNumberNullError, expectedError);
            return this;
        }
        
        public PlacementInformationPage VerifyErrorNoJobPlacementEntered(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualJobTypeNullError, expectedError);
            return this;
        }

        public PlacementInformationPage VerifyErrorNoPlacementsSelected(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementNumberNullError, expectedError);
            return this;
        }

        public PlacementInformationPage VerifyError_PlacementRadioButtonNotSelected(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualPlacementRadioButtonNotSelected, expectedError);
            return this;
        }

        public PlacementInformationPage VerifyErrorJobRoleTooLong(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualJobTypeTooLongError, expectedError);
            return this;
        }

        public PlacementInformationPage VerifyErrorJobRoleTooShort(string expectedError)
        {
            FormCompletionHelper.VerifyText(ActualJobTypeTooShortError, expectedError);
            return this;
        }
    }
}
