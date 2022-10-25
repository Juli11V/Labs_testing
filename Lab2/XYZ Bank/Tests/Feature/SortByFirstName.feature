Feature: SortByFirstName
	Sort customers records in descending order

@smoke
Scenario: Perform sort of customer records in descending order
	Given I launch the application
	And I click on the Bank Manager Login link
	And I click on the Customers menu item
	When I click on the First Name header
	Then I should see customer records sorted in descending order
