using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SpecFlowFeature1Steps : BaseTest
    {
        [Given(@"I select Provider from the dropdown")]
        public void GivenISelectProviderFromTheDropdown()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.SelectProviderFromDropdown();
        }
        
        [When(@"I press Upload")]
        public void WhenIPressUpload()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.ClickUploadLink();
        }

        [Then(@"I should see an Error")]
        public void ThenIShouldSeeAnError()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I select ""(.*)"" from the dropdown")]
        public void GivenISelectFromTheDropdown(string p0)
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.SelectFromDropdown(p0);
        }

        [Then(@"I should see an Error for no file selected")]
        public void ThenIShouldSeeAnErrorForNoFileSelected()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.NoFileSelectedErrMsgCheck();        
        }

        [Given(@"I select a Word document")]
        public void GivenISelectAWordDocument()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.SelectWordDocument();
        }

        [Then(@"I should see an Error for invalid file selected")]
        public void ThenIShouldSeeAnErrorForInvalidFileSelected()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.WrongFiletypeErrMsgCheck();
        }

        [Given(@"I select a JPEG image")]
        public void GivenISelectAJPEGImage()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);            
            fileUploadPage.SelectJPEGImage();
        }
    }
}
