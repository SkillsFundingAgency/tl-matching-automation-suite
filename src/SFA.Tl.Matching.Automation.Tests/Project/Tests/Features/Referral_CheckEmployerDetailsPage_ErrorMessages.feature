Feature: Referral Journey - Check Employer Details page - Error messages
         Verify the error messages are correctly triggered on the Check Employer Details Page in the referral journey

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to Who is the employer page Referral Journey
	And I enter an Employer business name "testNameForPageCheck" and Continue

@regression
Scenario: Referral - Check Employer Details - Verify error messages
	Then the Check employers details page must pull the correct details from DB

	When I clear all text fields on the Employer Contact Details and Continue
	Then the Check Employer page will show an error for "Null" contact name as "You must enter a contact name for placements"
	And the Check Employer page will show an error for "Null" email address stating "You must enter a contact email for placements"
	And the Check Employer page will show an error for "Null" phone number must be a number stating "You must enter a contact telephone number for placements"

	When I enter an Invalid contact name "A" of "oneCharacterLong" on the Check Employer screen and Continue
	Then the Check Employer page will show an error for "oneCharacterLong" contact name as "You must enter a contact name using 2 or more characters"

	When I enter an Invalid contact name "ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJA" of "Morethan99Characters" on the Check Employer screen and Continue
	Then the Check Employer page will show an error for "Morethan99Characters" contact name as "You must enter a contact name that is 100 characters or fewer"

	When I enter an Invalid contact name "Name!£$%^&*()" of "SpecialCharacters" on the Check Employer screen and Continue
	Then the Check Employer page will show an error for "SpecialCharacters" contact name as "You must enter a contact name using only letters, hyphens and apostrophes"

	When I enter an Invalid Phone Number "ABCDEFG123456" of "AlphaNumericCharacters" on the Check Employer screen and Continue
	Then the Check Employer page will show an error for "alphaNumericCharacters" phone number must be a number stating "You must enter a number"

	When I enter an Invalid Phone Number "254125" of "SixNumbersOnly" on the Check Employer screen and Continue
	Then the Check Employer page will show an error for "SixNumbersOnly" phone number must be a number stating "You must enter a telephone number that has 7 or more numbers"


#@regression
#Scenario Outline: Referral - Check Employer Details - Job type must be between 2 and 99 characters and no special characters
#	When I enter an Invalid contact name <InvalidContactName> on the Check Employer screen and Continue
#	Then the Check Employer page will show an error for <Characters> as <ErrorMessage>
#Examples:
#| Characters        | InvalidName                                                                                          | ErrorMessage                                                              |
#| 1                 | A                                                                                                    | You must enter a contact name using 2 or more characters                  |
#| 100               | ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ | You must enter a contact name using 99 characters or less                 |
#| SpecialCharacters | Name!£$%^&*()                                                                                        | You must enter a contact name using only letters, hyphens and apostrophes |
#
#@regression
#Scenario: Referral - Check Employer Details - Phone number must contain numbers
#	Given I enter a phone number consisting of alphanumeric characters only
#	And I press Continue on the Check Employer page
#	Then the Check Employer page will show an error for phone number must be a number stating "You must enter a number"
#	
#@regression
#Scenario: Referral - Check Employer Details - Phone number must contain at least 7 characters
#	Given I enter a phone number consisting of alphanumeric characters and six numbers only
#	And I press Continue on the Check Employer page
#	Then the Check Employer page will show an error for phone number not long enough "You must enter a telephone number that has 7 or more numbers"
