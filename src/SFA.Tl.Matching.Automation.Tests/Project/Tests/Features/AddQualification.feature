Feature: AddQualification
Verify that an admin user can add a qualification

Background: 
	Given I have navigated to the IDAMS login page
	And I have logged in as an "Admin User"
	And I navigate to Find a Provider Page

@regression
Scenario: Add Qualification that is mapped to the service
	Given I am on the Qualification Details Page 10000055
	When I add a Qualification that is already mapped to the service
	Then the Qualification should be added successfully

@NotValidAnymore
#Scenario: Add Qualification that is NOT mapped to the service
#	Given I am on the Qualification Details Page 10000055
#	When I add a Qualification that is Not mapped to the service
#	Then the Qualification should be added successfully
