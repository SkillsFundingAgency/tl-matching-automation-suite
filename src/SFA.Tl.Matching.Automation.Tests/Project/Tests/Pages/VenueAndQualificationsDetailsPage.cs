using NUnit.Framework;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class VenueAndQualificationsDetailsPage : BasePage
    {
        private static String PAGE_TITLE = "B43 6JN";
        private By AddQualificationLink = By.PartialLinkText("Add a qualification");
        private By QualificationsTable = By.XPath("//table");

        public VenueAndQualificationsDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
            if (ScenarioContext.Current.TryGetValue<string>("PostCodeTextFromVenuesTable", out string x))
            {
                PAGE_TITLE = x;
            }
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public AddQualificationPage ClickAddQualificationLink()
        {
             FormCompletionHelper.ClickElement(AddQualificationLink);
             return new AddQualificationPage(webDriver);
        }      

        public String GetQualificationId(String query)
        {            
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());

            String LardIdMappedToService = null;
            foreach (object[] LarId in queryResults)
            {                
                LardIdMappedToService = LarId[0].ToString();
            }
            return LardIdMappedToService;
        }

        public void VerifyQualificationIsAdded(String QualId)
        {
            IWebElement elemTable = webDriver.FindElement(QualificationsTable);
            List<IWebElement> qualTableList = new List<IWebElement>(elemTable.FindElements(By.TagName("td")));
            IWebElement row = qualTableList.Where(item => item.Text.Contains(QualId)).FirstOrDefault();
            var value = qualTableList.GroupBy(x => x).Where(group => group.Count() > 1).Select(group => group.Key).ToList();
            Assert.AreEqual(0, value.Count);
        }
    }
}