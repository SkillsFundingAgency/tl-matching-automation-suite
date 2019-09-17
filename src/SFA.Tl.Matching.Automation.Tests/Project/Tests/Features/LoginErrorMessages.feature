Feature: Login Error Messages
	When a user is not able to log on the IDAMS page, the appropriate error message should be displayed

Background:
	Given I have navigated to the IDAMS login page

    @regression
	Scenario: Attempt to login but do not enter the username
	When I only enter the password and try to login on the IDAMS login page
	Then a warning will be displayed stating "Please enter your user ID or your email address"

	@regression
	Scenario: Attempt to login but do not enter the password
	When I only enter the username and try to login on the IDAMS login page
	Then a warning will be displayed stating "Please enter your user password"

	@regression
	Scenario: Attempt to login but do not enter the username and password
	When I Login without entering Username and Password
	Then a warning will be displayed stating "Please enter your user ID or email address and your password"

	@regression
	Scenario: Attempt to login with invalid user credentials
	When I enter an invalid username password and try to login on the IDAMS login page
	Then a warning will be displayed stating "Invalid user ID, email address or password"
