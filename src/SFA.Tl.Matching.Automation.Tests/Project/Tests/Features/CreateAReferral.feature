Feature: Create a Referral
Verify that a referral journey is completed and a referral record is created for every provider selected.
Verify the Check answers screen replays the users answers correctly
Please note, these tests are using hardcoded values to select the first two provders returned in the results.

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page
	Given I select some providers
	When I press the Continue button
	Then I am on the Placement information page
	Given I enter a job description of "Builder" on the Placement information page
	And I select No for the number of placements known
	And I press Continue on the Placement Information page
	Then I am on Who is the employer page
	Given I enter an employer name of "Abacus Childrens Nurseries" on the Who is the employer page
	And I press Continue on the Who is the employer page
	Then I am taken to the Check Employer Details page

@regression
    Scenario: Create a referral - No of placements is not known
    Then the Check employers details page will show the details entered
    Given I press Continue on the Check Employer Details page
    Then the referral Check answers screen will display the referral details entered
    And the providers selected will be displayed on the Referral Check Answers screen
    Given I press Opt In on the Check answers page
    Given I press Continue on the Check Employer Details page
    And referral records are created
	And the Opportunity record has recorded the user Opted in
	And the Referral Done page is displayed
	And the Referral Done page displays the correct text in the What happens next section
	
    
