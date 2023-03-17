using OpenQA.Selenium;
using SpecFlowNunitTestAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNunitTestAutomation.Pages
{
    class SchedulerPOSPage : CommonActionsUtils
    {
        private static By MRS2 = By.XPath("//*[@id='comboBox_taglist']/child::li/span[text()='MRS ( 2 )']");
        private static By MRS5 = By.XPath("//*[@id='comboBox_taglist']/child::li/span[text()='Non-Exam ( 5 )']");
        private static By MRS4_Row_available_slots = By.XPath("//*[@class='k-scheduler-layout k-scheduler-dayview k-scrollbar-v']/child::tbody/child::tr[2]/child::td[2]/child::div/child::table/child::tbody/tr/td[2][@class='k-today']");
        private static By MRS4_Row_available_slot = By.XPath("(//*[contains(@class,'k-middle-row')]/child::td[2])[@class='k-today']");
        private static By SelectedSlot = By.XPath("//*[@class='k-today k-state-selected']");

        private static By MRS4_Row_Second_available_slot = By.XPath("(//*[@class='k-scheduler-layout k-scheduler-dayview k-scrollbar-v']/child::tbody/child::tr[2]/child::td[2]/child::div/child::table/child::tbody/tr/td[2][@class='k-today'])[1]");

        private static By NewAppointmentWindow = By.XPath("//*[@id='divModal']");
        private static By AppointmentType = By.XPath("//*[@id='appointmentReasons']");
        private static By ConfirmedButton = By.XPath("//*[@id='saveAppointmentData']");
        private static By SearcHPatientTab = By.XPath("//*[@id='panelPatientDetailsTab']");
        private static By AppointmentDuration = By.XPath("//*[@id='appointmentDuration']");
        private static By SearcHPatientTabCloseButton = By.XPath("//*[@id='divModal']/div/div/div/div/div/button");
        private static By ExistingAppointment(string appointment_name) => By.XPath("//*[contains(text(),'"+appointment_name+"')]");
        private static By CutAppointmentOption = By.XPath("//*[@id='cutAppointment']");
        private static By DoubleBookAppointmentOption = By.XPath("//*[@id='doubleBookAppointment']");
        private static By DoubleBookConfirmationMessage = By.XPath("//*[@class='jconfirm-content-pane']");
        private static By DoubleBookConfirmButton = By.XPath("//*[@class='jconfirm-buttons']/button[text()='confirm']");
        private static By AllAppointments = By.XPath("//div[contains(@class,'k-event appointment-event')]//p");
        private static By AppointmentName(int index) => By.XPath("(//div[contains(@class,'k-event appointment-event')]//p)[" + index + "]");
        private static By LensExamAppointments = By.XPath("//*[@class='k-event k-event-inverse appointment-event']");
        private static By ChangeStatusOption = By.XPath("//*[@id='changeStatus']");
        private static By ChangeStatusCancelled = By.XPath("//*[text()='Cancelled']");
        private static By CrossIcon(string aptname) => By.XPath("//*[text()='"+aptname+ "']//parent::div[contains(@class,'cross')]");
        private static By Paste = By.XPath("//*[@id='pasteAppointment']");
        private static By ContextMenu = By.XPath("//*[@id='contextMenu']/li");
        private static By ToastMessage = By.XPath("//*[@id='toast-container']");
        private static By LoaderIcon = By.XPath("//*[@id='loaderWrapper']");

        public bool IsSlotAvailable()
        {
            WaitForElementToExist(MRS4_Row_available_slot, 20);
            return IsElementDisplayed(MRS4_Row_available_slot);
        }

        public void clickOnFirstAvailableSlot()
        {
            Thread.Sleep(3000);
            try
            {
                ClickElement(MRS4_Row_available_slot, " ");
            }
            finally
            {
                ClickElementUsingJS(MRS4_Row_available_slot, "First Slot");
            }
            
            ClickElement(MRS4_Row_available_slot, " ");
            DoubleClick(SelectedSlot, "First Slot");
        }
        


        public void rightClickOnNextAvailableSlot()
        {
            ClickElement(MRS4_Row_available_slot, "Next available slot");
            RightClick(SelectedSlot, "Next available slot");           
        }
        public void SelectAvailableSlot()
        {
            DoubleClickOnVisibleElement(MRS4_Row_available_slots, SearcHPatientTabCloseButton, AppointmentDuration);
            Thread.Sleep(5000);
        }

        public void SelectAppointmentType(string appointmentType)
        {
            WaitForElementToExist(AppointmentType, 15);
            SelectValueByVisibleText(AppointmentType,"appointment type", appointmentType);
        }

        public void clickConfirmedButton()
        {
            WaitForElementToBeClickable(ConfirmedButton, 15);
            ClickElement(ConfirmedButton, "Confirmed Button");
        }

        public void RightClickOnExistingAppointment(string fName, string lName)
        {
            Thread.Sleep(3000);
            
            WaitForElementToBeClickable(ExistingAppointment(fName+" "+lName), 15);
            ClickElement(ExistingAppointment(fName+" "+lName), "existing appointment");
            Thread.Sleep(2000);
            RightClick(ExistingAppointment(fName+" "+lName), "existing appointment");

        }

        public void CutAppointment()
        {
            WaitForElementToBeClickable(CutAppointmentOption, 15);
            ClickElement(CutAppointmentOption, "Cut");
        }

        public void DoubleBookAppointment()
        {
            WaitForElementToBeClickable(DoubleBookAppointmentOption, 15);
            ClickElement(DoubleBookAppointmentOption, "Double Book");
        }

        public string GetDoubleBookingConfirmationMessage()
        {
            WaitForElementToExist(DoubleBookConfirmationMessage, 15);
            string msg = GetTextValue(DoubleBookConfirmationMessage, "Double booking confirmation message");
            return msg;
        }

        public void ConfirmDoubleBooking()
        {
            WaitForElementToBeClickable(DoubleBookConfirmButton, 15);
            ClickElement(DoubleBookConfirmButton, "confirm button");
        }

        public void deleteAllAppointments()
        {   
            WaitForElementToBeClickable(ChangeStatusOption, 15);
            ClickElement(ChangeStatusOption, "Change Status");
            WaitForElementToBeClickable(ChangeStatusCancelled, 20);
            ClickElement(ChangeStatusCancelled, "Cancelled");
        }

        
        public bool IsCrossIconPresent(string fname,string lname)
        {
            string aptName = fname + " " + lname;            
           // Thread.Sleep(1000);
            WaitForElementToExist(CrossIcon(aptName),25);
            return IsElementDisplayed(CrossIcon(aptName));
        }

        public void PasteAppointment()
        {
            WaitForElementToBeClickable(Paste, 15);
            ClickElement(Paste, "paste");
        }

        
        public IList<string> GetAllElementsFromContextMenu()
        {
            List<string> all = new List<string>();
            var contextItems = FindElements(ContextMenu);
            Thread.Sleep(2000);
            foreach( var i in contextItems)
            {
                all.Add(i.Text);
            }
            return all;
        }

        public void MouseHoverOnDoubleBookOption()
        {
            WaitForElementToBeVisible(DoubleBookAppointmentOption, 15);
            MouseHoverOnElement(DoubleBookAppointmentOption);
        }

        public bool ValidateToastMessage()
        {
            WaitUntillElementToBeVisible(ToastMessage, 35);
            return IsElementDisplayed(ToastMessage);            
        }

        public void dragAndDropElement(string fName, string lName)
        {
            // source = findelement with fname lname
            // destination = next available slot
            DragAndDropOnNextSlot(MRS4_Row_available_slots,SearcHPatientTabCloseButton,AppointmentDuration,SearcHPatientTab,ExistingAppointment(fName+ lName));

        }

        public bool IsIconLoaderDisappeared()
        {
            return IsElementInVisible(LoaderIcon,15);
        }

        public int getTotalNumOfAppointments()
        {
            int totalNumOfAppointments = FindElementCount(AllAppointments);
            return totalNumOfAppointments;
        }

        public string getAppointmentName(int index)
        {
            WaitForElementToBeVisible(AppointmentName(index), 25);
            ClickElement(AppointmentName(index), "Appointment name");
            string name = GetTextValue(AppointmentName(index), "Appointment name");
            return name;          
        }

        public void RightClickOnExistingAppointment(string appointmentName)
        {
            ClickElement(ExistingAppointment(appointmentName), "appointment");
            RightClick(ExistingAppointment(appointmentName), "appointment");
        }

        public string getToastMessage()
        {
            WaitForElementToExist(ToastMessage, 25);
            return GetTextValue(ToastMessage, "Toast Message");
        }

        public void DragAndDropOnNextSlot(string fname,string lname)
        {
            WaitForElementToBeClickable(MRS4_Row_available_slot, 25);
            ClickElement(MRS4_Row_available_slot, "available slot");
            WaitForElementToBeClickable(ExistingAppointment(fname + " " + lname), 25);
            DragAndDrop(ExistingAppointment(fname +" "+ lname),"existing appo", MRS4_Row_available_slot, "drag and drop");
        }
    }

    





}
