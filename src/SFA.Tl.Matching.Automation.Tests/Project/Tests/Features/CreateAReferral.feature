Feature: Create a Referral
Verify that a referral journey is completed and a referral record is created for every provider selected.
Verify the Check answers screen replays the users answers correctly
Please note, these tests are using hardcoded values to select the first two provders returned in the results.

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	#And I navigate to Who is the employer page Referral Journey
	#And I enter an Employer business name "testNameForGeneralFlow" and Continue

@regression
    Scenario: Create a referral - No of placements is not known
	And I navigate to Who is the employer page Referral Journey
	And I enter an Employer business name "testNameForGeneralFlow" and Continue
	Then Enter the Employer Details and continue for Referral Journey
    Then the referral Check answers screen will display the referral details entered
    #And the providers selected will be displayed on the Referral Check Answers screen
	Given I Confirm details on the Check answers page
	And I Continue with Single Opportunity on the Opportunity Basket
	And I opt in to send emails and press Confirm and Send Opportunity
	Then I check that the emails are sent successfully
	#Then referral records are created
	#And the Opportunity record will record OPT IN has been selected
	#And the Emails Sent Page is displayed with the correct text
	
	
	@regression
    Scenario: Create a referral - A single referral with no of placements and job role specified
    And I navigate to Who is the employer page Referral Journey by entering placement information
	And I enter an Employer business name "testNameForGeneralFlow" and Continue
	Then Enter the Employer Details and continue for Referral Journey
    Then the referral Check answers screen will display the referral details entered
	Given I Confirm details on the Check answers page
	#Then referral records are created
	#And the Opportunity record will record OPT IN has been selected
	#And the Emails Sent Page is displayed with the correct text
	And I Continue with Single Opportunity on the Opportunity Basket
	And I opt in to send emails and press Confirm and Send Opportunity
	Then I check that the emails are sent successfully


	@regression
    Scenario: Create a referral - The user will not be asked to select the Employer again when they add more than one opportunity to a referral 
    And I navigate to Who is the employer page Referral Journey
	And I enter an Employer business name "testNameForGeneralFlow" and Continue
	Given I have added a single opportunity
	When I start Adding another Opportunity from Opportunity Basket
	Then I will not be asked to select the Employer name again
