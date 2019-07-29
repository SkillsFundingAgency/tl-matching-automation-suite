Feature: Select Providers page - Search results
	This feature is used to confirm the search results on the Select providers page are displayed with the correct information. 


Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page

@regression
Scenario: Select Providers - Details entered on the Find Provider page will be displayed in the header on Select Providers page
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading 
	

@regression
Scenario: Search on Select Providers page and return zero results
	Given I have filled in the search form on the Search Providers page with criteria which will return no results
	When I press the Search again button on the Select Providers page
	Then the Select Providers page will display a H2 heading for zero results	

@regression
Scenario: Validate search results on Select a Provider page where results are returned 1
    Given I have filled in the search form on the Search Providers page with criteria which will return some results 
	And I press the Search again button on the Select Providers page
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading 
	

@regression
Scenario: Validate search results on Select a Provider page where results are returned 2
    Given I have filled in the search form on the Search Providers page with criteria which will return some results 
	And I press the Search again button on the Select Providers page
	Then the provider results returned will match the expected values
	And the Select Providers page will display the count, skill area, postcode and radius in the H2 heading 

	@regression
Scenario: Validate search results on Select a Provider page where 1 result is returned
    Given I have filled in the search form on the Search Providers page with criteria which will return one result
	And I press the Search again button on the Select Providers page
	And the Select Providers page will display the count, skill area, postcode, radius and text result in in the H2 heading 

