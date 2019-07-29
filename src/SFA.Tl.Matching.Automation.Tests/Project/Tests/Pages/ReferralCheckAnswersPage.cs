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
    public class ReferralCheckAnswersPage : BasePage
    {
        private static String PAGE_TITLE = (" ");
        private By PageHeading = By.XPath("//*[@id='main-content']/div/div/h1");
        private By ConfirmAndSendButton = By.ClassName("govuk-button");
        private By ConfirmationSelected = By.Name("ConfirmationSelected");
        private By TypeOfPlacement = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[1]/td");
        private By Postcode = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[2]/td");
        private By Radius = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[3]/td");
        private By JobRole = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[4]/td");
        private By NumberOfPlacements = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[5]/td");
        private By provider1Name = By.XPath("//*[@id='main-content']/div/div/p[1]");
       // private By provider2Name = By.XPath("//*[@id='main-content']/div/div/p[3]");

        //Variables to store values from the database
        private String actualPostcode;
        private String actualSearchRadius;
        private String actualJobtitle;
        private int actualPlacementsKnown;
        private String actualNoOfPlacements;
        private String actualEmployername;
        private String actualSkillArea;
        private int OpportunityId;

        //Variables to store values entered in the journey web page
 //private String expectedPostcode = (string)ScenarioContext.Current["_provisionGapPostcode"];
// private String expectedSearchRadius = (string)ScenarioContext.Current["_provisionGapPostcodeRadius"];
//private String expectedJobType = (string)ScenarioContext.Current["_provisionGapJobType"];
 //       private String expectedNoOfPlacementsKnown = (string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
   //     private String expectedTypeOfPlacement = (string)ScenarioContext.Current["_provisionGapTypeOfPlacement"];
    //    private String expectedEmployername = (string)ScenarioContext.Current["_provisionGapEmployerName"];

        //Variables to store values entered in the journey web page
        private String expectedPostcode = Constants.postCode;
        private String expectedSearchRadius = Constants.radius;
        private String expectedJobType = Constants.jobTitle;
        private String expectedNoOfPlacementsKnown = Constants.NoofPlacements; //(string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
        private String expectedTypeOfPlacement = Constants.skillArea;
        private String expectedEmployername = Constants.employerName;

        public ReferralCheckAnswersPage(IWebDriver webDriver) : base(webDriver)
        {
          // SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }       

        public ReferralDonePage ClickConfirmAndSendutton()
        {
           FormCompletionHelper.ClickElement(ConfirmAndSendButton);

            return new ReferralDonePage(webDriver);
        }

        public ReferralCheckAnswersPage ClickConfirmationCheckBox()
        {
            FormCompletionHelper.ClickElement(ConfirmationSelected);
            return new ReferralCheckAnswersPage(webDriver);

        }

        public ReferralCheckAnswersPage VerifyPageHeader()
        {
            //String expectedPageTitle = "Check " + expectedEmployername + "'s answers";
            String expectedPageTitle = "Check answers";
            String actualPageTitle = PageInteractionHelper.GetText(PageHeading);

            PageInteractionHelper.VerifyPageHeading(actualPageTitle, expectedPageTitle);
            return new ReferralCheckAnswersPage(webDriver);
        }

        public ReferralCheckAnswersPage VerifyProvidersAreDisplayed()
        {
           String provider1 = (string)ScenarioContext.Current["_Provider1"];
          // String provider2 = (string)ScenarioContext.Current["_Provider2"];
           ProviderResultsHelper.VerifyProviderDisplayed(provider1, provider1Name);
           Console.WriteLine(provider1 + "Verified");
           //PageInteractionHelper.VerifyProviderDisplayed(provider2, provider2Name);
           //Console.WriteLine(provider2 + "Verified");

           return new ReferralCheckAnswersPage(webDriver);
        }


        public ReferralCheckAnswersPage VerifyEmployersAnswers()
        {
            //String query = ("Select o.postcode, o.searchradius, o.jobtitle, o.PlacementsKnown, o.placements, o.employername, r.Name, o.id from opportunity o, route r where o.RouteId = r.Id and o.ID in (select max(id) from opportunity)");
            String query = ("Select oi.Postcode, oi.SearchRadius, oi.JobRole, oi.PlacementsKnown, oi.Placements, e.CompanyName from opportunity o, OpportunityItem OI, employer e where o.id = oi.OpportunityId and o.EmployerId = e.Id and o.ID in (select max(id) from opportunity)");
            Console.WriteLine(query);

           var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
          

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
                //  ScenarioContext.Current["_provisionGapOpportunityID"] = OpportunityId;

                Console.WriteLine("ActualNoOfPlacements: " + actualNoOfPlacements + "ExpectedNoOfPlacements: " + expectedNoOfPlacementsKnown);
                Console.WriteLine("ActualPostcode: " + actualPostcode + "ExpectedPostcode: " + expectedPostcode);
                Console.WriteLine("ActualSearchRadius: " + actualSearchRadius + "ExpectedSearchRadius: " + expectedSearchRadius);
                Console.WriteLine("ActualJobTitle: " + actualJobtitle + "ExpectedJobTitle: " + expectedJobType);
                Console.WriteLine("ActualSkillArea: " + actualSkillArea + "ExpectedSkillArea: " + expectedTypeOfPlacement);
                Console.WriteLine("ActualEmployerName: " + actualEmployername + "ExpectedEmployerName: " + expectedEmployername);
                Console.WriteLine("ActualpLACEMENTS: " + actualPlacementsKnown);


                //Assert the variables above to the actual values displayed on the screen
                //PageInteractionHelper.VerifyText(actualSkillArea, expectedTypeOfPlacement);
                PageInteractionHelper.VerifyText(actualPostcode, expectedPostcode);
                PageInteractionHelper.VerifyText(actualSearchRadius, expectedSearchRadius);
                PageInteractionHelper.VerifyText(actualJobtitle, expectedJobType);
                PageInteractionHelper.VerifyText(actualNoOfPlacements, actualNoOfPlacements);
            }
            return new ReferralCheckAnswersPage(webDriver);
        }
    }
}
