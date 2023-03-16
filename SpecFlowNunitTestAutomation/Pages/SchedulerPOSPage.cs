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
        private static By NewAppointmentWindow = By.XPath("//*[@id='divModal']");
        private static By AppointmentType = By.XPath("//*[@id='appointmentReasons']");
        private static By ConfirmedButton = By.XPath("//*[@id='saveAppointmentData']");
        private static By SearcHPatientTab = By.XPath("//*[@id='panelPatientDetailsTab']");
        private static By AppointmentDuration = By.XPath("//*[@id='appointmentDuration']");
        private static By SearcHPatientTabCloseButton = By.XPath("//*[@id='divModal']/div/div/div/div/div/button");
        private static By ExistingAppointment(string fname,string lname) => By.XPath("//*[text()='" +fname+" "+lname+"']");
        private static By CutAppointmentOption = By.XPath("//*[@id='cutAppointment']");
        private static By DoubleBookAppointmentOption = By.XPath("//*[@id='doubleBookAppointment']");
        private static By DoubleBookConfirmationMessage = By.XPath("//*[@class='jconfirm-content-pane']");
        private static By DoubleBookConfirmButton = By.XPath("//*[@class='jconfirm-buttons']/button[text()='confirm']");
        private static By AllAppointments = By.XPath("//*[@class='k-event appointment-event']");
        private static By LensExamAppointments = By.XPath("//*[@class='k-event k-event-inverse appointment-event']");
        private static By ChangeStatusOption = By.XPath("//*[@id='changeStatus']");
        private static By ChangeStatusCancelled = By.XPath("//*[text()='Cancelled']");
        private static By CrossIcon(string aptname) => By.XPath("//*[text()='"+aptname+ "']/parent::div[@class='k-event appointment-event k-state-selected cross']");
        private static By Paste = By.XPath("//*[@id='pasteAppointment']");
        private static By ContextMenu = By.XPath("//*[@id='contextMenu']/li");
        private static By ToastMessage = By.XPath("//*[@id='toast-container']");
        private static By LoaderIcon = By.XPath("//*[@id='loaderWrapper']");


        public bool IsSlotAvailable()
        {
            bool flag = false;
            if(GetElementsVisibilityStatus(MRS4_Row_available_slots,SearcHPatientTabCloseButton,AppointmentDuration, SearcHPatientTab) ==true)
            { 
                flag = true;
            }
            return flag;
            Thread.Sleep(5000);
             
        }


        public void rightClickOnAvailableSlot()
        {
            RightClickOnVisibleElement(MRS4_Row_available_slots, SearcHPatientTabCloseButton, AppointmentDuration, SearcHPatientTab);
            Thread.Sleep(5000);
        }
        public void SelectAvailableSlot()
        {
            DoubleClickOnVisibleElement(MRS4_Row_available_slots, SearcHPatientTabCloseButton, AppointmentDuration);
            Thread.Sleep(5000);
        }

        public void SelectAppointmentType(string appointmentType)
        {
            SelectValueByVisibleText(AppointmentType,"appointment type", appointmentType);
        }

        public void clickConfirmedButton()
        {
            ClickElement(ConfirmedButton, "Confirmed Button");
        }

        public void RightClickOnExistingAppointment(string fName, string lName)
        {
            Thread.Sleep(3000);
            ClickElement(ExistingAppointment(fName, lName), "existing appointment");
            Thread.Sleep(2000);
            RightClick(ExistingAppointment(fName,lName), "existing appointment");

        }

        public void CutAppointment()
        {
            ClickElement(CutAppointmentOption, "Cut");
        }

        public void DoubleBookAppointment()
        {
            ClickElement(DoubleBookAppointmentOption, "Double Book");
        }

        public string GetDoubleBookingConfirmationMessage()
        {
            string msg = GetTextValue(DoubleBookConfirmationMessage, "Double booking confirmation message");
            return msg;
        }

        public void ConfirmDoubleBooking()
        {
            ClickElement(DoubleBookConfirmButton, "confirm button");
        }

        public void deleteAllAppointments()
        {            
            try
            {
                DeleteExistingElement(AllAppointments, ChangeStatusOption, ChangeStatusCancelled);
            }
            catch
            {
                Console.WriteLine("No appointments is booked for today!");
            }
        }

        public void DeleteContactLensExam()
        {
            try
            {
                DeleteExistingElement(LensExamAppointments, ChangeStatusOption, ChangeStatusCancelled);
            }
            
            catch
            {
                Console.WriteLine("No appointments is booked for today!");
            }
            
        }

        public bool IsCrossIconPresent(string fname,string lname)
        {
            string aptName = fname + " " + lname;            
            Thread.Sleep(1000);
            return IsElementDisplayed(CrossIcon(aptName));
        }

        public void PasteAppointment()
        {
            ClickElement(Paste, "paste");
        }

        
        public void refresh()
        {
            RefreshPage();
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
            MouseHoverOnElement(DoubleBookAppointmentOption);
        }

        public bool GetToastMessage()
        {
            WaitUntillElementToBeVisible(ToastMessage, 15);
            //string msg = GetTextValue(ToastMessage, "Toast Message");
            return IsElementDisplayed(ToastMessage);

        }

        public void dragAndDropElement(string fName, string lName)
        {
            // source = findelement with fname lname
            // destination = next available slot
            DragAndDropOnNextSlot(MRS4_Row_available_slots,SearcHPatientTabCloseButton,AppointmentDuration,SearcHPatientTab,ExistingAppointment(fName, lName));

        }

        public bool IsIconLoaderDisappeared()
        {
            return IsElementInVisible(LoaderIcon,15);
        }
        
    }

    





}
