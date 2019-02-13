Feature: Select Providers page - Search results
	This feature is used to confirm the search results on the Select providers page are displayed with the correct information. 


Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page

@regression
Scenario: Select Providers - Details entered on the Find Provider page will be displayed in the header on Select Providers page
	Then the Select Providers page will display the postcode and skill area selected on the Find Providers page

@regression
Scenario: Select Providers - Search using the Search on the page
	Given I have entered new Skill Area as "Care services"
	And Employer postcode as "B20 3HQ"
	And Providers within as "25 miles"
	And I press the Search again button on the Select Providers page
	Then the Select Providers page will display the skill area, postcode and radius in the H2 heading