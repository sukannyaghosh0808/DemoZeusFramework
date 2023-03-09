using ICSharpCode.SharpZipLib.GZip;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using SpecFlowNunitTestAutomation.Hooks;
using SpecFlowNunitTestAutomation.Pages;
using SpecFlowNunitTestAutomation.TableData;
using SpecFlowNunitTestAutomation.Utils;
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
    public sealed class PatientBrowserSteps
    {
        PatientBrowserPage patientBrowserPage = new ();

        
        public string FirstName =  RandomItemGenerator.RandomTextGeneration(12);
        public string LastName = RandomItemGenerator.RandomTextGeneration(14);
        public string PhoneNumber = RandomItemGenerator.RandomNumberGeneration(1000000000, 10000000000);
        public string DateOfBirth = "05/05/1995";
        public string EmailID = RandomItemGenerator.RandomTextGeneration(7)+ "@yahoo.com";
        public string Address1 = RandomItemGenerator.RandomTextGeneration(12);
        public string Zipcode = RandomItemGenerator.RandomNumberGeneration(67801, 67835);

        public string InvalidFirstName = RandomItemGenerator.RandomTextGeneration(6)+ RandomItemGenerator.RandomNumberGeneration(10, 100);
        public string InvalidLastName = RandomItemGenerator.RandomTextGeneration(6) + RandomItemGenerator.RandomNumberGeneration(10, 100);
        public string InvalidEmail = RandomItemGenerator.RandomTextGeneration(6);
        public string InvalidDateOfBirth = RandomItemGenerator.RandomNumberGeneration(57801997, 67801997);
        public string InvalidAddress1 = RandomItemGenerator.RandomTextGeneration(351);
        public string InvalidPhoneNumber = RandomItemGenerator.RandomNumberGeneration(10000000000, 100000000000);
        public string alreadyRegistredMobile = "9999999999";
        public string InvalidZipcode = " ";

        [Given(@"Patient is not created already with the set of data provided")]
        public void GivenPatientIsNotCreatedAlreadyWithTheSetOfDataProvided()
        {
            //Using First Name, Last Name, Phone Number, Date Of Birth and Email
            patientBrowserPage.EnterDetailsToSearchExistingPatient(FirstName,LastName,PhoneNumber,DateOfBirth,EmailID);
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
            patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName,LastName,EmailID,DateOfBirth, Address1, Zipcode,"2", "1", "229", PhoneNumber);
            patientBrowserPage.clickContinueWithoutEmail();
        }

        [When(@"I click on create button and skip address verification")]
        public void WhenIClickOnCreateButtonAndSkipAddressVerification()
        {
            //The patient is creating automatically even without checking the skip address verification checkbox.
            patientBrowserPage.ClickCreate();
            //Thread.Sleep(4000);
        }

        [Then(@"Patient should be created and successful message ""([^""]*)"" should show on screen")]
        public void ThenPatientShouldBeCreatedAndSuccessfulMessageShouldShowOnScreen(string message)
        {
            Assert.AreEqual(message, patientBrowserPage.GetToastMessage(), "Actual and Expected Toast Message are not same ");
            ReporterClass.AddStepLog("Message Displayed: " + patientBrowserPage.GetToastMessage());
        }



        [When(@"I provide all the required fields with valid data except First Name")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptFirstName()
        {
            patientBrowserPage.EnterPatientDetailsToCreateNew(InvalidFirstName,LastName, EmailID, DateOfBirth, Address1, Zipcode, "2", "1", "229", PhoneNumber);
            patientBrowserPage.clickContinueWithoutEmail();
        }


        [When(@"I click on create button")]
        public void WhenIClickOnCreateButton()
        {
            patientBrowserPage.ClickCreate();
            Thread.Sleep(4000);
        }


        [Then(@"Patient should not be created and error message ""([^""]*)"" should show on screen")]
        public void ThenPatientShouldNotBeCreatedAndErrorMessageShouldShowOnScreen(string message)
        {
            Assert.AreEqual(message, patientBrowserPage.GetToastMessage(), "Actual and Expected Error Message are not same ");
        }


        [When(@"I provide all the required fields with valid data except Last Name")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptLastName()
        {
            patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName,InvalidLastName,EmailID,DateOfBirth,Address1,Zipcode,"2","1","229",PhoneNumber);
            patientBrowserPage.clickContinueWithoutEmail();
        }


        [When(@"I provide all the required fields with valid data except email")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptEmail()
        {
           patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName,LastName,InvalidEmail,DateOfBirth,Address1,Zipcode,"2","1","229",PhoneNumber);
        }

        [When(@"I provide all the required fields with valid data except DOB")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptDOB()
        {
            patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName, LastName, EmailID, InvalidDateOfBirth, Address1, Zipcode, "2", "1", "229", PhoneNumber);
            patientBrowserPage.clickContinueWithoutEmail();
        }

        [When(@"I provide all the required fields with valid data except Address")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptAddress()
        {
            patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName, LastName, EmailID,DateOfBirth, InvalidAddress1, Zipcode, "2", "1", "229", PhoneNumber);
            patientBrowserPage.clickContinueWithoutEmail();
        }



        [When(@"I provide all the required fields with valid data except Phone Number")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptPhoneNumber()
        {
            patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName, LastName, EmailID, DateOfBirth,Address1, Zipcode, "2", "1", "229", InvalidPhoneNumber);
            patientBrowserPage.clickContinueWithoutEmail();
        }
        [When(@"I provide all the required fields with valid data except a phone number that is already registered with another patient")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptAPhoneNumberThatIsAlreadyRegisteredWithAnotherPatient()
        {
            
            patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName, LastName, EmailID, DateOfBirth, Address1, Zipcode, "2", "1", "229", alreadyRegistredMobile);
            patientBrowserPage.clickContinueWithoutEmail();
        }

        [Then(@"A confirmation popup gets prompted to the user to continue with the existing phone number")]
        public void ThenAConfirmationPopupGetsPromptedToTheUserToContinueWithTheExistingPhoneNumber()
        {
            bool status = patientBrowserPage.ValidatePhoneWaringMessage(alreadyRegistredMobile);
            if (status==true) 
                ReporterClass.AddStepLog("Popup displaying");
            else
                Assert.Fail("Phone Confrmation PopUp does not contain existing mobile number");        
        }

        [When(@"I provide all the required fields with valid data except ZipCode")]
        public void WhenIProvideAllTheRequiredFieldsWithValidDataExceptZipCode()
        {
            patientBrowserPage.EnterPatientDetailsToCreateNew(FirstName, LastName, EmailID, DateOfBirth, Address1,InvalidZipcode, "2", "1", "229", alreadyRegistredMobile);
            patientBrowserPage.clickContinueWithoutEmail();
        }
        
        [When(@"I provide all required fields with valid data that is already used for patient creation")]
        public void WhenIProvideAllRequiredFieldsWithValidDataThatIsAlreadyUsedForPatientCreation()
        {
            string _fullname = "Tom";
            string _addressLine1 = "New York City";
            string _lastname = "Welsmith";
            string _dob = "03031997";
            string _mail = "TomWel123@gmail.com";
            string _zip = "56001";
            string _sex = "2";
            string _phtype = "1";
            string _usd = "229";
            string _ph = "8013456334";
            patientBrowserPage.EnterPatientDetailsToCreateNew(_fullname,_lastname, _mail, _dob,_addressLine1,_zip,_sex,_phtype,_usd,_ph);
            patientBrowserPage.clickContinueWithoutEmail();

        }

        [When(@"I provide all required fields with valid data for patient creation with leading whitespaces")]
        public void WhenIProvideAllRequiredFieldsWithValidDataForPatientCreationWithLeadingWhitespaces()
        {
            string whitespaces_FirstName = "    wendy";
            string whitespaces_MiddleName = "    harry";
            string whitespaces_LastName = "    smith";
            patientBrowserPage.EnterPatientDetailsToCreateNew(whitespaces_FirstName, whitespaces_MiddleName,whitespaces_LastName, EmailID, DateOfBirth, Address1, Zipcode, "2", "1", "229", PhoneNumber);
            patientBrowserPage.clickContinueWithoutEmail();
        }

        static string existingNumber = "8013456334";
        static string existingName = "Tom";

        [When(@"I search for a patient with ""([^""]*)""")]
        public void WhenISearchForAPatientWith(string phoneNumber)
        {
            phoneNumber = existingNumber;
            patientBrowserPage.searchPatientWithPhone(phoneNumber);
            patientBrowserPage.SearchPatient();
        }


        [Then(@"The patient with correct ""([^""]*)"" is displayed on screen")]
        public void ThenThePatientWithCorrectIsDisplayedOnScreen(string phoneNumber)
        {
            phoneNumber= existingNumber;
            string name = patientBrowserPage.getPatientNameAfterSearch();
            if (name == existingName)
            {
                ReporterClass.AddStepLog("Name : " + name);
                ReporterClass.AddStepLog("Phone Number : " + phoneNumber);
            }
            else
                Assert.Fail("Correct patient details is not retrieved. getting patient with name:" + name);
        }

        [Then(@"Recently added link should be visible")]
        public void ThenRecentlyAddedLinkShouldBeVisible()
        {
            Assert.IsTrue(patientBrowserPage.ValidateRecentlyAddedLink(),"Link is not displayed");
        }


        [When(@"I click the recently added link")]
        public void WhenIClickTheRecentlyAddedLink()
        {
            patientBrowserPage.clickRecentlyAddedLink();
            Thread.Sleep(4000);
        }


        [Then(@"Patient profile data is displayed on screen")]
        public void ThenPatientProfileDataIsDisplayedOnScreen()
        {
            bool status = patientBrowserPage.ValidatePatientFileLink();
            Assert.IsTrue(status, "Patient File is unable to open");
            ReporterClass.AddStepLog("Recently added link navigates to the patient file");
        }

        [When(@"I search for a patient")]
        public void WhenISearchForAPatient(Table table)
        {
            var data = table.CreateInstance<PatientBrowserPageTableData>();
            string email = data.EmailID;
            string DOB = data.DOB;
            
            if(DOB==null)
            {
                patientBrowserPage.searchPatientWithEmail(email);                
            }
            else if(email==null)
            {
                patientBrowserPage.searchPatientWithDOB(DOB);
            }
            Thread.Sleep(3000);
            patientBrowserPage.SearchPatient();
            Thread.Sleep(3000);
        }


        [Then(@"The patient with following data is displayed on screen")]
        public void ThenThePatientWithFollowingDataIsDisplayedOnScreen(Table table)
        {
            var data = table.CreateInstance<PatientBrowserPageTableData>();
            string email = data.EmailID;
            string DOB = data.DOB;


            if (DOB==null)
            {
                bool status = patientBrowserPage.isEmailPresent(email);
                Assert.IsTrue(status, $"Patient with email id : {email} is not present");
                ReporterClass.AddStepLog($"Patient with email id : {email} is present");
            }
            else if (email==null)
            {
                bool status = patientBrowserPage.isDOBPresent(DOB);
                Assert.IsTrue(status, $"Patient with dob  : {DOB} is not present");
                ReporterClass.AddStepLog($"Patient with dob  : {DOB} is present");
            }            

        }
        static string FName;

        [When(@"I search for the newly created patient by first name and last name")]
        public void WhenISearchForTheNewlyCreatedPatientByFirstNameAndLastName()
        {
            //patientBrowserPage.clickRecentlyAddedLink();
            //string FName = patientBrowserPage.GetNewlyAddedFirstName();
            //string LName = patientBrowserPage.GetNewlyAddedFirstName();

            //Console.WriteLine(patientBrowserPage.GetNewlyAddedFirstName());
            //patientBrowserPage.SwitchToMainWindow();
            patientBrowserPage.EnterDetailsToSearchExistingPatient(FirstName, LastName,string.Empty,string.Empty,string.Empty);
            patientBrowserPage.SearchPatient();
            Thread.Sleep(3000);

        }

        [Then(@"The patient data with first name and last name is displayed on screen")]
        public void ThenThePatientDataWithFirstNameAndLastNameIsDisplayedOnScreen()
        {
           Assert.True(patientBrowserPage.ValidateSearchResultFirstName(FirstName),"Patient First name is not showing in search");
           Assert.True(patientBrowserPage.ValidateSearchResultLastName(LastName), "Patient Last name is not showing in search");
            Thread.Sleep(2000);
        }

    }
}
