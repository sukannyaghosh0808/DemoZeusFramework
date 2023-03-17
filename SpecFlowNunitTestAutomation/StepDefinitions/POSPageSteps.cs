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
    class POSPageSteps
    {
        SchedulerPOSPage posPage = new SchedulerPOSPage();
        PatientBrowserPage patientBrowserPage = new PatientBrowserPage();


        [Given(@"Check for slot availablity in MRS lane ""([^""]*)"" for today's date")]
        public void GivenCheckForSlotAvailablityInMRSLaneForTodaysDate(string lane)
        {
            Assert.True(posPage.IsSlotAvailable(), "No slot is available");
        }



        [Given(@"I click on the first available slot")]
        public void GivenIClickOnTheFirstAvailableSlot()
        {
            posPage.clickOnFirstAvailableSlot();
            ReporterClass.AddStepLog("Clicking on first available slot");
            Thread.Sleep(3000);
        }


        [Given(@"I search and open the ""([^""]*)"" patient created")]
        public void GivenISearchAndOpenThePatientCreated(string number)
        {
            if(number == "first")
            {
                patientBrowserPage.EnterDetailsToSearchExistingPatient(PatientCreateUtil.first_FirstName,PatientCreateUtil.first_LastName, string.Empty, string.Empty, string.Empty);
                ReporterClass.AddStepLog("First Name : " + PatientCreateUtil.first_FirstName);
                ReporterClass.AddStepLog("First Name : " + PatientCreateUtil.first_LastName);

            }
            else
            {
                patientBrowserPage.EnterDetailsToSearchExistingPatient(PatientCreateUtil.SecondPersonFName, PatientCreateUtil.SecondPersonLName, string.Empty, string.Empty, string.Empty);
                ReporterClass.AddStepLog("First Name : " + PatientCreateUtil.SecondPersonFName);
                ReporterClass.AddStepLog("First Name : " + PatientCreateUtil.SecondPersonLName);

            }
            patientBrowserPage.SearchPatient();            
            patientBrowserPage.DoubleClickOnSearchResult();
            Thread.Sleep(2000);
        }


        [Given(@"I provide the following appointment type for scheduling a slot")]
        public void GivenIProvideTheFollowingAppointmentTypeForSchedulingASlot(Table table)
        {
            var data = table.CreateInstance<SchedulerPOSPageTableData>();
            string appointmentType = data.AppointmentType;
            posPage.SelectAppointmentType(appointmentType);
            ReporterClass.AddStepLog("Selecting Appointment Type as : " + appointmentType);
        }


        [When(@"I click on confirmed button")]
        public void WhenIClickOnConfirmedButton()
        {
            posPage.clickConfirmedButton();
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
            if (number == "first")
            {
                string FName = PatientCreateUtil.first_FirstName;
                string LName = PatientCreateUtil.first_LastName;

                ReporterClass.AddStepLog("First Name : " + FName);
                ReporterClass.AddStepLog("First Name : " + LName);
                posPage.RightClickOnExistingAppointment(FName + " " + LName);
            }
            else if (number == "second")
            {
                string FName = PatientCreateUtil.SecondPersonFName;
                string LName = PatientCreateUtil.SecondPersonLName;
                ReporterClass.AddStepLog("First Name : " + FName);
                ReporterClass.AddStepLog("First Name : " + LName);
                posPage.RightClickOnExistingAppointment(FName + " " + LName);
            }
            Thread.Sleep(3000);
            if (action == "Cut")
            {
                posPage.CutAppointment();
                ReporterClass.AddStepLog("Select option : Cut");

            }
            else if (action == "Double Book")
            {
                posPage.DoubleBookAppointment();
                ReporterClass.AddStepLog("Select option : Double Book");
            }
            Thread.Sleep(2000);
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
                if (posPage.IsIconLoaderDisappeared() == true)
                {
                    Assert.True(posPage.IsCrossIconPresent(FName_first, LName_first), "Cross Icon is not visible");
                }
                ReporterClass.AddStepLog("The Cross Icon after Cut is present on the appointment");
            }
            else if (number == "second")
            {
                string FName_second = PatientCreateUtil.SecondPersonFName;
                string LName_second = PatientCreateUtil.SecondPersonLName;
                ReporterClass.AddStepLog("First Name : " + FName_second);
                ReporterClass.AddStepLog("First Name : " + LName_second);
                posPage.RightClickOnExistingAppointment(FName_second, LName_second);
            }
        }



        [When(@"I right click on the next available slot in MRS lane ""([^""]*)"" and select ""([^""]*)""")]
        public void WhenIRightClickOnTheNextAvailableSlotInMRSLaneAndSelect(string lane, string paste)
        {
            posPage.rightClickOnNextAvailableSlot();
            Thread.Sleep(2000);
            //posPage.clickOnFirstAvailableSlot();
            posPage.PasteAppointment();
            Thread.Sleep(2000);
        }


        [Then(@"Appointment details updated success message should appear")]
        public void ThenAppointmentDetailsUpdatedSuccessMessageShouldAppear()
        {
            Thread.Sleep(3000);
            Assert.True(posPage.ValidateToastMessage());
            ReporterClass.AddStepLog(posPage.getToastMessage());
            ReporterClass.AddStepLog("Appointment details updated success message is appearing...");
            Thread.Sleep(3000);
        }




        [When(@"I drag the existing appointment and drop in the next available slot in MRS lane ""([^""]*)"" for the ""([^""]*)"" patient created")]
        public void WhenIDragTheExistingAppointmentAndDropInTheNextAvailableSlotInMRSLaneForThePatientCreated(string p0, string first)
        {            
            posPage.DragAndDropOnNextSlot(PatientCreateUtil.first_FirstName,PatientCreateUtil.first_LastName);
        }



        [Then(@"A modal window should appear with the message ""([^""]*)""")]
        public void ThenAModalWindowShouldAppearWithTheMessage(string message)
        {
            Assert.AreEqual(message, posPage.GetDoubleBookingConfirmationMessage(), "Modal Window is not displaying correct message....");
        }


        [Given(@"I confirm that I want to add another appointment in the same timeslot for a different patient")]
        public void GivenIConfirmThatIWantToAddAnotherAppointmentInTheSameTimeslotForADifferentPatient()
        {
            posPage.ConfirmDoubleBooking();
            ReporterClass.AddStepLog("Double Booking Confirm");
        }



        [When(@"I right click on an existing appointment for the ""([^""]*)"" patient created")]
        public void WhenIRightClickOnAnExistingAppointmentForThePatientCreated(string number)
        {
            if (number == "first")
            {
                string FName = PatientCreateUtil.first_FirstName;
                string LName = PatientCreateUtil.first_LastName;
                posPage.RightClickOnExistingAppointment(FName, LName);
                posPage.MouseHoverOnDoubleBookOption();
            }
        }


        [Then(@"Verify the following options are present in the context menu")]
        public void ThenVerifyTheFollowingOptionsArePresentInTheContextMenu(Table table)
        {
            var data = table.CreateSet<SchedulerPOSPageTableData>();
            List<string> options = new List<string>();
            foreach (var a in data)
            {
                options.Add(a.RightClickMenuItems);
            }
            IList<string> all = posPage.GetAllElementsFromContextMenu();
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
