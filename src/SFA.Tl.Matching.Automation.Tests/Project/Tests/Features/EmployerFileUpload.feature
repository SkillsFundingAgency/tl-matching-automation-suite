Feature: EmployerFileUpload
	This feature is used to upload new Employer data. 
	The test will verify a Employer file can be uploaded and the record/s are written to the Employer table. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"


Scenario: Upload Employer Data
	Given I Navigate to File Upload Page
	And I have cleared down the Employer table first
	And I Upload Employer File
	When I press Submit
	Then the screen should display File Successfully Uploaded Message
	And the Database should have a new employer named 1066 Enterprise
