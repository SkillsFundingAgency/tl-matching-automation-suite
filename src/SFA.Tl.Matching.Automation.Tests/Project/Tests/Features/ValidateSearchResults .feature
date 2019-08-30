Feature: Verify the search results on the Select provider page match the expected values

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to the Select Providers page

@regression
Scenario: Validate search results on Select a Provider page where results are returned 3
	When I have filled in the search form on the Search Providers page with criteria which returns some results
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading
