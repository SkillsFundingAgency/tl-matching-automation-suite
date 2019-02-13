Feature: Upload file page errors
	Verification of the correct errors being displayed when a file upload is attempted 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I Navigate to File Upload Page

@regression
    Scenario: Attempt to upload a file without selecting a file
	Given I select "Provider" from the dropdown
	And I press Upload
	Then I should see an Error for no file selected 

@regression
    Scenario: Attempt to upload a Word document
	Given I select "Provider" from the dropdown
	And I select a Word document
	And I press Upload
	Then I should see an Error for invalid file selected

@regression
    Scenario: Attempt to upload a JPEG
	Given I select "Employer" from the dropdown
	And I select a JPEG image
	And I press Upload
	Then I should see an Error for invalid file selected
