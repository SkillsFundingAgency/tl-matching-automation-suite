Feature: Create a Referral
Verify that a referral journey is completed and a referral record is created for every provider selected.
Verify the Check answers screen replays the users answers correctly
Please note, these tests are using hardcoded values to select the first two provders returned in the results.

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to Who is the employer page Referral Journey
	And I entered employer name and press continue 
	

@regression
    Scenario: Create a referral - No of placements is not known
    Then the Check employers details page will show the details entered
    #Given I press Continue on the Check Employer Details page
    Then the referral Check answers screen will display the referral details entered
   # And the providers selected will be displayed on the Referral Check Answers screen
    Given I press Opt In on the Check answers page and click continue  
	#Given I press Opt In on the Check answers page
    #Given I press Continue on the Check Employer Details page
    And referral records are created
	And the Opportunity record has recorded the user Opted in
	Then the Referral Done page is displayed with the correct text
	#And the Referral Done page is displayed

	@regression
    Scenario: Create a referral - A single referral
    Then the Check employers details page will show the details entered
    Then the referral Check answers screen will display the referral details entered
    Given I press Opt In on the Check answers page and click continue  
	#And referral records are created
	#And the Opportunity record has recorded the user Opted in
	#Then the Referral Done page is displayed with the correct text
	And I press Continue with Opportunity on the Opportunity Basket
	And I opt in to send emails and press Confirm and Send Opportunity
	

	@regression
    Scenario: Create a referral - The user will not be asked to select the Employer again when they add more than one opportunity to a referral 
    Given I have added a single opportunity
	When I press Add another Opportunity on the Opportunity Basket
	Then I will not be asked to select the Employer name again

    
