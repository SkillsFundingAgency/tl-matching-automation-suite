Feature: Error messages on the Select Providers page
	This feature is used to confirm the error message on the Select providers page when a postcode is not entered. 


Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page

@regression
Scenario: Select Providers-Press Continue without entering a postcode
	Given I have entered new Skill Area as "Care services"
	And Employer postcode as "B20 3HQ"
	And Providers within as "25 miles"
	And I press the Search again button on the Select Providers page
	And I click the Report provision gap link
	Then I am on the Placement information page

