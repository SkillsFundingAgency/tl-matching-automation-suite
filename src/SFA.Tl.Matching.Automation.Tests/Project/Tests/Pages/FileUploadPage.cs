using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class FileUploadPage : BasePage
    {
        private static String PAGE_TITLE = "Data Import";
        private String EmployerFileLocation = "C:/EmployersDataFile.xlsx";
        private String ProviderFileLocation = "C:/ProviderData.xlsx";
        private String WordDocumentLocation = "C:/Word.docx";
        private String JPEGImageLocation = "C:/Image.jpg";
        private String ExpectedPageURL = "https://tl-test-mtchui-as.azurewebsites.net/Search/Start";
        String ExpectedSuccessTitle = "File uploaded successfully";
        private By ActualSuccessTitle = By.ClassName("das-notification__body");
        private By LogoffButton = By.LinkText("Sign out");
        private By UploadButton = By.ClassName("govuk-button");
        private By BrowseFile = By.ClassName("govuk-file-upload");
        public By SuccessMessage = By.ClassName("das-notification__body");
        private By Dropdown = By.Id("SelectedImportType");
        private By ActualErrWrongFiletypeSelected = By.LinkText("You must upload an Excel file with the XLSX file extension");
        private By ActualErrNoFileSelected = By.LinkText("You must select a file");
        String ExpectedErrNoFileSelected = "You must select a file";
        String ExpectedErrWrongFiletypeSelected = "You must upload an Excel file with the XLSX file extension";


        public FileUploadPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public void VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, ExpectedPageURL);
        }

        public void VerifyUploadSuccessMessage()
        {
            PageInteractionHelper.VerifyText(ActualSuccessTitle, ExpectedSuccessTitle);
            webDriver.Close();
        }

        public void ClickUploadLink()
        {
            FormCompletionHelper.ClickElement(UploadButton);
        }

        public void SelectEmployerFile()
        {
            FormCompletionHelper.EnterText(BrowseFile, EmployerFileLocation);
        }

        public void SelectProviderFile()
        {
            FormCompletionHelper.EnterText(BrowseFile, ProviderFileLocation);
        }

        public void SelectWordDocument()
        {
            FormCompletionHelper.EnterText(BrowseFile, WordDocumentLocation);
        }

        public void SelectJPEGImage()
        {
            FormCompletionHelper.EnterText(BrowseFile, JPEGImageLocation);
        }

        public void SelectEmployerFromDropdown()
        {
            FormCompletionHelper.SelectFromDropDownByValue(Dropdown, "Employer");
        }

        public void SelectProviderFromDropdown()
        {
            FormCompletionHelper.SelectFromDropDownByValue(Dropdown, "Provider");
        }

        public void SelectFromDropdown(String dropdownValue)
        {
            FormCompletionHelper.SelectFromDropDownByValue(Dropdown, dropdownValue);
        }

        public void Logoff()
        {
            FormCompletionHelper.ClickElement(LogoffButton);
        }

        public void NoFileSelectedErrMsgCheck()
        {
            PageInteractionHelper.VerifyText(ActualErrNoFileSelected, ExpectedErrNoFileSelected);
        }

        public void WrongFiletypeErrMsgCheck()
        {
            PageInteractionHelper.VerifyText(ActualErrWrongFiletypeSelected, ExpectedErrWrongFiletypeSelected);
        }

        public void ClearProviderTable()
        {
            String DeleteProviderQuery = "Delete FROM Provider";
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteProviderQuery, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            //Confirm theProvider table is cleared down:
            String ProviderRecordCount = "Select Count(*) FROM Provider";
            var result = SqlDatabaseConncetionHelper.ReadDataFromDataBase(ProviderRecordCount, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
            Assert.AreEqual(result[0][0], 0);
        }

        public void VerifyNewProviderCreated()
        {
            Thread.Sleep(10000);
            String ProviderRecordCount = "Select Count(*) FROM Provider";
            var result = SqlDatabaseConncetionHelper.ReadDataFromDataBase(ProviderRecordCount, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
            Assert.AreEqual(341, result[0][0]);
        }
    }
}
