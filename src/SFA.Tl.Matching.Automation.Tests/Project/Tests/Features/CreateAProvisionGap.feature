Feature: Create a Provision Gap record
Verify that a provision gap record is created and the details entered in the journey are correctly displayed back to the user for confirmation.

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"

@regression
Scenario: A provision gap record is created where the user does not enter the number of placements required	
	Given I navigate to Who is the employer page Provision Gap with unknown Number of students	
	And I enter an Employer business name "testNameForGeneralFlow" and Continue
	Then Enter the Employer Details and continue for Provision Gap Journey
    Then a Provision gap record will be created
	When I Finish the Provision Gap Journey
	Then the Opportunity record will record OPT IN has not been selected
	
@regression
Scenario: A provision gap record is created where the user enters the number of placements required and opts in to share their details
   Given I entered new search criteria and press Search again button on the Select Providers Page
	And I press the report provision gap link
	And I navigate to Who is the employer page Provision Gap with known Number of students    
	And I enter an Employer business name "testNameForGeneralFlow" and Continue
	Then Enter the Employer Details and continue for Provision Gap Journey
    Then a Provision gap record will be created
	When I Finish the Provision Gap Journey
	Then the Opportunity record will record OPT IN has not been selected
