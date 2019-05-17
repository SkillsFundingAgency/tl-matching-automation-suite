Feature: Create a Referral
Verify that a referral journey is completed and a referral record is created for every provider selected.
Verify the Check answers screen replays the users answers correctly
Please note, these tests are using hardcoded values to select the first two provders returned in the results.

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page
	And I select a provider and continue to placement information page
	And I entered the placement information and press No then click continue button
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

	
    
