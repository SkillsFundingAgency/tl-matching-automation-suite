Feature: Create a Provision Gap record
Verify that a provision gap record is created and the details entered in the journey are correctly displayed back to the user for confirmation.

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page

@regression
Scenario: A provision gap record is created where the user does not enter the number of placements required
	Given I have entered new Skill Area as "Care services"
	And Employer postcode as "AB37 9HR"
	And Providers within as "25 miles"
	And I press the Search again button on the Select Providers page
	And I press the report provision gap link
	Then I am on the Placement information page
	Given I enter a job description of "Builder" on the Placement information page
	And I select No for the number of placements known
	And I press Continue on the Placement Information page
	Then I am on Who is the employer page
	Given I enter an employer name of "Paul Robert Housden" on the Who is the employer page
	And I press Continue on the Who is the employer page
	Then the Check employers details page will show the details entered
	Given I press Continue on the Check Employer Details page
	Then the Check answers screen will display the provision gap details entered
	Given I press Confirm and Send on the Check answers page
    Then a Provision gap record will be created
	And the Opportunity record will record OPT IN has not been selected
	And the Provision Gap Done page is displayed
	
	@regression
Scenario: A provision gap record is created where the user enters the number of placements required and opts in to share tehir details
	Given I have entered new Skill Area as "Care services"
	And Employer postcode as "AB37 9HR"
	And Providers within as "25 miles"
	And I press the Search again button on the Select Providers page
	And I press the report provision gap link
	Then I am on the Placement information page
	Given I enter a job description of "Builder" on the Placement information page
	And I have selected the Yes radio button
	And I enter 6 for the number of placements
	And I press Continue on the Placement Information page
	Then I am on Who is the employer page
	Given I enter an employer name of "Paul Robert Housden" on the Who is the employer page
	And I press Continue on the Who is the employer page
	Then the Check employers details page will show the details entered
	Given I press Continue on the Check Employer Details page
	Then the Check answers screen will display the provision gap details entered
	Given I press Opt In on the Check answers page
	Given I press Confirm and Send on the Check answers page
    Then a Provision gap record will be created
	And the Opportunity record will record OPT IN has been selected
	And the Provision Gap Done page is displayed

	

	
