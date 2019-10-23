Feature: UserRegistration

@user_registration
Scenario: Successful
	Given I have entered an email address('eve.holt@reqres.in') into a registration form
	And I have entered valid password ('pistol') into a registration form
	When I send the registration values
	Then the response should have the status code '200' along with a token

Scenario: Unsuccessful
	Given I have entered an email address('sydney@fife') into a registration form
	When I send the registration values
	Then the response should have the status code  '400' along with an error
