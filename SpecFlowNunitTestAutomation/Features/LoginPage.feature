Feature: Login Page
Different test scenarios for Login Page

Background:
	Given Launch the Zeus application
	But User is not logged in

@TC_Zeus_Login_0001 
Scenario: Verify User access when login information is valid
	Given I provide all required fields with valid data
    #Using valid Username and password
	When I click on Login
	#Then User should be redirected to Zeus main page after being prompted with message "Please wait. Zeus is setting up the configurations for you!!"
	Then Verify user is landed on the dashboard page

@TC_Zeus_Login_0002 
Scenario: Verify User access when Username is valid and password is incorrect
	Given I provide all required fields with incorrect password
    #Using Valid Username and invalid password
	When I click on Login
	Then User should be prompted with message "Invalid Credentials. You have 4 more attempt(s) left. To generate new password, use Forgot Password option."
    #If attempted more times message should be the same while the number of attempts should be attempts left - 1
	Given I provide all required fields with incorrect password
	When I click on Login
	Then User should be prompted with message "Invalid Credentials. You have 3 more attempt(s) left. To generate new password, use Forgot Password option."

@TC_Zeus_Login_0003 @PositiveTests
Scenario: Verify Forgot Password while Username is valid
	Given I open Forgot Password Page
	And I provide Valid Username
		| ValidUsername |
		| aaly          |
	When I click Reset Password
	Then User should be redirected to the Login Page and receive "Email sent to registered Email" 

@TC_Zeus_Login_0004 @NegativeTests
Scenario: Verify User access when User does not exist
	Given I provide all required fields with non existing Username and password
    #Using Non-existing Username and password
	When I click on Login
	Then User should be prompted with message "Username doesn't exist"

@TC_Zeus_Login_0005 @NegativeTests
Scenario: Verify User access when Username, Password or both are left empty
	Given I don't provide any Username or password
    #Using empty Username and empty password
	When I click on Login
	Then nothing should happen and user stays on login page only
    #A message needs to be added to this scenario to prompt User to fill all required sections (Username and password)

@TC_Zeus_Login_0006 @PositiveTests
Scenario: Verify Forgot Password
	When I click Forgot Password?
	Then User should be redirected to Forgot Password page

@TC_Zeus_Login_0007 @NegativeTests
Scenario: Verify Forgot Password while Username is empty
	Given I open Forgot Password Page
	When I click Reset Password
	Then User should receive "The Username field is required."

@TC_Zeus_Login_0008 @NegativeTests
Scenario: Verify Forgot Password while Username is invalid
	Given I open Forgot Password Page
	And I provide an invalid Username
    #Using invalid Username
	When I click Reset Password
	Then User should receive "No such user exists."