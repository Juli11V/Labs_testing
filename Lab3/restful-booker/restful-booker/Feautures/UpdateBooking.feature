Feature: UpdateBooking

@smoke
Scenario: Update the booking record
	When I call an update request for the record 
	Then I check whether the record is updated
	
