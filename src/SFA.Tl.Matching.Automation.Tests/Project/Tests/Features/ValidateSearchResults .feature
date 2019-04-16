Feature: Verify the search results on the Select provider page match the expected values

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page

@regression
Scenario: Validate search results on Select a Provider page where results are returned 3
Given I have entered new Skill Area as "Care services"
	And Employer postcode as "B43 6JN"
	And Providers within as "25 miles"
	And I press the Search again button on the Select Providers page
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading 

@regression
Scenario: Validate search results on Select a Provider page where results are returned 4
Given I have entered new Skill Area as "Digital"
	And Employer postcode as "B43 6JN"
	And Providers within as "15 miles"
	And I press the Search again button on the Select Providers page
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading 

