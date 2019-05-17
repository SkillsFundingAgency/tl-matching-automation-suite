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
    public class CheckAnswersPage : BasePage
    {
        private By PageHeading = By.XPath("//*[@id='main-content']/div/div/h1");
        private By ConfirmAndSendButton = By.ClassName("govuk-button");
        private By ConfirmationSelected = By.Name("ConfirmationSelected");
        private By TypeOfPlacement = By.XPath("//*[@id='main-content']//tr[1]/td[1]");
        private By Postcode = By.XPath("//*[@id='main-content']//tr[2]/td[1]");
        private By JobRole = By.XPath("//*[@id='main-content']//tr[3]/td[1]");
        private By NumberOfPlacements = By.XPath("//*[@id='main-content']//tr[4]/td[1]");

        private static String PAGE_TITLE = (" ");
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
        private String expectedPostcode = Constants.postCode;
        private String expectedSearchRadius = Constants.radius;
        private String expectedJobType = Constants.jobTitle;
        private String expectedNoOfPlacementsKnown = (string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
        private String expectedTypeOfPlacement = Constants.skillArea;
        private String expectedEmployername = Constants.employerName;

        public CheckAnswersPage(IWebDriver webDriver) : base(webDriver)
        {
          // SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }               

        public DonePage ClickConfirmAndSendutton()
        {
           FormCompletionHelper.ClickElement(ConfirmAndSendButton);

            return new DonePage(webDriver);
        }

        public CheckAnswersPage ClickOptIn()
        {
            FormCompletionHelper.ClickElement(ConfirmationSelected);
            return new CheckAnswersPage(webDriver);
        }
        
        public CheckAnswersPage VerifyPageHeader()
        {
            String expectedPageTitle = "Check " + expectedEmployername + "'s answers";
            String actualPageTitle = PageInteractionHelper.GetText(PageHeading);

            PageInteractionHelper.VerifyPageHeading(actualPageTitle, expectedPageTitle);

            return new CheckAnswersPage(webDriver);
        }
        
        public CheckAnswersPage VerifyEmployersAnswers()
        {
            List<Object[]> opportunityInfo = GetOpportunityDetails();
            
            foreach (object[] fieldNo in opportunityInfo)
            {
                //Assign values to variables from the SQL query run
                actualPostcode = fieldNo[0].ToString();
                actualSearchRadius = (fieldNo[1].ToString() + " miles");
                actualJobtitle = fieldNo[2].ToString();
                actualPlacementsKnown = Convert.ToInt32(fieldNo[3]);
                actualNoOfPlacements = fieldNo[4].ToString();
                actualEmployername = fieldNo[5].ToString();
                actualSkillArea = fieldNo[6].ToString();
                OpportunityId = Convert.ToInt32(fieldNo[7]);
                ScenarioContext.Current["_provisionGapOpportunityID"] = OpportunityId;

                // checking values against sql record                     
                //Assert the variables entered in the journey to the actual values written to the opportunity record
                PageInteractionHelper.AssertText(actualSkillArea, expectedTypeOfPlacement);
                PageInteractionHelper.AssertText(actualPostcode, expectedPostcode);
                PageInteractionHelper.AssertText(actualSearchRadius, expectedSearchRadius);
                PageInteractionHelper.AssertText(actualJobtitle, expectedJobType);
                PageInteractionHelper.AssertText(actualNoOfPlacements, actualNoOfPlacements);
            }
            //checking values against UI screen
            PageInteractionHelper.VerifyText(TypeOfPlacement, expectedTypeOfPlacement);
            PageInteractionHelper.VerifyText(Postcode, expectedPostcode);
            PageInteractionHelper.VerifyText(JobRole, expectedJobType);
            PageInteractionHelper.VerifyText(NumberOfPlacements, expectedNoOfPlacementsKnown);

            return new CheckAnswersPage(webDriver);
        }


        private List<Object[]> GetOpportunityDetails()
        {
            String query = ("Select o.postcode, o.searchradius, o.jobtitle, o.PlacementsKnown, o.placements, o.employername, r.Name, o.id from opportunity o, route r where o.RouteId = r.Id and o.ID in (select max(id) from opportunity)");
            Console.WriteLine(query);

            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            return queryResults;
        }
    }
}