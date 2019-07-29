Feature: Referral journey - Validate the error messages on the Placement Information page
	     This feature is used to confirm the error messages on the Placement information page in the Referral journey. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Select Providers page
	Given I select some providers
	When I press the Continue button
	Then I am on the Placement information page

@regression
Scenario: Referral Placement Information - Press continue without entering any data
    
	Given I clear the job field on the Placement Information page
	And I press Continue on the Placement Information page
	Then the Placement Information page will show an error stating "You must tell us what specific job the placement student would do"
	And the Placement Information page will display a no placement selected error stating "You must tell us whether the employer knows how many placements they want at this location"

@regression
Scenario: Referral-Placement Information - Number of Placements field is shown only if Yes is selected
	Given I select the No radio button
	Then Number of Placements field is not displayed
	Given I select the Yes radio button
	Then Number of Placements field is displayed

	 
@regression
Scenario: Referral-Placement Information - Job type must be between 2 and 99 characters
	Given I enter a job title 1 character long
	And I press Continue on the Placement Information page
	Then the Place Information page will show an error for job type not long enough stating "You must enter a job role using 2 or more characters"
	Given I enter a job title longer than 99 characters
	And I press Continue on the Placement Information page
	Then the Place Information page will show an error for job type too long stating "You must enter a job role using 99 characters or less"

@regression
Scenario: Referral Placement Information - Number of placements entered must be greater than 0
    Given I select the Yes radio button
	And I enter 0 for the number of placements
	And I press Continue on the Placement Information page
	Then the Place Information page will show an error for number of placements being too small stating "The number of placements must be 1 or more"
	
@regression
Scenario: Referral Placement Information - Number of placements entered must be less than 1000
	Given I select the Yes radio button
	And I enter 1000 for the number of placements
	And I press Continue on the Placement Information page
	Then the Place Information page will show an error for number of placements being too big stating "The number of placements must be 999 or less"
	
@regression
Scenario: Referral Placement Information - Number of placements must be entered if the number of placements field is visbile
	Given I select the Yes radio button
	And I press Continue on the Placement Information page
	Then the Place Information page will show an error for Placement number cannot be null stating "You must estimate how many placements the employer wants at this location"
