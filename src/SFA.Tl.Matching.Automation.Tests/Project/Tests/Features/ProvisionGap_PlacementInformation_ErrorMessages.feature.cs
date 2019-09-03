﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Provision Gap - Placement Information - Error Messages")]
    public partial class ProvisionGap_PlacementInformation_ErrorMessagesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ProvisionGap_PlacementInformation_ErrorMessages.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Provision Gap - Placement Information - Error Messages", "\tThis feature is used to confirm the error messages on the Placement information " +
                    "page for a provision gap", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
 testRunner.Given("I have navigated to the IDAMS login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And("I have logged in as an \"Admin User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("No Suitable Providers - Placement Information - Error Messages when No data is en" +
            "tered and click Continue")]
        [NUnit.Framework.CategoryAttribute("regression")]
        public virtual void NoSuitableProviders_PlacementInformation_ErrorMessagesWhenNoDataIsEnteredAndClickContinue()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No Suitable Providers - Placement Information - Error Messages when No data is en" +
                    "tered and click Continue", null, new string[] {
                        "regression"});
#line 9
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 10
 testRunner.Given("I navigate to the Provision Gap Placement Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I enter no placement information and Continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("the Placement Information page will show an error stating \"You must tell us why t" +
                    "he employer did not choose a provider\" for \"NoProvidersChosen\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And("the Placement Information page will show an error stating \"You must tell us wheth" +
                    "er the employer knows how many students they want for this job at this location\"" +
                    " for \"StudentsOptionNotSelected\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Placement Information - Number of Placements field is shown only if Yes is select" +
            "ed")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.TestCaseAttribute("Yes", "Displayed", null)]
        [NUnit.Framework.TestCaseAttribute("No", "Not Displayed", null)]
        public virtual void PlacementInformation_NumberOfPlacementsFieldIsShownOnlyIfYesIsSelected(string value, string result, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Placement Information - Number of Placements field is shown only if Yes is select" +
                    "ed", null, @__tags);
#line 16
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 17
 testRunner.Given("I navigate to the Provision Gap Placement Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.When(string.Format("I select {0} for how many students needed", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then(string.Format("Number of Students field is {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Placement Information - Job type must be between 2 and 99 characters")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.TestCaseAttribute("1", "A", "You must enter a job role using 2 or more characters", null)]
        [NUnit.Framework.TestCaseAttribute("100", "ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJA" +
            "BCDEFGHIJABCDEFGHIJA", "You must enter a job role that is 100 characters or fewer", null)]
        [NUnit.Framework.TestCaseAttribute("Numbers", "123456", "You must enter a job role using letters", null)]
        [NUnit.Framework.TestCaseAttribute("SpecialCharacters", "%^&**&^", "You must enter a job role using letters", null)]
        [NUnit.Framework.TestCaseAttribute("NumAndSpecialChar", "565%$^^6678&*", "You must enter a job role using letters", null)]
        public virtual void PlacementInformation_JobTypeMustBeBetween2And99Characters(string number, string jobRole, string errorMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Placement Information - Job type must be between 2 and 99 characters", null, @__tags);
#line 26
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 27
 testRunner.Given("I navigate to the Provision Gap Placement Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When(string.Format("I enter an invalid job title {0} and Continue", jobRole), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then(string.Format("the {0} for Invalid Job Role for {1} characters is displayed", errorMessage, number), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Placement Information - Number of Students must be between 1 and 999")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.TestCaseAttribute("0", "The number of students must be 1 or more", null)]
        [NUnit.Framework.TestCaseAttribute("1000", "The number of students must be 999 or less", null)]
        [NUnit.Framework.TestCaseAttribute("", "You must estimate how many students the employer wants for this job at this locat" +
            "ion", null)]
        public virtual void PlacementInformation_NumberOfStudentsMustBeBetween1And999(string number, string errorMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Placement Information - Number of Students must be between 1 and 999", null, @__tags);
#line 39
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 4
this.FeatureBackground();
#line 40
 testRunner.Given("I navigate to the Provision Gap Placement Information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When(string.Format("I enter Invalid number of Students {0} and Continue", number), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then(string.Format("the {0} for Invalid Number of Students is displayed for {1}", errorMessage, number), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

