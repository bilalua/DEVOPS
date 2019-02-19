Feature: AddEmployee
	As a QE Engg
	I want to add an Employee
	So that i can verify that my site is working correctly

@mytag
Scenario: Add new employee and verify that it gets added
	Given I open the web "http://localhost:16061/Home/Index" site
	When I click the "Add New Employee" button
	And I enter following emplyee data "123456789","AutomationUser","123"
	And I click the "Add" button
	Then I should see added Id and should remove the data
	| Key | Value     |
	| ID  | 123456789 |


	
