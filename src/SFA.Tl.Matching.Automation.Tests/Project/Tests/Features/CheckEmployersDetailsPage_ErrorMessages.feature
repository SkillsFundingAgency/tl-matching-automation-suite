Feature: Error messages on the Check Employer Details page
         Verify the error messages are correctly triggered on the Check Employer Details Page

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an Admin user
	And I navigate to the Check Employer Details page

@regression
Scenario: Check Employer Details - Press continue after clearing all fields
	Given I have cleared all of the text fields
	And I press Continue on the Check Employer Details page
	Then the Check Employer Details page will show an error for Null contact name stating "You must enter a contact name for placements"
	And the Check Employer Details page will show an error for Null email address stating "You must enter a contact email for placements"
	And the Check Employer Details page will show an error for Null contact number stating "You must enter a contact telephone number for placements"

@regression
Scenario: Check Employer Details - Job type must be between 2 and 99 characters
	Given I enter a contact name 1 character long on the Check Employer screen
	And I press Continue on the Check Employer page
	Then the Check Employer page will show an error for contact name not long enough stating "You must enter a contact name using 2 or more characters"
	Given I enter a contact name longer than 99 characters
	And I press Continue on the Check Employer page
	Then the Check Employer page will show an error for contact name being too long stating "You must enter a contact name using 99 characters or less"

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
	
@regression
Scenario: Check Employer Details - Contact name cannot contain special characters
	Given I enter special characters in contact name
	And I press Continue on the Check Employer page
	Then the Check Employer page will show an error for special characters in contact name stating "You must enter a contact name using letters only"
