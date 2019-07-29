Feature: ProviderFileUpload
	This feature is used to upload new provider data. 
	The test will verify a Provider file can be uploaded and the record/s are written to the Provider table. 


Background: 
	Given I have navigated to the IDAMS login page


@regression
Scenario: Upload Provider Data
	Given I have logged in as an Admin user
	And I Navigate to File Upload Page
	And I have cleared down the Provider table first
	And I upload a Provider File
	When I press Submit
	Then the screen should display File Successfully Uploaded Message
	And the database should have a new Provider