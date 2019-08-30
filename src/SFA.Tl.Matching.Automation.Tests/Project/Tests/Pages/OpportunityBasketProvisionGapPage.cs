using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class OpportunityBasketProvisionGapPage : BasePage
    {
        private static String PAGE_TITLE = ("Emails sent");
        private int opportunityID = (int)ScenarioContext.Current["_provisionGapOpportunityID"];
        private By FinishButton = By.ClassName("govuk-button");        
               
        public OpportunityBasketProvisionGapPage(IWebDriver webDriver) : base(webDriver)
        {
           SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }                       

        //Behaviour
        internal StartPage FinishProvisionGapJourney()  //FinishProvisionGapJourney
        {
            FormCompletionHelper.ClickElement(FinishButton);
            return new StartPage(webDriver);
        }

        public void VerifyProvisionGapRecordCreated()
        {
            List<Object[]> provisionGapCount = GetProvisionGapCount();
            foreach (object[] fieldNo in provisionGapCount)
            {
                //Assign values to variables from the SQL query run
                String actualCount = fieldNo[0].ToString();
                String expectedCount = Constants.expectedCount;

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.VerifyText(actualCount, expectedCount);
            }
        }

        private List<Object[]> GetProvisionGapCount()
        {
            String query = ("select count(*) from ProvisionGap where opportunityID = " + opportunityID);
            Console.WriteLine(query);
            Console.WriteLine("Opportunity ID: " + opportunityID);

            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());
            return queryResults;
        }        
    }
}
