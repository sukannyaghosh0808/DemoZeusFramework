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
    public sealed class PatientBrowserSteps
    {
        PatientBrowserPage patientBrowserPage = new PatientBrowserPage();

        static string FirstName = RandomItemGenerator.RandomTextGeneration(9);
        static string LastName = RandomItemGenerator.RandomTextGeneration(7);
        static string PhoneNumber = RandomItemGenerator.RandomNumberGeneration(1000000000, 10000000000);
        static string DateOfBirth = "02021997";
        static string EmailID = FirstName + "@gmail.com";
        static string Address1 = RandomItemGenerator.RandomTextGeneration(12);
        static string Zipcode = RandomItemGenerator.RandomNumberGeneration(67801, 67835);




        [Given(@"Patient is not created already with the set of data provided")]
        public void GivenPatientIsNotCreatedAlreadyWithTheSetOfDataProvided()
        {
            patientBrowserPage.SearchWithFirstname(FirstName);
            patientBrowserPage.SearchPatient();
            bool status = patientBrowserPage.ValidateIfPatientPresent();
            Assert.IsTrue(status);
        }


        [When(@"I click on create new patient button")]
        public void WhenIClickOnCreateNewPatientButton()
        {
            patientBrowserPage.ClickCreateNewButton();
        }


        [When(@"I provide all required fields with valid data for patient creation")]
        public void WhenIProvideAllRequiredFieldsWithValidDataForPatientCreation()
        {            
            patientBrowserPage.EnterPatientDetailsToCreateNew(LastName,EmailID,DateOfBirth, Address1, Zipcode,"2", "1", "229", PhoneNumber);
           
        }

        [When(@"I click on create button and skip address verification")]
        public void WhenIClickOnCreateButtonAndSkipAddressVerification()
        {
            patientBrowserPage.ClickCreate();
            Thread.Sleep(4000);
        }

        [Then(@"Patient should be created and successful message ""([^""]*)"" should show on screen")]
        public void ThenPatientShouldBeCreatedAndSuccessfulMessageShouldShowOnScreen(string message)
        {
            //Console.WriteLine("--------------"+patientBrowserPage.GetToastMessage());
            Assert.AreEqual(message, patientBrowserPage.GetToastMessage(), "Actual and Expected Toast Message are not same ");
            ReporterClass.AddStepLog("Message Displayed: " + patientBrowserPage.GetToastMessage());
        }


    }
}
