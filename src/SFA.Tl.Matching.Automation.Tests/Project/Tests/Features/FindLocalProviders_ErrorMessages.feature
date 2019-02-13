Feature: Error messages on the Find a Provider page
	This feature is used to confirm the error message on the Find a provider web page when a postcode is not entered. 


Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the FindProviders page

@regression
Scenario: FindLocalProviders-Press Continue without entering a postcode
	Given I clear the postcode field
	And I press Continue on the Find a Provider page
	Then the Find a Provider page will show an error stating "You must enter a postcode"
