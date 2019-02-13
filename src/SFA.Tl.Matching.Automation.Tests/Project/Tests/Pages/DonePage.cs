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
        private By FinishButton = By.ClassName("govuk-button");
        private int opportunityID = (int)ScenarioContext.Current["_provisionGapOpportunityID"];



        public DonePage(IWebDriver webDriver) : base(webDriver)
        {
           SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }
                       

        public void ClickFinishbutton()
        {
           FormCompletionHelper.ClickElement(FinishButton);
        }

        public void VerifyProvisionGapRecordCreated()
        {

            // String query = ("select count(*) from ProvisionGap where opportunityID in (select max(id) from opportunity)");
            String query = ("select count(*) from ProvisionGap where opportunityID = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("MAYUR" + opportunityID);

            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());


            foreach (object[] fieldNo in queryResults)
            {
                //Assign values to variables from the SQL query run
                String actualCount = fieldNo[0].ToString();
                String expectedCount = "1";

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.AssertText(actualCount, expectedCount);

            }
        }


        public void VerifyOptInValueRecorded(String expectectedValue)
        {
            String query = ("Select ConfirmationSelected from opportunity where id = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("MAYUR" + opportunityID);
          

            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());


            foreach (object[] fieldNo in queryResults)
            {
                //Assign values to variables from the SQL query run
                String actualConfirmationSelected = fieldNo[0].ToString();
                String expectedConfirmationSelected = expectectedValue;
                Console.WriteLine("MAYUR" + actualConfirmationSelected);

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.AssertText(actualConfirmationSelected, expectedConfirmationSelected);

            }

        }






    }
}
