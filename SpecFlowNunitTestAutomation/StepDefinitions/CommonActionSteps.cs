using NUnit.Framework;
using SpecFlowNunitTestAutomation.Hooks;
using SpecFlowNunitTestAutomation.Pages;
using SpecFlowNunitTestAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowNunitTestAutomation.StepDefinitions
{
    [Binding]
    public sealed class CommonActionSteps
    {
        LoginPage loginPage = new LoginPage();
        DashboardPage dashboardPage = new DashboardPage();
        PatientBrowserPage patientBrowserPage= new PatientBrowserPage();    

        //Common steps for Login page
        [Given(@"Launch the Zeus application")]
        public void GivenLaunchTheZeusApplication()
        {
            loginPage.LaunchZeusApplication();            
        }
        [Given(@"User is not logged in")]
        public void GivenUserIsNotLoggedIn()
        {
            bool loginStatus= loginPage.ValidateLoginPage();
            Assert.IsTrue(loginStatus,"User is already logged in. Please log out and try!");
        }



        //Common Steps for Patient Browser Page
        [Given(@"I login to the Zeus application with valid credentials")]
        public void GivenILoginToTheZeusApplicationWithValidCredentials()
        {
            string username = ExcelUtils.ReadDataFromExcel("Username");
            string password = ExcelUtils.ReadDataFromExcel("Password");
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClickLogin();
            ReporterClass.AddStepLog("Username provided: " + username);
            ReporterClass.AddStepLog("Password provided: " + password);
        }


        [When(@"I click on distribution center change button")]
        public void WhenIClickOnDistributionCenterChangeButton()
        {
            dashboardPage.ClickOnDistributionCenterChangeButton();
        }

        static string store = "5001 | Doctor - Mishawaka";
        [When(@"I select a store randomly")]
        public void WhenISelectAStoreRandomly()
        {            
            dashboardPage.SelectAnyStore(store);
        }


        [Then(@"The store should change to what was selected randomly")]
        public void ThenTheStoreShouldChangeToWhatWasSelectedRandomly()
        {
            if(store==dashboardPage.GetCurrentStoreName())
            {
                ReporterClass.AddStepLog("Selected store : " + store);
            }
            else
            {
                Assert.Fail("Could not select proper store ");
            }
        }

        [Given(@"I search for the ""([^""]*)"" patient created")]
        public void GivenISearchForThePatientCreated(string first)
        {
            patientBrowserPage.EnterDetailsToSearchExistingPatient(first, string.Empty, string.Empty, string.Empty, string.Empty);
            patientBrowserPage.SearchPatient();
        }

        [Given(@"I click the view file link for the patient created")]
        public void GivenIClickTheViewFileLinkForThePatientCreated()
        {
            patientBrowserPage.ViewFileForFirstPatient();
        }


        [Given(@"I go to the paper capture tab")]
        public void GivenIGoToThePaperCaptureTab()
        {
            patientBrowserPage.GoToPatientBrowserTab();
        }

    }
}
