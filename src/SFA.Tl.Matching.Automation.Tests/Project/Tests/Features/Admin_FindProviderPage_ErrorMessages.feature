Feature: Error messages on the Admin - Find a Provider page
	This feature is used to confirm the error messages on the Admin Find a provider page when the value entered in not in the correct format. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to Find a Provider Page

@regression
Scenario: The Search button is pressed when the text field is null
	When I clear the UKPRN search field and press Search
	Then the user will be shown he following message "You must enter a UKPRN"

@regression
Scenario: A UKPRN entered in the wrong format is searched for
	When I enter an invalid UKPRN and press Search
	Then the user will be shown the following message for invalid Ukprn "The value 'Invalid' is not valid for UKPRN."
