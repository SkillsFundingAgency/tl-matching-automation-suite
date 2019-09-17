Feature: Error messages on the Select Providers page
	This feature is used to confirm the error message on the Select providers page when a postcode is not entered. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to the Select Providers page

@regression
Scenario: Select Providers page - A postcode must be entered when searching
	Given I clear the postcode field on the Select providers page and Search Again
	Then I am shown an error for blank postcode stating "You must enter a postcode"

@regression
Scenario: Select Providers page - A real postcode must be entered when searching
	Given I enter an invalid postcode on the Select providers page and Search again
	Then I am shown an error for invalid postcode stating "You must enter a real postcode"

@regression
Scenario: Select Providers page - A provider must be selected before pressing Continue
   	When I have filled in the search form on the Search Providers page with criteria which returns some results
	When I press Continue without selecting Providers
	Then I am shown an error for no provider selected stating "You must select at least one provider"
