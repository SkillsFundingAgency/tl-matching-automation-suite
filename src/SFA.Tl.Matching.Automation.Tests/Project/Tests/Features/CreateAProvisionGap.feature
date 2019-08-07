Feature: Create a Provision Gap record
Verify that a provision gap record is created and the details entered in the journey are correctly displayed back to the user for confirmation.

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user

@regression
Scenario: A provision gap record is created where the user does not enter the number of placements required	
	Given I navigate to Who is the employer page Provision Gap with unknown Number of students	
	And I entered employer name and press continue 
	And the Check employers details page will show the details entered
	And the Check answers screen will display the provision gap details entered
	When I press Confirm and Send on the Check answers page
    Then a Provision gap record will be created
	And the Opportunity record will record OPT IN has not been selected
	And the Provision Gap Done page is displayed
	
@regression
Scenario: A provision gap record is created where the user enters the number of placements required and opts in to share their details
   Given I entered new search criteria and press Search again button on the Select Providers Page
	And I press the report provision gap link
	And I navigate to Who is the employer page Provision Gap with known Number of students    
    Then I am on Who is the employer page
    And I entered employer name and press continue 
	And the Check employers details page will show the details entered
	And the Check answers screen will display the provision gap details entered
	When I press Confirm and Send on the Check answers page
    Then a Provision gap record will be created
	And the Opportunity record will record OPT IN has not been selected
	And the Provision Gap Done page is displayed
    

	
