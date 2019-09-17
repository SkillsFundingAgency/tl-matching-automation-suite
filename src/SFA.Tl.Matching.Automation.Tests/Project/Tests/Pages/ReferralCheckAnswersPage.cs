using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class ReferralCheckAnswersPage : BasePage
    {
        private static String PAGE_TITLE = ("Check answers");
        private By PageHeading = By.XPath("//*[@id='main-content']/div/div/h1");
        private By ConfirmAndSendButton = By.ClassName("govuk-button");
        private By ConfirmationSelected = By.Name("ConfirmationSelected");
        private By TypeOfPlacement = By.XPath("//tr[1]/td[1]");
        private By Postcode = By.XPath("//tr[2]/td[1]");
        private By Radius = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[3]/td");
        private By JobRole = By.XPath("//tr[3]/td[1]");
        private By NumberOfPlacements = By.XPath("//tr[4]/td[1]");
        //private By provider1Name = By.XPath("//*[@id='main-content']/div/div/p[1]");
        private By provider1Name = By.XPath("//table[2]//tr[1]/th"); //updated for new changes
        //private By provider2Name = By.XPath("//table[2]//tr[2]/th");

        //Variables to store values from the database
        private String actualPostcode;
        private String actualSearchRadius;
        private String actualJobtitle;
        private int actualPlacementsKnown;
        private String actualNoOfPlacements;
        private String actualEmployername;
        private String actualSkillArea;
        private int OpportunityId;

        // Variables to store values entered in the journey web page
        // private String expectedPostcode = (string)ScenarioContext.Current["_provisionGapPostcode"];
        // private String expectedSearchRadius = (string)ScenarioContext.Current["_provisionGapPostcodeRadius"];
        // private String expectedJobType = (string)ScenarioContext.Current["_provisionGapJobType"];
        // private String expectedNoOfPlacementsKnown = (string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
        // private String expectedTypeOfPlacement = (string)ScenarioContext.Current["_provisionGapTypeOfPlacement"];
        // private String expectedEmployername = (string)ScenarioContext.Current["_provisionGapEmployerName"];

        // Variables to store values entered in the journey web page
        private String expectedPostcode = Constants.postCode;
        private String expectedSearchRadius = Constants.radius;
        private String expectedJobType = Constants.jobTitle;
        private String expectedNoOfPlacementsKnown = Constants.NoofPlacements; //(string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
        private String expectedTypeOfPlacement = Constants.skillArea;
        private String expectedEmployername = Constants.employerName;

        public ReferralCheckAnswersPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        //Actions
        private void ClickConfirmAndSendButton()
        {
            FormCompletionHelper.ClickElement(ConfirmAndSendButton);
        }

        //Behaviour
        internal OpportunitiesBasketReferralPage ConfirmAndSendOpportunity()
        {
            ClickConfirmAndSendButton();
            return new OpportunitiesBasketReferralPage(webDriver);
        }

        //Assertions
        //check and remove this method

        /*public ReferralCheckAnswersPage VerifyPageHeader()
        {
            String expectedPageTitle = "Check answers";
            String actualPageTitle = PageInteractionHelper.GetText(PageHeading);
            PageInteractionHelper.VerifyPageHeading(actualPageTitle, expectedPageTitle);
            return new ReferralCheckAnswersPage(webDriver);
        } */      

        public void CheckPlacementInformationFirstPass()
        {
            PageInteractionHelper.VerifyText(TypeOfPlacement, Constants.skillArea);
            PageInteractionHelper.VerifyText(Postcode, Constants.postCode);
            PageInteractionHelper.VerifyText(JobRole, "None given");
            PageInteractionHelper.VerifyText(NumberOfPlacements, Constants.NoofPlacementEntered);
        }

        public void VerifyEmployersAnswers()
        {
            String query = ("Select oi.Postcode, oi.SearchRadius, oi.JobRole, oi.PlacementsKnown, oi.Placements, e.CompanyName from opportunity o, OpportunityItem OI, employer e where o.id = oi.OpportunityId and o.EmployerId = e.Id and o.ID in (select max(id) from opportunity)");
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());

            foreach (object[] fieldNo in queryResults)
            {
                //Assign values to variables from the SQL query run
                actualPostcode = fieldNo[0].ToString();
                actualSearchRadius = (fieldNo[1].ToString() + " miles");
                actualJobtitle = fieldNo[2].ToString();
                actualPlacementsKnown = Convert.ToInt32(fieldNo[3]);
                actualNoOfPlacements = fieldNo[4].ToString();
                actualEmployername = fieldNo[5].ToString();
                //actualSkillArea = fieldNo[6].ToString();
                //OpportunityId = Convert.ToInt32(fieldNo[7]);
                //ScenarioContext.Current["_provisionGapOpportunityID"] = OpportunityId;

                Console.WriteLine("ActualNoOfPlacements: " + actualNoOfPlacements + "ExpectedNoOfPlacements: " + expectedNoOfPlacementsKnown);
                Console.WriteLine("ActualPostcode: " + actualPostcode + "ExpectedPostcode: " + expectedPostcode);
                Console.WriteLine("ActualSearchRadius: " + actualSearchRadius + "ExpectedSearchRadius: " + expectedSearchRadius);
                Console.WriteLine("ActualJobTitle: " + actualJobtitle + "ExpectedJobTitle: " + expectedJobType);
                Console.WriteLine("ActualSkillArea: " + actualSkillArea + "ExpectedSkillArea: " + expectedTypeOfPlacement);
                Console.WriteLine("ActualEmployerName: " + actualEmployername + "ExpectedEmployerName: " + expectedEmployername);
                Console.WriteLine("ActualPLACEMENTS: " + actualPlacementsKnown);

                //Assert the variables above to the actual values displayed on the screen
                //PageInteractionHelper.VerifyText(actualSkillArea, expectedTypeOfPlacement);
                //PageInteractionHelper.VerifyText(actualPostcode, expectedPostcode);
                //PageInteractionHelper.VerifyText(actualSearchRadius, expectedSearchRadius);
                //PageInteractionHelper.VerifyText(actualJobtitle, expectedJobType);
                //PageInteractionHelper.VerifyText(actualNoOfPlacements, actualNoOfPlacements);
            }
        }

        public void VerifyChosenProvidersAreDisplayedOnCheckAnswersScreen()
        {
            String provider1 = (string)ScenarioContext.Current["_Provider1"];
            //String provider2 = (string)ScenarioContext.Current["_Provider2"];
            ProviderResultsHelper.VerifyProviderDisplayed(provider1, provider1Name);
            Console.WriteLine(provider1 + " Verified");
            //PageInteractionHelper.VerifyProviderDisplayed(provider2, provider2Name);
            //Console.WriteLine(provider2 + "Verified");
        }

      

    }
}
