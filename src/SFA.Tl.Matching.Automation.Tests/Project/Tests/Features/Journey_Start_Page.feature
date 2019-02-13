Feature: User journey starting point Page
	A user, who is logged in to the Matching Service will start their user journey on the Start Page
	A user who is not logged in to the Matching Service will start their user journey on the Login Help Page

@regression
Scenario: The matching service journey starts from the Login Help Page for non logged in users
	Given I navigate to the Matching Service home page
	And I am not logged in
	Then I will be shown the Login Help Page

@regression
	Scenario: The matching service journey starts from the Start Page for logged in users
	Given I navigate to the Matching Service home page
	And I am logged in
	Then when I navigate to the homepage I will be taken to the Start Page
