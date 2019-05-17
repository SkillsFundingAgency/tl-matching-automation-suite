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
    public class DonePage : BasePage
    {
        private static String PAGE_TITLE = ("Report sent to the industry placement team");
        private int opportunityID = (int)ScenarioContext.Current["_provisionGapOpportunityID"];
        private By FinishButton = By.ClassName("govuk-button");        
               
        public DonePage(IWebDriver webDriver) : base(webDriver)
        {
           SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }                       

        public DonePage ClickFinishbutton()
        {
           FormCompletionHelper.ClickElement(FinishButton);

            return this;
        }

        public DonePage VerifyProvisionGapRecordCreated()
        {

            List<Object[]> provisionGapCount = GetProvisionGapCount();


            foreach (object[] fieldNo in provisionGapCount)
            {
                //Assign values to variables from the SQL query run
                String actualCount = fieldNo[0].ToString();
                String expectedCount = Constants.expectedCount;

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.AssertText(actualCount, expectedCount);
            }

            return this;
        }

        private List<Object[]> GetProvisionGapCount()
        {
            String query = ("select count(*) from ProvisionGap where opportunityID = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("Opportunity ID: " + opportunityID);

            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            return queryResults;
        }
        
        public DonePage VerifyOptInValueRecorded(String expectectedValue)
        {
            List<Object[]> confirmationSelected = GetConfirmationSelected();

            foreach (object[] fieldNo in confirmationSelected)
            {
                //Assign values to variables from the SQL query run
                String actualConfirmationSelected = fieldNo[0].ToString();
                String expectedConfirmationSelected = expectectedValue;
                Console.WriteLine("Confirmation Selected: " + actualConfirmationSelected);

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.AssertText(actualConfirmationSelected, expectedConfirmationSelected);
            }

            return this;
        }


        private List<Object[]> GetConfirmationSelected()
        {
            String query = ("Select ConfirmationSelected from opportunity where id = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("Opportunity ID: " + opportunityID);

            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            return queryResults;
        }
    }
}
