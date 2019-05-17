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
    public class ReferralDonePage : BasePage
    {
        private static String PAGE_TITLE = ("Emails sent");
        private By FinishButton = By.Id("tl-finish");
        private int opportunityID = (int)ScenarioContext.Current["_provisionGapOpportunityID"];
        private By ActualWhatHappensNextText = By.XPath("//*[@id='main-content']//p[2]");
               
        public ReferralDonePage(IWebDriver webDriver) : base(webDriver)
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

        public ReferralDonePage VerifyCountofReferralRecords()
        {           
            String query = ("select count(*) from referral where opportunityID = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("Opportunity ID: " + opportunityID);

            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
            
            foreach (object[] fieldNo in queryResults)
            {
                //Assign values to variables from the SQL query run
                String actualCount = fieldNo[0].ToString();
                String expectedCount = "1";

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.AssertText(expectedCount, actualCount);
            }
            return this;
        }


        public ReferralDonePage VerifyOptInValueRecorded(String expectectedValue)
        {
            String query = ("Select ConfirmationSelected from opportunity where id = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("Opportunity ID: " + opportunityID);
          
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
            
            foreach (object[] fieldNo in queryResults)
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

        public ReferralDonePage VerifyReferralRecordsCreated()
        {
            string provider1 = (string)ScenarioContext.Current["_Provider1"];
            //string provider2 = (string)ScenarioContext.Current["_Provider2"];

            string[] providerArray;
            providerArray = new string[]{provider1};

            foreach (String items in providerArray)
            {
                String query = ("select count(*) from referral where opportunityID = " + opportunityID + " and providervenueId in (select pv.id from ProviderVenue pv, provider p where pv.ProviderId = p.Id and p.name = '" + items + "')");
                Console.WriteLine(query);
               
                var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
                
                foreach (object[] fieldNo in queryResults)
                {
                    //Assign values to variables from the SQL query run
                    String actualCount = fieldNo[0].ToString();
                    String expectedCount = "1";

                    //Assert the variables above to the actual values displayed on the screen
                    PageInteractionHelper.AssertText(expectedCount, actualCount);
                }
            }
            return this;
        }

        public ReferralDonePage VerifyWhatHappensNextText()
        {
            String expectedEmployername = Constants.employerName;
            String expectedEmployerContact = (string)ScenarioContext.Current["_EmployerContactName"];
              String expectedWhatHappensNextText = ("We expect the provider will contact " + expectedEmployerContact + " within 2 to 3 working days. The provider will work with " + expectedEmployername + " to arrange the terms and details of each placement.");

             PageInteractionHelper.VerifyText(ActualWhatHappensNextText, expectedWhatHappensNextText);
            return this;
        }
    }
}
