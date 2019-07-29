Feature: Who is the Employer page error messages
	This feature is used to confirm the error messages on the Who is the Employer page. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Who is the employer page

@regression
Scenario: ProvisionGap_Who is the employer - Press continue without entering any data
	Given I clear the job field on the Who is the employer page
	And I press Continue on the Who is the employer page
	Then the Who is the employer page will show an error stating "You must tell us what specific job the placement student would do"
	
