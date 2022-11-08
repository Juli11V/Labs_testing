Feature: CreateBooking

@smoke
Scenario: Add a new booking
	Given I input firstname "Jim"
	And I input lastname "Brown"
	And I set a total price at "111"
	And I mark depositpaid as "true"
	And I select the booking dates as checkin in "2018-01-01" and checkout in "2019-01-01"
	And I input "Breakfast" in additional needs
	When I send create booking request
	Then validate booking is created
