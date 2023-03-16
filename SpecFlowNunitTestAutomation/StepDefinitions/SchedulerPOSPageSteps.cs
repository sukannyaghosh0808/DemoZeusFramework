using Gherkin.CucumberMessages.Types;
using NPOI.OpenXmlFormats.Wordprocessing;
using NUnit.Framework;
using OpenQA.Selenium;
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
    public sealed class SchedulerPOSPageSteps
    {
        SchedulerPOSPage schedulerPage = new SchedulerPOSPage();
        PatientBrowserPage patientBrowserPage = new PatientBrowserPage();

        [Given(@"Check for slot availablity in MRS lane ""([^""]*)"" for today's date")]
        public void GivenCheckForSlotAvailablityInMRSLaneForTodaysDate(string p0)
        {
            Assert.IsTrue(schedulerPage.IsSlotAvailable(),"No slot is available");
            Thread.Sleep(3000);
        }


        [Given(@"I click on the first available slot")]
        public void GivenIClickOnTheFirstAvailableSlot()
        {
            schedulerPage.SelectAvailableSlot();
        }
        
        [Given(@"I search and open the ""([^""]*)"" patient created")]
        public void GivenISearchAndOpenThePatientCreated(string number)
        {
            if (number == "first")
            {                
                string FName = PatientCreateUtil.first_FirstName;
                string LName = PatientCreateUtil.first_LastName;
                ReporterClass.AddStepLog("First Name : " + FName);
                ReporterClass.AddStepLog("First Name : " + LName);
                patientBrowserPage.EnterDetailsToSearchExistingPatient(FName, LName, string.Empty, string.Empty, string.Empty);
            }
            else if(number == "second")
            {
                string FName = PatientCreateUtil.SecondPersonFName;
                string LName = PatientCreateUtil.SecondPersonLName;
                ReporterClass.AddStepLog("First Name : " + FName);
                ReporterClass.AddStepLog("First Name : " + LName);
                patientBrowserPage.EnterDetailsToSearchExistingPatient(FName, LName, string.Empty, string.Empty, string.Empty);
            }
            patientBrowserPage.SearchPatient();
            Thread.Sleep(2000);
            patientBrowserPage.DoubleClickOnSearchResult();
            Thread.Sleep(2000);
        }


        [Given(@"I provide the following appointment type for scheduling a slot")]
        public void GivenIProvideTheFollowingAppointmentTypeForSchedulingASlot(Table table)
        {
            var data = table.CreateInstance<SchedulerPOSPageTableData>();
            string appointmentType = data.AppointmentType;
            schedulerPage.SelectAppointmentType(appointmentType);
            ReporterClass.AddStepLog("Selecting Appointment Type as : "+ appointmentType);
        }


        [When(@"I click on confirmed button")]
        public void WhenIClickOnConfirmedButton()
        {
            schedulerPage.clickConfirmedButton();
        }


        [Then(@"The appointment is created and succesful message with appointment number is shown on screen")]
        public void ThenTheAppointmentIsCreatedAndSuccesfulMessageWithAppointmentNumberIsShownOnScreen()
        {
            if (patientBrowserPage.GetToastMessage().Contains("Appointment added successfully with reference #"))
            {
                ReporterClass.AddStepLog("Appointment Booking ID : " + patientBrowserPage.GetToastMessage());
            }
            else
            {
                Assert.Fail("Appointment booking is not successful! please try again");
            }
        }

        [When(@"I right click and select ""([^""]*)"" on an existing appointment for the ""([^""]*)"" patient created")]
        public void WhenIRightClickAndSelectOnAnExistingAppointmentForThePatientCreated(string action, string number)
        {
            if(number == "first")
            {
                string FName = PatientCreateUtil.first_FirstName;
                string LName = PatientCreateUtil.first_LastName;
                ReporterClass.AddStepLog("First Name : " + FName);
                ReporterClass.AddStepLog("First Name : " + LName);
                schedulerPage.RightClickOnExistingAppointment(FName, LName);
            }
            else if( number == "second")
            {
                string FName = PatientCreateUtil.SecondPersonFName;
                string LName = PatientCreateUtil.SecondPersonLName;
                ReporterClass.AddStepLog("First Name : " + FName);
                ReporterClass.AddStepLog("First Name : " + LName);
                schedulerPage.RightClickOnExistingAppointment(FName, LName);
            }
            Thread.Sleep(3000);
            if(action == "Cut")
            {
                schedulerPage.CutAppointment();
            }
            else if(action == "Double Book")
            {
                schedulerPage.DoubleBookAppointment();
            }
            Thread.Sleep(2000);
        }


        [Then(@"A modal window should appear with the message ""([^""]*)""")]
        public void ThenAModalWindowShouldAppearWithTheMessage(string message)
        {
            Assert.AreEqual(message, schedulerPage.GetDoubleBookingConfirmationMessage(),"Modal Window is not displaying correct message....");
        }



        [Given(@"I confirm that I want to add another appointment in the same timeslot for a different patient")]
        public void GivenIConfirmThatIWantToAddAnotherAppointmentInTheSameTimeslotForADifferentPatient()
        {
            schedulerPage.ConfirmDoubleBooking();
        }



        [Then(@"A cross icon should show on the appointment for the ""([^""]*)"" patient created")]
        public void ThenACrossIconShouldShowOnTheAppointmentForThePatientCreated(string number)
        {
            if (number == "first")
            {
                string FName_first = PatientCreateUtil.first_FirstName;
                string LName_first = PatientCreateUtil.first_LastName;
                ReporterClass.AddStepLog("First Name : " + FName_first);
                ReporterClass.AddStepLog("First Name : " + LName_first);
                // schedulerPage.RightClickOnExistingAppointment(FName, LName);
                Thread.Sleep(4000);
                if(schedulerPage.IsIconLoaderDisappeared() == true)
                {
                    Assert.True(schedulerPage.IsCrossIconPresent(FName_first, LName_first), "Cross Icon is not visible");
                }
                ReporterClass.AddStepLog("The Cross Icon after Cut is present on the appointment");
            }
            else if (number == "second")
            {
                string FName_second = PatientCreateUtil.SecondPersonFName;
                string LName_second = PatientCreateUtil.SecondPersonLName;
                ReporterClass.AddStepLog("First Name : " + FName_second);
                ReporterClass.AddStepLog("First Name : " + LName_second);
                schedulerPage.RightClickOnExistingAppointment(FName_second, LName_second);
            }            
            //Thread.Sleep(3000);
        }



        [When(@"I right click on the next available slot in MRS lane ""([^""]*)"" and select ""([^""]*)""")]
        public void WhenIRightClickOnTheNextAvailableSlotInMRSLaneAndSelect(string lane, string paste)
        {
            schedulerPage.rightClickOnAvailableSlot();
            Thread.Sleep(2000);
            schedulerPage.PasteAppointment();
            Thread.Sleep(2000);
        }



        [Then(@"Appointment details updated success message should appear")]
        public void ThenAppointmentDetailsUpdatedSuccessMessageShouldAppear()
        {
            Assert.True(schedulerPage.GetToastMessage());
            ReporterClass.AddStepLog("Appointment details updated success message is appearing...");
        }



        [When(@"I drag the existing appointment and drop in the next available slot in MRS lane ""([^""]*)"" for the ""([^""]*)"" patient created")]
        public void WhenIDragTheExistingAppointmentAndDropInTheNextAvailableSlotInMRSLaneForThePatientCreated(string p0, string first)
        {
            string FName = PatientCreateUtil.first_FirstName;
            string LName = PatientCreateUtil.first_LastName;
            schedulerPage.dragAndDropElement(FName, LName);
        }


        [When(@"I right click on an existing appointment for the ""([^""]*)"" patient created")]
        public void WhenIRightClickOnAnExistingAppointmentForThePatientCreated(string number)
        {
            if(number == "first")
            {
                string FName = PatientCreateUtil.first_FirstName;
                string LName = PatientCreateUtil.first_LastName;
                schedulerPage.RightClickOnExistingAppointment(FName, LName);
                schedulerPage.MouseHoverOnDoubleBookOption();
            }           
        }


        [Then(@"Verify the following options are present in the context menu")]
        public void ThenVerifyTheFollowingOptionsArePresentInTheContextMenu(Table table)
        {
            var data = table.CreateSet<SchedulerPOSPageTableData>();
            List<string> options = new List<string>();            
            foreach(var a in data )
            {
                options.Add(a.RightClickMenuItems);
            }
            IList<string> all = schedulerPage.GetAllElementsFromContextMenu();
            bool isEqual = Enumerable.SequenceEqual(options.OrderBy(e => e), all.OrderBy(e => e));
            if (isEqual)
            {
                ReporterClass.AddStepLog("All options are present in context menu");
            }
            else
            {
                Assert.Fail("All options are not present");
                ReporterClass.AddFailedStepLog("All options are not present in context menu");
            }
        }
    }
}