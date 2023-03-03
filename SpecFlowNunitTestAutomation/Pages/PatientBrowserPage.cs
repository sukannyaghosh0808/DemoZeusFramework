using OpenQA.Selenium;
using SpecFlowNunitTestAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNunitTestAutomation.Pages
{
    class PatientBrowserPage : CommonActionsUtils
    {
        private static By firstname = By.Id("FirstName");       
        private static By lastname = By.XPath("//*[@class='control-label required col-md-4']//following-sibling::input[@name='LastName']");
        private static By Phone = By.Id("txtPhoneNumber");
        private static By Email = By.XPath("//*[@id='EmailAddress']");
        private static By DateOfBirth = By.XPath("//*[@id='patientDOB']");
        private static By SearchBtn = By.XPath("//*[@id='IsMerge']/following-sibling::div/button");
        private static By NoGridRecords = By.XPath("//*[@class='k-grid-norecords-template']");
        private static By CreateNew = By.Id("btnCreatePatient");
        private static By AddressLine1 = By.Id("Address1");
        private static By ZipCode = By.Id("txtSearchZipCode");
        private static By Gender = By.Id("GenderId");
        private static By Phone_Type = By.Id("TypeList");
        private static By ISD = By.Id("Phones_PhoneNumbers_0__CountryId");
        private static By Number = By.Id("GenderId");
        private static By PhoneNumber_createPatient = By.Id("Phones_number");
        private static By ContinueWithoutAddress = By.Id("SkipAddressVerification");
        private static By ContinueWithoutEmail = By.XPath("//*[@id='ckbSkipEmail']");
        private static By ToastMessage = By.XPath("//*[@id='toast-container']/div/div");
        private static By SmsNotificationCheckBox = By.XPath("//*[@id='IsAllowedToGetSmsNotification']");
        private static By CreateBtn = By.XPath("//*[@class='btn btn-primary pull-right'][text()='Create']");


        public void EnterPatientDetailsToCreateNew(string lname,string email,string DOB,string address,string zipcode,string gender,string phoneType,string isd,string phNumber)
        {
            //aentering all mandatory fields
            //entering address line 1 
            SendValue(AddressLine1, "address", address);
            //last name
            SendValue(lastname, "lastname", lname);
            //entering email
            SendValue(Email, "email", email);
            //skip email check
            ClickElement(ContinueWithoutEmail, "skip email");
            //date of birth
            SendValue(DateOfBirth, "DateOfBirth", DOB);
            //zip code
            SendValue(ZipCode, "zipcode", zipcode);
            //gender
            SelectValueByValue(Gender, "gender", gender);
            //phone number
            SelectValueByValue(Phone_Type, "phone type", phoneType); //type
            SelectValueByValue(ISD, "ISD", isd);//isd
            SendValue(PhoneNumber_createPatient, "phone",phNumber); //number

            //skip sms notification checkbox
            ClickElement(SmsNotificationCheckBox, "sms checkbox");

        }


        


        public void SearchPatient()
        {
            ClickElement(SearchBtn, "Search");
        }
        
        public bool ValidateIfPatientPresent()
        {
            if (GetTextValue(NoGridRecords, "grid records") == "There is no data on current page")
                return true;
            else
                return false;
        }

        public void ClickCreateNewButton()
        {
            ClickElement(CreateNew, "Create New");
        }
        public void ClickContinueWithoutAddress()
        {
            ClickElement(ContinueWithoutAddress, "continue without address");
        }
        

        public string GetToastMessage()
        {
            return GetTextValue(ToastMessage, "Toast Message");
            
        }

        public void SearchWithFirstname(string _firstName)
        {
            SendValue(firstname, "firstname",_firstName) ;
        }

        public void ClickCreate()
        {
            ScrollToElement(CreateBtn, "Create Patient");
            ClickElement(CreateBtn, "Create");
        }
        
    }
}
