Feature: Referral - Placement Information - Error Messages
	     This feature is used to confirm the error messages on the Placement information page in the Referral journey. 

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"

@regression
Scenario: Referral-Placement Information - Press continue without entering any data
    Given I navigate to the Referral Journey Placement Information page
	When I enter no placement information and Continue 
	Then the Placement Information page will show an error stating "You must tell us whether the employer knows how many students they want for this job at this location" for "StudentsOptionNotSelected"

@regression
Scenario Outline: Referral-Placement Information - Number of Placements field is shown only if Yes is selected
	Given I navigate to the Referral Journey Placement Information page
	When I select <Value> for how many students needed
	Then Number of Students field is <Result>	
Examples:
| Value | Result        |
| Yes   | Displayed     |
| No    | Not Displayed |
	 
@regression
Scenario Outline: Referral-Placement Information - Job type must be between 2 and 99 characters
	Given I navigate to the Referral Journey Placement Information page
	When I enter an invalid job title <JobRole> and Continue	
	Then the <ErrorMessage> for Invalid Job Role for <Number> characters is displayed
Examples:
| Number | JobRole                                                                                               | ErrorMessage                                              |
| 1      | A                                                                                                     | You must enter a job role using 2 or more characters      |
| 100    | ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJA | You must enter a job role that is 100 characters or fewer |

@regression
Scenario Outline: Referral-Placement Information - Number of placements entered must be greater than 0
	Given I navigate to the Referral Journey Placement Information page
    When I enter Invalid number of Students <Number> and Continue	
	Then the <ErrorMessage> for Invalid Number of Students is displayed for <Number>
Examples:
| Number | ErrorMessage                                                                         |
| 0      | The number of students must be 1 or more                                             |
| 1000   | The number of students must be 999 or less                                           |
|        | You must estimate how many students the employer wants for this job at this location |
