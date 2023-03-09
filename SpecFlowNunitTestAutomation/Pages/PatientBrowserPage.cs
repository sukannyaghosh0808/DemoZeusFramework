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
        private static By firstnameOnSearchPage = By.Id("FirstName");
        private static By firstname = By.XPath("//*[@class='form-control input-group'][@id='FirstName']");
        private static By lastname = By.XPath("//*[@class='control-label required col-md-4']//following-sibling::input[@name='LastName']");
        private static By middlename = By.XPath("//*[@id='MiddleName']");
        private static By lastnameOnSearchPage = By.Id("LastName");
        private static By Phone = By.Id("txtPhoneNumber");
        private static By EmailOnSearchPage = By.XPath("//*[@id='Email']");
        private static By Email = By.XPath("//*[@id='EmailAddress']");
        private static By DateOfBirth = By.XPath("//*[@id='patientDOB']");
        private static By DOBonSearchPage = By.XPath("//*[@id='inputPatientDOBSearch']");
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
        //private static By ToastMessage = By.XPath("//*[@id='toast-container']/div/div");
        private static By ToastMessage = By.XPath("//*[@class='toast-message']");
        private static By SmsNotificationCheckBox = By.XPath("//*[@id='IsAllowedToGetSmsNotification']");
        private static By CreateBtn = By.XPath("//*[@class='btn btn-primary pull-right'][text()='Create']");
        private static By PhoneNumberConfMessage = By.XPath("//*[@class='jconfirm-content']");
        private static By PatientNameAfterSearch = By.XPath("//*[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr/td[4]");
        private static By RecentlyAdded = By.XPath("//*[@id='recentlyAddedLink']");
        private static By SearchResultFirstRowEmail = By.XPath("//*[@id='searchResult']/child::div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[1]/child::td[6]");
        private static By SearchResultFirstRowDOB = By.XPath("//*[@id='searchResult']/child::div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[1]/child::td[5]");
        private static By SearchResultFirstName = By.XPath("//*[@id='searchResult']/child::div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[1]/child::td[4]");
        private static By SearchResultLastName = By.XPath("//*[@id='searchResult']/child::div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[1]/child::td[3]");
        private static By citymenu = By.XPath("//*[@class='form-control none valid']");
        private static By SearchResultViewFile = By.XPath("//*[@id='searchResult']/child::div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[1]/child::td[12]/a");
        private static By PaperCaptureTab = By.XPath("//*[text()='Paper Capture']");
        private static By PaperCaptureUploadBtn = By.XPath("//*[@id='btnUploadFile']");
        private static By PaperCaptureScanIcon= By.XPath("//*[@id='btnScanDocument']");
        private static By PaperCaptureSelectIcon = By.XPath("//*[@id='btnFileExplorer']/child::i");
        private static By PaperCaptureCategory = By.XPath("//*[@id='CategoryId']");
        private static By PaperCaptureSubCategory = By.XPath("//*[@id='SubCategoryId']");
        private static By PaperCaptureTitle = By.XPath("//*[@id='inputTitle']");
        private static By PaperCaptureAddButton = By.XPath("//*[@id='btnSubmitAddForm']");
        private static By PaperCaptureLastAddedFileViewLink = By.XPath("//*[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[1]/child::td[9]/a");
        private static By PaperCaptureImage = By.XPath("//*[@id='divFilePreviewContent']/child::div[2]/img");
        private static By PaperCaptureEditButton = By.XPath("//*[@id='editPaperCapture']");
        private static By PaperCaptureUpdateButton = By.XPath("//*[@id='btnSubmitUpdateForm']");
        private static By PaperCaptureCloseButton = By.XPath("//*[@id='btnPatientFileModalClose']/child::span");
        private static By PaperCaptureDeleteButton = By.XPath("//*[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[1]/child::td[11]/child::a/child::i");        
        private static By PaperCaptureDeleteConfirmButton = By.XPath("//*[@class='jconfirm-buttons']/button[text()='confirm']");        
        private static By PaperCaptureExistingFile = By.XPath("//*[@name='ScannedFile'][1]");
        private static By PaperCaptureSelectButton = By.XPath("//*[@id='btnSelectFile']");


        public void EnterPatientDetailsToCreateNew(string fname,string lname,string email,string DOB,string address,string zipcode,string gender,string phoneType,string isd,string phNumber)
        {
            //aentering all mandatory fields
            //entering firstname
            ClearAndSendValue(firstname, "firstname", fname);
            //entering address line 1           
            ClearAndSendValue(AddressLine1, "address", address);
            //last name
            ClearAndSendValue(lastname, "lastname", lname);
            //entering email
            ClearAndSendValue(Email, "email", email);
            //skip email check
            //ClickElement(ContinueWithoutEmail, "skip email");
            //date of birth
            ClearAndSendValue(DateOfBirth, "DateOfBirth", DOB);
            //zip code
            ClearAndSendValue(ZipCode, "zipcode", zipcode);
            //WaitForElementToBeVisible(citymenu, 5);
;            //gender
            SelectValueByValue(Gender, "gender", gender);
            //phone number
            SelectValueByValue(Phone_Type, "phone type", phoneType); //type
            SelectValueByValue(ISD, "ISD", isd);//isd
            ClearAndSendValue(PhoneNumber_createPatient, "phone",phNumber); //number

            //skip sms notification checkbox
            ClickElement(SmsNotificationCheckBox, "sms checkbox");

        }

        //override method for middlename
        public void EnterPatientDetailsToCreateNew(string fname, string mname,string lname, string email, string DOB, string address, string zipcode, string gender, string phoneType, string isd, string phNumber)
        {
            //aentering all mandatory fields
            //entering firstname
            ClearAndSendValue(firstname, "firstname", fname);
            ClearAndSendValue(middlename, "middlename", mname);
            //entering address line 1           
            ClearAndSendValue(AddressLine1, "address", address);
            //last name
            ClearAndSendValue(lastname, "lastname", lname);
            //entering email
            ClearAndSendValue(Email, "email", email);
            //skip email check
            //ClickElement(ContinueWithoutEmail, "skip email");
            //date of birth
            ClearAndSendValue(DateOfBirth, "DateOfBirth", DOB);
            //zip code
            ClearAndSendValue(ZipCode, "zipcode", zipcode);
            //Thread.Sleep(3000);
            //gender
            SelectValueByValue(Gender, "gender", gender);
            
            //phone number
            SelectValueByValue(Phone_Type, "phone type", phoneType); //type
            SelectValueByValue(ISD, "ISD", isd);//isd
            ClearAndSendValue(PhoneNumber_createPatient, "phone", phNumber); //number
            //skip sms notification checkbox
            ClickElement(SmsNotificationCheckBox, "sms checkbox");

        }


        public void clickContinueWithoutEmail()
        {
            ClickElement(ContinueWithoutEmail, "skip email");
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
            WaitUntillElementToBeVisible(ToastMessage, 15);
            return GetTextValue(ToastMessage, "Toast Message");
            
        }

        public void ClickCreate()
        {
            ScrollToElement(CreateBtn, "Create Patient");
            ClickElement(CreateBtn, "Create");
        }

        public void EnterDetailsToSearchExistingPatient(string _firstName, string _lastName, string _phoneNumber, string _dateOfBirth, string _emailID)
        {
            //Using First Name, Last Name, Phone Number, Date Of Birth and Email
            /*SendValue(firstnameOnSearchPage, "FirstName", _firstName);
            SendValue(lastnameOnSearchPage, "Last Name", _lastName);
            SendValue(Phone, "Phone", _phoneNumber);
            SendValue(DOBonSearchPage, "DOB", _dateOfBirth);
            SendValue(EmailOnSearchPage, "Email", _emailID); */

            ClearAndSendValue(firstnameOnSearchPage, "FirstName", _firstName);
            ClearAndSendValue(lastnameOnSearchPage, "Last Name", _lastName);
            ClearAndSendValue(Phone, "Phone", _phoneNumber);
            ClearAndSendValue(DOBonSearchPage, "DOB", _dateOfBirth);
            ClearAndSendValue(EmailOnSearchPage, "Email", _emailID);
        }

        public void DeleteFirstName()
        {
            ClearText(firstname, "Firstname");
        }

        public bool ValidatePhoneWaringMessage(string number)
        {
            string popup = GetTextValue(PhoneNumberConfMessage, "confirmation msg");
            if (popup.Contains(number))
                return true;
            else
                return false;

        }

        public void searchPatientWithPhone(string _phoneNumber)
        {
            SendValue(Phone, "phone", _phoneNumber);
        }

        public string getPatientNameAfterSearch()
        {
            return GetTextValue(PatientNameAfterSearch,"Patient name");
        }

        public bool ValidateRecentlyAddedLink()
        {
            return IsEelementExist(RecentlyAdded, 30);
        }

        
        public void clickRecentlyAddedLink()
        {
            ClickElement(RecentlyAdded,"Recently added");
            SwitchWindow();
        }

        public bool ValidatePatientFileLink()
        {
            //SwitchWindow();
            if (GetPageURL().Contains("PatientFile"))
                return true;
            else
                return false;
        }

        public void searchPatientWithEmail(string email)
        {
            SendValue(EmailOnSearchPage, "Email", email);
        }

        public bool isEmailPresent(string email)
        {
            string actual = GetTextValue(SearchResultFirstRowEmail," ");
            if (actual == email)
                return true;
            else
                return false;
        }

        public bool isDOBPresent(string dob)
        {
            string actual = GetTextValue(SearchResultFirstRowDOB, " ");
            if (actual == dob)
                return true;
            else
                return false;
        }

        public void searchPatientWithDOB(string dob)
        {
            SendValue(DOBonSearchPage, "dob", dob);
        }

        public string GetNewlyAddedFirstName()
        {
           // SwitchWindow();
            return GetTextValue(firstname,"first name");
        }
        public string GetNewlyAddedLastName()
        {
            //SwitchWindow();
            return GetTextValue(lastname, "last name");
        }

        public bool ValidateSearchResultFirstName(string name)
        {
            if (name == GetTextValue(SearchResultFirstName, "first name"))
                return true;
            else
                return false;
        }
        public bool ValidateSearchResultLastName(string name)
        {
            if (name == GetTextValue(SearchResultLastName, "last name"))
                return true;
            else
                return false;
        }

        public void ViewFileForFirstPatient()
        {
            ClickElement(SearchResultViewFile, "view file");   
        }

        public void GoToPatientBrowserTab()
        {
            SwitchWindow();
            ClickElement(PaperCaptureTab, "paper capture tab");
        }

        public void ClickUploadButton()
        {
            ClickElement(PaperCaptureUploadBtn,"Upload button");
        }

        public void ClickScanIcon()
        {
            ClickElement(PaperCaptureScanIcon,"scan icon");
        }

        public void UploadExternalFile(string path)
        {
            //UploadFileUsingRobotClass(path);
            UploadFileUsingAutoIT(path);
        }

        public void selectCategory(string category)
        {
            SelectValueByVisibleText(PaperCaptureCategory, "category", category);
        }
        public void selectSubCategory(string subcategory)
        {
            SelectValueByVisibleText(PaperCaptureSubCategory,"category", subcategory);
        }

        public void EnterpaperCaptureTitle(string title)
        {
            ClearAndSendValue(PaperCaptureTitle, "title", title);
        }
        public void ClickAddPaperCaptureButton()
        {
            ClickElement(PaperCaptureAddButton, "add button");
        }

        public void ClickPaperCaptureViewLink()
        {
            ClickElement(PaperCaptureLastAddedFileViewLink, "view link");
        }

        public bool? IsNewlyAdedPaperCaptureIsPresent()
        {
            return IsElementDisplayed(PaperCaptureImage);
        }

        public void ClickpaperCaptureEditButton()
        {
            ClickElement(PaperCaptureEditButton, "edit");
        }

        public void ClickUpdateButton()
        {
            ClickElement(PaperCaptureUpdateButton, "update");
        }

        public void ClosePaperCaptureFile()
        {
            ClickElement(PaperCaptureCloseButton, "close");
        }

        public void DeletePaperCapture()
        {
            ClickElement(PaperCaptureDeleteButton, "delete");
        }

        public void ConfirmDelete()
        {
            ClickElement(PaperCaptureDeleteConfirmButton, "confirm delete");
        }

        public void ClickPaperCaptureSelectIcon()
        {
            ClickElement(PaperCaptureSelectIcon, "paper capture select icon");
        }

        public void SelectExistingFile()
        {
            ClickElement(PaperCaptureExistingFile, "existing paper capture file");
        }
        public void PaperCaptureExistingFileSelectButton()
        {
            ClickElement(PaperCaptureSelectButton, "select paper capture button");
        }
    }

}
