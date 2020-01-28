Feature: Provider Results On Show Me Everything Page
    Verify that Provider Results within 30 miles for all the routes are displayed

Background: 
    Given I have navigated to the IDAMS login page
    And I have logged in as an "Admin User"

@regression
Scenario:  Verify Provider Results
    When I navigate to show all Providers page which returns many results
    Then I should see provider results in all routes
	And the Select Providers page will display the count and result in the H2 heading
	When I Filter Provider results for One route
    Then I should see provider results displayed only for One route
	And the Select Providers page will display the count, result and route in the H2 heading
	When I Filter Provider results for One more route
	Then the Select Providers page will display the count, result and routes in the H2 heading

@regression
Scenario: Verify Provider Results returning zero results
	When I navigate to Provider results page with no results
	Then the Providers page will display zero results for the H2 heading

@regression
Scenario: Validate search results on Select a Provider page where 1 result is returned
    When I navigate to Provider results page with only one result
	Then the Providers page will display the count and text result in the H2 heading
