using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class OpportunitiesBasketReferralPage : BasePage
    {
        private const string PAGE_TITLE = "All opportunities";
        private By continueButton = By.Id("tl-continue");
        private By AddAnotherOpportunity = By.Id("tl-add-another-opportunity");
        private By selectAllCheckbox = By.Name("selectall");
        private By Opportunity1WorkPlace = By.XPath("//tr[1]/td[1]");
        private By Opportunity1JobRole = By.XPath("//tr[1]/td[2]");
        private By Opportunity1StudentsWanted = By.XPath("//tr[1]/td[3]");
        private By Opportunity1NoOfProviders = By.XPath("//tr[1]/td[4]");

        public OpportunitiesBasketReferralPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        //Behaviour
        internal BeforeYouSendEmailsPage ContinueWithOpportunity()
        {
            FormCompletionHelper.ClickElement(continueButton);
            return new BeforeYouSendEmailsPage(webDriver);
        }

        internal BeforeYouSendEmailsPage ContinueWithOpportunityMultipleOpportunities()
        {
            FormCompletionHelper.ClickElement(selectAllCheckbox);
            FormCompletionHelper.ClickElement(continueButton);
            return new BeforeYouSendEmailsPage(webDriver);
        }

        internal FindLocalProvidersPage StartAddingAnotherOpportunityFromBasket()
        {
            FormCompletionHelper.ClickElement(AddAnotherOpportunity);
            return new FindLocalProvidersPage(webDriver);
        }

        //Assertions
        public void VerifyOpportunityDetailsAreDisplayedforOpportunity1()
        {
            string StudentsWanted = "At least 1";
            string NoOfProviders = "1";

            PageInteractionHelper.VerifyText(Opportunity1WorkPlace, Constants.postCode);
            PageInteractionHelper.VerifyText(Opportunity1JobRole, "None given");
            PageInteractionHelper.VerifyText(Opportunity1StudentsWanted, StudentsWanted);
            // PageInteractionHelper.VerifyText(Opportunity1NoOfProviders, NoOfProviders);
        }

        public OpportunitiesBasketReferralPage VerifyLatestReferralRecordValues()
        {
            string EmployerName = (string)ScenarioContext.Current["_provisionGapEmployerName"];
            string _employercontact = (string)ScenarioContext.Current["_EmployerContactName"];
            string _employercontactemail = (string)ScenarioContext.Current["_EmployerContactEmail"];
            string _employercontactphone = (string)ScenarioContext.Current["_EmployerContactNumber"];
            string _opportunityType = "Referral";
            string _searchPostcode = (string)ScenarioContext.Current["_SearchPostcode"];
            string _placementsRequired = (string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
            string _placementsKnown;

            string query = ("select oi.id, o.EmployerContact, o.EmployerContactEmail, o.EmployerContactPhone, OI.OpportunityType, oi.CreatedBy, oi.JobRole, oi.Postcode, oi.PlacementsKnown, oi.Placements, e.CompanyName, oi.SearchRadius from Employer E, Opportunity O, OpportunityItem OI where o.EmployerId = e.Id and o.Id = OI.OpportunityId and oi.id in (select max (oi.id) from Employer E, Opportunity O, OpportunityItem OI where o.EmployerId = e.Id and o.Id = OI.OpportunityId and e.CompanyName  = '" + EmployerName + "')");
            var queryResults = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());

            foreach (object[] fieldNo in queryResults)
            {

                //Assign values to variables from the SQL query run
                string id = fieldNo[0].ToString();
                string employercontact = fieldNo[1].ToString();
                string employercontactemail = fieldNo[2].ToString();
                string employercontactphone = fieldNo[3].ToString();
                string OpportunityType = fieldNo[4].ToString();
                string jobRole = fieldNo[6].ToString();
                string searchPostcode = fieldNo[7].ToString();
                string placementsKnown = fieldNo[8].ToString();
                string numberofPlacements = fieldNo[9].ToString();
                //OpportunityId = Convert.ToInt32(fieldNo[7]);

                if (numberofPlacements == "1")
                {
                    _placementsKnown = "False";
                    _placementsRequired = "1";

                }
                else
                {
                    _placementsKnown = "True";
                }

                // Console.WriteLine("Placements Known: " + placementsKnown);

                //Assert the variables above to the actual values displayed on the screen
                PageInteractionHelper.VerifyText(employercontact, _employercontact);
                PageInteractionHelper.VerifyText(employercontactemail, _employercontactemail);
                PageInteractionHelper.VerifyText(employercontactphone, _employercontactphone);
                PageInteractionHelper.VerifyText(OpportunityType, _opportunityType);
                PageInteractionHelper.VerifyText(searchPostcode, _searchPostcode);
                PageInteractionHelper.VerifyText(placementsKnown, _placementsKnown);
                PageInteractionHelper.VerifyText(numberofPlacements, _placementsRequired);

            }

            return this;
        }

        public OpportunitiesBasketReferralPage VerifyLatestOpportunityValuesDisplayedOnScreen()
        {
            IList<IWebElement> SearchField = webDriver.FindElements(By.TagName("tr"));
                        
            var rowTds = SearchField[1].FindElements(By.TagName("td"));
            string actualWorkPlace = "";
            string actualJobRole = "";
            string actualStudentsWanted = "";
            string actualProviders = "";
            string expectedWorkPlace = (string)ScenarioContext.Current["_SearchPostcode"];
            string expectedJobRole = (string)ScenarioContext.Current["_provisionGapJobType"];
            string expectedStudentsWanted = (string)ScenarioContext.Current["_provisionGapNumberofPlacements"];
            string expectedProviders = (string)ScenarioContext.Current["_Provider1"];

            for (int k = 0; k < rowTds.Count; k++)
            {
                if (k == 0)
                {
                    actualWorkPlace = rowTds[k].Text;
                }
                else if (k==1)
                {
                    actualJobRole = rowTds[k].Text;
                }
                else if (k == 2)
                {
                    actualStudentsWanted = rowTds[k].Text;
                }
                else if (k == 3)
                {
                    actualProviders = rowTds[k].Text;
                }
                
            }

            Framework.Helpers.FormCompletionHelper.VerifyText(actualWorkPlace, expectedWorkPlace);
            Framework.Helpers.FormCompletionHelper.VerifyText(actualStudentsWanted, expectedStudentsWanted );
            Framework.Helpers.FormCompletionHelper.VerifyText(actualProviders, expectedProviders);
            Framework.Helpers.FormCompletionHelper.VerifyText(actualJobRole, expectedJobRole);

            return this;
        }
    }
}

