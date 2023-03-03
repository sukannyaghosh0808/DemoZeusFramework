Feature: 09_Patient Browser Page
Different test scenarios for Patient Browser Page

Background:
	Given Launch the Zeus application
	And I login to the Zeus application with valid credentials
	When I click on distribution center change button
	And I select a store randomly
	Then The store should change to what was selected randomly

@TC_Zeus_PB_0001 @PositiveTests
Scenario: Verify Patient Creation where all required fields are valid
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all required fields with valid data for patient creation
	    #All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	    #Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button and skip address verification
	Then Patient should be created and successful message "Patient added in Zeus and queued to create in MRS" should show on screen

@TC_Zeus_PB_0002 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except firstname
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all the required fields with valid data except First Name
	    #All required fields are: Invalid First Name, Valid Last Name, Valid Email, 
	    #Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button
	Then Patient should not be created and error message "First Name should contain alphabets only." should show on screen

@TC_Zeus_PB_0003 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except lastname
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all the required fields with valid data except Last Name
	    #All required fields are: Valid First Name, Invalid Last Name, Valid Email, 
	    #Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button
	Then Patient should not be created and error message "Last Name should contain alphabets only." should show on screen

@TC_Zeus_PB_0004 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except email
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all the required fields with valid data except email
	    #All required fields are: Valid First Name, Valid Last Name, Invalid Email, 
	    #Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button
	Then Patient should not be created and error message "Email address is invalid" should show on screen

@TC_Zeus_PB_0005 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except DOB
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all the required fields with valid data except DOB
	    #All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	    #Invalid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button
	Then Patient should not be created and error message "The field Date Of Birth must be a date." should show on screen

@TC_Zeus_PB_0006 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except Address
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all the required fields with valid data except Address
	    #All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	    #Valid Date of Birth, Valid Phone Number, Valid Gender, Invalid Address Line 1, Valid Zip Code
	And I click on create button
	Then Patient should not be created and error message "Address1 length cannot exceed 350 characters." should show on screen

@TC_Zeus_PB_0007 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except Phone Number
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all the required fields with valid data except Phone Number
	    #All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	    #Valid Date of Birth, Invalid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button
	Then Patient should not be created and validation message "Phone number should contain exact 10 digits" should show on screen

@TC_Zeus_PB_0008 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except phone number is all registered with another patient
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all required fields with valid data for patient creation
	And I click on create button and skip address verification
	Then Patient should be created and successful message "Patient added" should show on screen
	     #Create another patient with the same phone number that was created in the above steps
	When I click on create new patient button
	And I provide all the required fields with valid data except a phone number that is already registered with another patient
	    #All required fields are: Valid First Name, Valid Last Name, Invalid Email, 
	    #Valid Date of Birth, Valid Phone Number that is already registered with another patient, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button and skip address verification
	Then A confirmation popup gets prompted to the user to continue with the existing phone number

@TC_Zeus_PB_0009 @NegativeTests
Scenario: Verify Patient Creation where all required fields are valid except ZipCode
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	#Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all the required fields with valid data except ZipCode
	#All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	#Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Invalid Zip Code
	And I click on create button
	Then Patient should not be created and error message "ZipCode is a required field" should show on screen

@TC_Zeus_PB_0010 @NegativeTests
Scenario: Verify Patient Creation when the patient is already registered
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all required fields with valid data for patient creation
	And I click on create button and skip address verification
	Then Patient should be created and successful message "Patient added" should show on screen
	#Create another patient with the set of data that was created in the above steps
	#Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all required fields with valid data that is already used for patient creation
	#All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	#Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button
	Then Patient should not be created and validation message "Patient with same details (First Name, DOB, and Phone No.) already exist" should show on screen

@TC_Zeus_PB_0011 @PositiveTests
Scenario: Verify Patient Creation where First Name, Middle Name and Last name have whitespaces at the begining
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	#Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all required fields with valid data for patient creation with leading whitespaces
	#All required fields are: whitespaces_First Name, whitespaces_Middle Name, whitespaces_Last Name, Valid Email, 
	#Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button and skip address verification
	Then Patient should be created and successful message "Patient added" should show on screen

@TC_Zeus_PB_0012 @PositiveTests
Scenario: Search patient by first name and last name
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all required fields with valid data for patient creation
	    #All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	    #Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button and skip address verification
	Then Patient should be created and successful message "Patient added" should show on screen
	When I search for the newly created patient by first name and last name
	Then The patient data with first name and last name is displayed on screen

@TC_Zeus_PB_0013 @PositiveTests
Scenario: Search patient by email
	Given I open patient browser page
	When I search for a patient
		| EmailID                 |
		| xarroliga@nowoptics.com |
	Then The patient with following data is displayed on screen
		| EmailID                 |
		| xarroliga@nowoptics.com |

@TC_Zeus_PB_0014 @PositiveTests
Scenario: Search patient by dob
	Given I open patient browser page
	When I search for a patient
		| DOB        |
		| 09/30/1996 |
	Then The patient with following data is displayed on screen
		| DOB        |
		| 09/30/1996 |

@TC_Zeus_PB_0015 @PositiveTests
Scenario: Search patient by phone number
	Given I open patient browser page
	When I search for a patient with "PhoneNumber"
	Then The patient with correct "PhoneNumber" is displayed on screen

@TC_Zeus_PB_0016 @PositiveTests
Scenario: Check recently added link
	Given I open patient browser page
	And Patient is not created already with the set of data provided
	    #Using First Name, Last Name, Phone Number, Date Of Birth and Email
	When I click on create new patient button
	And I provide all required fields with valid data for patient creation
	    #All required fields are: Valid First Name, Valid Last Name, Valid Email, 
	    #Valid Date of Birth, Valid Phone Number, Valid Gender, Valid Address Line 1, Valid Zip Code
	And I click on create button and skip address verification
	Then Patient should be created and successful message "Patient added" should show on screen
	And Recently added link should be visible
	When I click the recently added link
	Then Patient profile data is displayed on screen