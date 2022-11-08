Feature: ReadBookings

@smoke
Scenario: Read the bookings
	When I send read the bookings request
	Then the response code should be OK
