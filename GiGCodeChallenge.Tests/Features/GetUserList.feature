Feature: GetUserList

@user_list
Scenario: List users
	When I send the request
	Then the response should have the status code '200' with list of users
