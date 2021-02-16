using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class EmailsSentPage : BasePage
    {
        private static String PAGE_TITLE = ("Emails sent");
        private By FinishButton = By.Id("tl-end");
        //private int opportunityID = (int)ScenarioContext.Current["_provisionGapOpportunityID"];
        private int opportunityID = 212; 
        private By ActualWhatHappensNextText = By.XPath("//*[@id='main-content']//p[2]");
               
        public EmailsSentPage(IWebDriver webDriver) : base(webDriver)
        {
           SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }                       

        //Actions
        private void ClickFinishbutton()
        {
           FormCompletionHelper.ClickElement(FinishButton);
        }

        //Behaviour
        internal StartPage FinishReferralJourney()
        {
            ClickFinishbutton();
            return new StartPage(webDriver);
        }

        //Assertions
        public void VerifyCountofReferralRecords()
        {           
            String query = ("select count(*) from referral where opportunityID = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("Opportunity ID: " + opportunityID);
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());
            
            foreach (object[] fieldNo in queryResults)
            {
                //Assign values to variables from the SQL query run
                String actualCount = fieldNo[0].ToString();
                String expectedCount = "1";

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.VerifyText(expectedCount, actualCount);
            }
        }

        //Once you find with Mayur place this method in appropriate page (either here or oppBasketPage)
        public void VerifyOptInValueRecorded(String expectectedValue)
        {
            List<Object[]> confirmationSelected = GetConfirmationSelected();

            foreach (object[] fieldNo in confirmationSelected)
            {
                //Assign values to variables from the SQL query run
                String actualConfirmationSelected = fieldNo[0].ToString();
                String expectedConfirmationSelected = expectectedValue;
                Console.WriteLine("Confirmation Selected: " + actualConfirmationSelected);

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.VerifyText(actualConfirmationSelected, expectedConfirmationSelected);
            }
        }

        private List<Object[]> GetConfirmationSelected()
        {
            String query = ("Select ConfirmationSelected from opportunity where id = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("Opportunity ID: " + opportunityID);
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());
            return queryResults;
        }

        public void VerifyReferralRecordsCreated()
        {
            string provider1 = (string)ScenarioContext.Current["_Provider1"];
            //string provider2 = (string)ScenarioContext.Current["_Provider2"];

            string[] providerArray;
            providerArray = new string[]{provider1};

            foreach (String items in providerArray)
            {
                String query = ("select count(*) from referral where opportunityID = " + opportunityID + " and providervenueId in (select pv.id from ProviderVenue pv, provider p where pv.ProviderId = p.Id and p.name = '" + items + "')");
                Console.WriteLine(query);               
                var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());
                
                foreach (object[] fieldNo in queryResults)
                {
                    //Assign values to variables from the SQL query run
                    String actualCount = fieldNo[0].ToString();
                    String expectedCount = "1";

                    //Assert the variables above to the actual values displayed on the screen
                    PageInteractionHelper.VerifyText(expectedCount, actualCount);
                }
            }
        }

        public void VerifyWhatHappensNextText()
        {
            String expectedEmployername = Constants.employerName;
            String expectedEmployerContact = (string)ScenarioContext.Current["_EmployerContactName"];
            String expectedWhatHappensNextText = ("We expect the provider will contact " + expectedEmployerContact + " within 2 to 3 working days. The provider will work with " + expectedEmployername + " to arrange the terms and details of each placement.");

            PageInteractionHelper.VerifyText(ActualWhatHappensNextText, expectedWhatHappensNextText);
        }

        public int GetIsCompleted(String query)
        {
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());

            String OpportunityItemId = null;
            foreach (object[] OppItemId in queryResults)
            {
                OpportunityItemId = OppItemId[0].ToString();
            }
            int IsCompleted = 0;
            for (int i = 0; i < 90000; i++)
            {
                if (IsCompleted == 0)
                {
                    var query2 = ("select IsCompleted from OpportunityItem where Id = '" + OpportunityItemId + "'");
                    var queryResults2 = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query2, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());

                    foreach (object[] Value in queryResults2)
                    {
                        IsCompleted = Convert.ToInt32(Value[0]);
                    }
                }
                else
                {
                    break;
                }
            }
            return IsCompleted;
        }

        public void VerifyIsCompletedIsTrue(int actualValue)
        {
            int expectedValue = 1;
            PageInteractionHelper.VerifyValue(actualValue, expectedValue);
        }
    }
}
