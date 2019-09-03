Feature: Select Providers page - Search results
	This feature is used to confirm the search results on the Select providers page are displayed with the correct information. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to the Select Providers page

@regression
Scenario: Select Providers - Details entered on the Find Provider page will be displayed in the header on Select Providers page
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading 

@regression
Scenario: Search on Select Providers page and return zero results in any skill area
	When I have filled in the search form on the Search Providers page with criteria which returns no results
	Then the Select Providers page will display a H2 heading for zero results

@regression
Scenario: Search on Select Providers page and return zero results in only selected skill area
	When I have filled in the search form on the Search Providers page with criteria which returns no results in only selected skill area
	Then the Select Providers page will display a H2 heading for zero results for the selected skill area	

@regression
Scenario: Validate search results on Select a Provider page where results are returned 2
    When I have filled in the search form on the Search Providers page with criteria which returns some results 
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading 

@regression
Scenario: Validate search results on Select a Provider page where 1 result is returned
    When I have filled in the search form on the Search Providers page with criteria which returns one result
	Then the Select Providers page will display the count, skill area, postcode, radius and text result in in the H2 heading
