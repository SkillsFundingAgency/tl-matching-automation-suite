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
        private static String PAGE_TITLE = (" ");

        public CheckAnswersPage(IWebDriver webDriver) : base(webDriver)
        {
          // SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }


        private By PageHeading = By.XPath("//*[@id='main-content']/div/div/h1");
        private By ConfirmAndSendButton = By.ClassName("govuk-button");
        private By ConfirmationSelected = By.Name("ConfirmationSelected");
        private By TypeOfPlacement = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[1]/td");
        private By Postcode = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[2]/td");
        private By Radius = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[3]/td");
        private By JobRole = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[4]/td");
        private By NumberOfPlacements = By.XPath("//*[@id='main-content']/div/div/table/tbody/tr[5]/td");

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
        private String expectedPostcode = (string)ScenarioContext.Current["_provisionGapPostcode"];
        private String expectedSearchRadius = (string)ScenarioContext.Current["_provisionGapPostcodeRadius"];
        private String expectedJobType = (string)ScenarioContext.Current["_provisionGapJobType"];
        private String expectedNoOfPlacementsKnown = (string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
        private String expectedTypeOfPlacement = (string)ScenarioContext.Current["_provisionGapTypeOfPlacement"];
        private String expectedEmployername = (string)ScenarioContext.Current["_provisionGapEmployerName"];

        

        public void ClickConfirmAndSendutton()
        {
           FormCompletionHelper.ClickElement(ConfirmAndSendButton);
        }

        public void ClickOptIn()
        {
            FormCompletionHelper.ClickElement(ConfirmationSelected);
        }


        public void VerifyPageHeader()
        {
            String expectedPageTitle = "Check " + expectedEmployername + "'s answers";
            String actualPageTitle = PageInteractionHelper.GetText(PageHeading);

            PageInteractionHelper.VerifyPageHeading(actualPageTitle, expectedPageTitle);
        }


        public void VerifyEmployersAnswers()
        {
        
            //String query = ("Select postcode, searchradius, jobtitle, PlacementsKnown, placements, employername from opportunity where ID in (select max(id) from opportunity)");
            String query = ("Select o.postcode, o.searchradius, o.jobtitle, o.PlacementsKnown, o.placements, o.employername, r.Name, o.id from opportunity o, route r where o.RouteId = r.Id and o.ID in (select max(id) from opportunity)");

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
                actualSkillArea = fieldNo[6].ToString();
                OpportunityId = Convert.ToInt32(fieldNo[7]);
                ScenarioContext.Current["_provisionGapOpportunityID"] = OpportunityId;

                Console.WriteLine(actualNoOfPlacements + expectedNoOfPlacementsKnown);
                Console.WriteLine(actualPostcode + expectedPostcode);
                Console.WriteLine(actualSearchRadius + expectedSearchRadius);
                Console.WriteLine(actualJobtitle + expectedJobType);
                Console.WriteLine(actualSkillArea +  expectedTypeOfPlacement);
                Console.WriteLine(actualEmployername + expectedEmployername);
                               

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.AssertText(actualSkillArea, expectedTypeOfPlacement);
                PageInteractionHelper.AssertText(actualPostcode, expectedPostcode);
                PageInteractionHelper.AssertText(actualSearchRadius, expectedSearchRadius);
                PageInteractionHelper.AssertText(actualJobtitle, expectedJobType);
                PageInteractionHelper.AssertText(actualNoOfPlacements, actualNoOfPlacements);


            }
        }







    }
}
