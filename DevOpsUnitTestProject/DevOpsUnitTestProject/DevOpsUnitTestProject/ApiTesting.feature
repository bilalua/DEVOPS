Feature: ApiTesting
	As a QE engg
	I want to be able to check employee API
	So that i can verify CURD Operation

@mytag
Scenario: Verify API Is working and apply CURD Operations
	Given I am able to send a GET request to "url" 
	Then I should get "200" response code
	When I send a POST request to "api/employee" with "007","James Bond" and "55"
	Then I should get "200" response code
	And I should see following data
	| Key          | Value      |
	| EmployeeID   | 7        |
	| EmployeeName | James Bond |
	| EmployeeAge  | 55         |
	When I send a DELETE request to "api/employee/?" with "007"
	Then I should get "200" response code
	And I should see sucessfully deleted message in response
