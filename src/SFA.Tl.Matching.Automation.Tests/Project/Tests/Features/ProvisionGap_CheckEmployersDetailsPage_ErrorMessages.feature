Feature: Provision Gap - Check Employer Details page - Error messages
         Verify the error messages are correctly triggered on the Check Employer Details Page

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to the Check Employer Details page For a Provison Gap Journey

@regression
Scenario: Check Employer Details - Press continue after clearing all fields
	When I clear all text fields on the Employer Contact Details and Continue
	Then the Check Employer Details page will show an error for Null contact name stating "You must enter a contact name for placements"
	And the Check Employer Details page will show an error for Null email address stating "You must enter a contact email for placements"
	And the Check Employer Details page will show an error for Null contact number stating "You must enter a contact telephone number for placements"

@regression
Scenario Outline: Referral - Check Employer Details - Job type must be between 2 and 99 characters and no special characters
	When I enter an Invalid contact name <InvalidContactName> on the Check Employer screen and Continue
	Then the Check Employer page will show an error for <Characters> as <ErrorMessage>
Examples:
| Characters        | InvalidName                                                                                           | ErrorMessage                                                              |
| 1                 | A                                                                                                     | You must enter a contact name using 2 or more characters                  |
| 100               | ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJA | You must enter a contact name that is 100 characters or fewer             |
| SpecialCharacters | Name!£$%^&*()                                                                                         | You must enter a contact name using only letters, hyphens and apostrophes |

@regression
Scenario: Check Employer Details - Phone number must contain numbers
	Given I enter a phone number consisting of alphanumeric characters only
	And I press Continue on the Check Employer page
	Then the Check Employer page will show an error for phone number must be a number stating "You must enter a number"
	
@regression
Scenario: Check Employer Details - Phone number must contain at least 7 characters
	Given I enter a phone number consisting of alphanumeric characters and six numbers only
	And I press Continue on the Check Employer page
	Then the Check Employer page will show an error for phone number not long enough "You must enter a telephone number that has 7 or more numbers"
