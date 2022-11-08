Feature: ReadRandomQuote

@smoke
Scenario: Read a quote
	When I send a read random quote request
	Then The response status code should be OK
