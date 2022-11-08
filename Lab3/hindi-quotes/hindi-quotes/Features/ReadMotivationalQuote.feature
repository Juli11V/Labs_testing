Feature: ReadMotivationalQuote

@smoke
Scenario: Read a motivational quote
	Given I input a motivational type of quote
	When I send a read quote request
	Then The the type of recieved quote should be motivational
