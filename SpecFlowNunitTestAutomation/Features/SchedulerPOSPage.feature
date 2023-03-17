Feature: 03_Scheduler POS Page
Different test scenarios for Scheduler POS Page

Background:
	Given Launch the Zeus application
	And I login to the Zeus application with valid credentials
	When I click on distribution center change button
	And I select a store named "5001 | Doctor - Mishawaka"
	Then The store should change to "5001 | Doctor - Mishawaka"
	Given I go to the Scheduler menu
	And I go to the POS menu
	And Delete any existing appointments

	@TC_Zeus_POS_0001 @PositiveTests
Scenario: Create an eye exam appointment on mrs lane in a corporate store
	Given Check for slot availablity in MRS lane "MRS ( 4 )" for today's date
	And I click on the first available slot
	And I search and open the "first" patient created
	And I provide the following appointment type for scheduling a slot
		| AppointmentType |
		| Eye Exam        |
	When I click on confirmed button
	Then The appointment is created and succesful message with appointment number is shown on screen


@TC_Zeus_POS_0002 @PositiveTests
Scenario: Create an eye exam appointment on mrs lane in a franchise store
#a franchise store range is between 7000 to 7999
	When I click on distribution center change button
	And I select a store named "0027 | Stanton Optical - Palm Springs"
	Then The store should change to "0027 | Stanton Optical - Palm Springs"
	Given I go to the Scheduler menu
	And I go to the POS menu
	And Delete any existing appointments
	And Check for slot availablity in MRS lane "MRS ( 4 )" for today's date
	And I click on the first available slot
	And I search and open the "first" patient created
	And I provide the following appointment type for scheduling a slot
		| AppointmentType |
		| Eye Exam        |
	When I click on confirmed button
	Then The appointment is created and succesful message with appointment number is shown on screen

@TC_Zeus_POS_0003 @PositiveTests
Scenario: Create double eye exam appointment in the same timeslot on mrs lane in a corporate store
	When I click on distribution center change button
	And I select a store named "5001 | Doctor - Mishawaka"
	Then The store should change to "5001 | Doctor - Mishawaka"
	Given I go to the Scheduler menu
	And I go to the POS menu
	And Delete any existing appointments
	When I click on distribution center change button
	And I select a store named "5001 | Doctor - Mishawaka"
	Then The store should change to "5001 | Doctor - Mishawaka"
	Given I go to the Scheduler menu
	And I go to the POS menu
	And Delete any existing appointments
	And Check for slot availablity in MRS lane "MRS ( 4 )" for today's date
	And I click on the first available slot
	And I search and open the "first" patient created
	And I provide the following appointment type for scheduling a slot
		| AppointmentType |
		| Eye Exam        |
	When I click on confirmed button
	Then The appointment is created and succesful message with appointment number is shown on screen
	When I right click and select "Double Book" on an existing appointment for the "first" patient created
	Then A modal window should appear with the message "Are you sure you want to add another appointment?"
	Given I confirm that I want to add another appointment in the same timeslot for a different patient
	And I search and open the "second" patient created
	And I provide the following appointment type for scheduling a slot
		| AppointmentType |
		| Eye Exam        |
	When I click on confirmed button
	Then The appointment is created and succesful message with appointment number is shown on screen

		
@TC_Zeus_POS_0004 @PositiveTests
Scenario: Cut and paste an eye exam appointment from one timeslot to another on mrs lane in a corporate store
	Given Check for slot availablity in MRS lane "MRS ( 4 )" for today's date
	And I click on the first available slot
	And I search and open the "first" patient created
	And I provide the following appointment type for scheduling a slot
		| AppointmentType |
		| Eye Exam        |
	When I click on confirmed button
	Then The appointment is created and succesful message with appointment number is shown on screen
	When I right click and select "Cut" on an existing appointment for the "first" patient created
	Then A cross icon should show on the appointment for the "first" patient created
	When I right click on the next available slot in MRS lane "MRS ( 4 )" and select "Paste"
	Then Appointment details updated success message should appear

@TC_Zeus_POS_0005 @PositiveTests
Scenario: Drag and drop an eye exam appointment from one timeslot to another on mrs lane in a corporate store
	Given Check for slot availablity in MRS lane "MRS ( 4 )" for today's date
	And I click on the first available slot
	And I search and open the "first" patient created
	And I provide the following appointment type for scheduling a slot
		| AppointmentType |
		| Eye Exam        |
	When I click on confirmed button
	Then The appointment is created and succesful message with appointment number is shown on screen
	When I drag the existing appointment and drop in the next available slot in MRS lane "MRS ( 4 )" for the "first" patient created
	Then Appointment details updated success message should appear

@TC_Zeus_POS_0006 @PositiveTests
Scenario: Right Click and validate all options on the created appointment
	Given Check for slot availablity in MRS lane "MRS ( 4 )" for today's date
	And I click on the first available slot
	And I search and open the "first" patient created
	And I provide the following appointment type for scheduling a slot
		| AppointmentType |
		| Eye Exam        |
	When I click on confirmed button
	Then The appointment is created and succesful message with appointment number is shown on screen
	When I right click on an existing appointment for the "first" patient created
	Then Verify the following options are present in the context menu
		| RightClickMenuItems |
		| Patient Details     |
		| Edit                |
		| Double Book         |
		| Cut                 |
		| Change Status       |
		| Create Order        |
		| Launch MRS          |
		| View Journals       |
		| Change Store        |
