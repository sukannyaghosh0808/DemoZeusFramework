using NUnit.Framework;
using SpecFlowNunitTestAutomation.Pages;
using SpecFlowNunitTestAutomation.TableData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowNunitTestAutomation.StepDefinitions
{
    [Binding]
    public sealed class PaperCaptureSteps
    {
        PatientBrowserPage patientBrowserPage = new PatientBrowserPage();

        [Given(@"I click the upload button")]
        public void GivenIClickTheUploadButton()
        {
            patientBrowserPage.ClickUploadButton();
        }

        [Given(@"I click the scan icon")]
        public void GivenIClickTheScanIcon()
        {
            patientBrowserPage.ClickScanIcon();
        }
        [Given(@"I select an external file to upload")]
        public void GivenISelectAnExternalFileToUpload()
        {
            Thread.Sleep(1000);
            //string path = @"C:\Users\Sukannya Ghosh\Desktop\patient issue.png";
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + @"\TestData\patient issue.png";
            patientBrowserPage.UploadExternalFile(path);
            Thread.Sleep(3000);
        }

        [Given(@"I select the following options in paper capture popup")]
        public void GivenISelectTheFollowingOptionsInPaperCapturePopup(Table table)
        {
            var data = table.CreateInstance<PaperCaptureTableData>();
            string category = data.Category;
            string subcategory = data.SubCategory;
            patientBrowserPage.selectCategory(category);
            patientBrowserPage.selectSubCategory(subcategory);
            Thread.Sleep(2000);
        }
        [Given(@"I provide a new title")]
        public void GivenIProvideANewTitle()
        {
            patientBrowserPage.EnterpaperCaptureTitle("patient issue");
            Thread.Sleep(2000);
        }
        [When(@"I click the add button in paper capture modal window")]
        public void WhenIClickTheAddButtonInPaperCaptureModalWindow()
        {
            patientBrowserPage.ClickAddPaperCaptureButton();
            Thread.Sleep(3000);
        }
        [Then(@"The success message ""([^""]*)"" is displayed on screen")]
        public void ThenTheSuccessMessageIsDisplayedOnScreen(string p0)
        {
            string actual = patientBrowserPage.GetToastMessage();
            
            Assert.AreEqual(actual, p0,"File upload unsuccessful");
        }
        [When(@"I click the view link for the file just added")]
        public void WhenIClickTheViewLinkForTheFileJustAdded()
        {
            patientBrowserPage.ClickPaperCaptureViewLink();
            Thread.Sleep(3000);
        }

        [Then(@"The file is displayed on screen")]
        public void ThenTheFileIsDisplayedOnScreen()
        {
            //how do i validate its the same file
            Assert.True(patientBrowserPage.IsNewlyAdedPaperCaptureIsPresent(),"File is not visible");
        }
        [Given(@"I click the edit icon in the file")]
        public void GivenIClickTheEditIconInTheFile()
        {
            patientBrowserPage.ClickpaperCaptureEditButton();
        }
        [Given(@"I provide a new title for editing")]
        public void GivenIProvideANewTitleForEditing()
        {
            patientBrowserPage.EnterpaperCaptureTitle("patient insurance");
            Thread.Sleep(1000);
        }
        [When(@"I click the update button")]
        public void WhenIClickTheUpdateButton()
        {
            patientBrowserPage.ClickUpdateButton();
            Thread.Sleep(2000);
        }

        [Given(@"I close the file displayed on screen")]
        public void GivenICloseTheFileDisplayedOnScreen()
        {
            patientBrowserPage.ClosePaperCaptureFile();
        }


        [When(@"I click the delete icon in the grid for the file just added")]
        public void WhenIClickTheDeleteIconInTheGridForTheFileJustAdded()
        {
            patientBrowserPage.DeletePaperCapture();
            patientBrowserPage.ConfirmDelete();
            Thread.Sleep(3000);
        }

        [Given(@"I close the Paper Capture modal window")]
        public void GivenICloseThePaperCaptureModalWindow()
        {
            patientBrowserPage.ClosePaperCaptureFile();
            Thread.Sleep(3000);
        }


        [Given(@"I click the select icon")]
        public void GivenIClickTheSelectIcon()
        {
            patientBrowserPage.ClickPaperCaptureSelectIcon();
            Thread.Sleep(2000);
        }

        [Given(@"I select an existing file")]
        public void GivenISelectAnExistingFile()
        {
            patientBrowserPage.SelectExistingFile();
            patientBrowserPage.PaperCaptureExistingFileSelectButton();
        }

    }
}
