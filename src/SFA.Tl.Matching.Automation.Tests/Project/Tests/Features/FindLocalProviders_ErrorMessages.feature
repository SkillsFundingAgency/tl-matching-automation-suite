Feature: Error messages on the Find a Provider page
	This feature is used to confirm the error message on the Find a provider web page when a postcode is not entered. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to the FindProviders page

@regression
Scenario: FindLocalProviders-Press Continue without entering a postcode
	When I clear the Postcode and Search
	Then the Find Providers page will show an error stating "You must enter a postcode"
