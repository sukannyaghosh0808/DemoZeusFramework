Feature: 01_Paper Capture
Different test scenarios for Paper capture

Background:
	Given Launch the Zeus application
	And I login to the Zeus application with valid credentials
	When I click on distribution center change button
	And I select a store randomly
	Then The store should change to what was selected randomly
	Given I open patient browser page
	And I search for the "first" patient created
	And I click the view file link for the patient created
	And I go to the paper capture tab

@TC_Zeus_PaperCapture_0001 @PositiveTests
Scenario: Upload new paper capture
	Given I click the upload button
	And I click the scan icon
	And I select an external file to upload
	And I select the following options in paper capture popup
		| Category  | SubCategory    |
		| Insurance | Insurance Card |
	And I provide a new title
	When I click the add button in paper capture modal window
	Then The success message "File Uploaded Successfully" is displayed on screen
	When I click the view link for the file just added
	Then The file is displayed on screen

@TC_Zeus_PaperCapture_0002 @PositiveTests
Scenario: Edit paper capture
	Given I click the upload button
	And I click the scan icon
	And I select an external file to upload
	And I select the following options in paper capture popup
		| Category  | SubCategory    |
		| Insurance | Insurance Card |
	And I provide a new title
	When I click the add button in paper capture modal window
	Then The success message "File Uploaded Successfully" is displayed on screen
	When I click the view link for the file just added
	Then The file is displayed on screen
	Given I click the edit icon in the file
	And I select the following options in paper capture popup
		| Category           | SubCategory             |
		| Exam/ Prescription | Paper Chart Examination |
	And I provide a new title for editing
	When I click the update button
	Then The success message "Record has been updated successfully" is displayed on screen

@TC_Zeus_PaperCapture_0003 @PositiveTests
Scenario: Eliminate paper capture
	Given I click the upload button
	And I click the scan icon
	And I select an external file to upload
	And I select the following options in paper capture popup
		| Category  | SubCategory    |
		| Insurance | Insurance Card |
	And I provide a new title
	When I click the add button in paper capture modal window
	Then The success message "File Uploaded Successfully" is displayed on screen
	When I click the view link for the file just added
	Then The file is displayed on screen
	Given I close the file displayed on screen
	When I click the delete icon in the grid for the file just added
	Then The success message "Paper capture deleted successfully" is displayed on screen

@TC_Zeus_PaperCapture_0004 @PositiveTests
Scenario: Select an image previously uploaded in the paper capture
	Given I click the upload button
	And I click the scan icon
	And I select an external file to upload
	And I close the Paper Capture modal window
	And I click the upload button
	And I click the select icon
	And I select an existing file
	And I select the following options in paper capture popup
		| Category  | SubCategory    |
		| Insurance | Insurance Card |
	And I provide a new title
	When I click the add button in paper capture modal window
	Then The success message "File Uploaded Successfully" is displayed on screen