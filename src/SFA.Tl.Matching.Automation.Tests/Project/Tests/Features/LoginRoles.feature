Feature: LoginRoles
	Admin users will see a link on the Start Page to upload Employer Data
	Standard users will not be shows a link on the Start Page to upload Employer data

Background: 
	Given I have navigated to the IDAMS login page

@regression
Scenario: Admin users should see a link to upload Employer data
	Given I have logged in as an "Admin User"
	Then I should be on the Start Page
	And I should see an option stating "Upload employer and provider data"

@regression
Scenario: Users with both Admin and Standard user access should see a link to upload Employer data
	Given I have logged in as an "Dual User"
	Then I should be on the Start Page
	And I should see an option stating "Upload employer and provider data"

@regression
Scenario: Standard users should not see a link to upload Employer data
	Given I have logged in as an "Standard User"
	Then I should be on the Start Page
	And I should not see a link to upload Employer Data
	
@regression
Scenario: IDAMS users not authorised to use the Matching Service will be denied login
	Given I have logged in as an "Non Authorised User"
	Then I should be on the Invalid Role Page
