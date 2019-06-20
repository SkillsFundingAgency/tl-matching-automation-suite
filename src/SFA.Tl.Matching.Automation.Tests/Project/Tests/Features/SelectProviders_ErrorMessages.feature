Feature: Error messages on the Select Providers page
	This feature is used to confirm the error message on the Select providers page when a postcode is not entered. 


Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page

@regression
Scenario: Select Providers page - A postcode must be entered when searching
	Given I clear the postcode field on the Select providers page
	And I press the Search again button on the Select Providers page
	Then I am shown an error for blank postcode stating "You must enter a postcode"

@regression
Scenario: Select Providers page - A real postcode must be entered when searching
	Given I enter an invalid postcode on the Select providers page
	And I press the Search again button on the Select Providers page
	Then I am shown an error for invalid postcode stating "You must enter a real postcode"

@regression
Scenario: Select Providers page - A provider must be selected before pressing Continue
   	Given I have entered new Skill Area in dropdown
	And Employer postcode as "B43 6JN"
	And Providers within as "25 miles"
	And I press the Search again button on the Select Providers page
	Then I am shown an error for no provider selected stating "You must select at least one provider"