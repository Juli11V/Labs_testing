Feature: DeleteBooking

@smoke
Scenario: Delete the booking record
	When I call a delete request for the record 
	Then I check whether the record is deleted
