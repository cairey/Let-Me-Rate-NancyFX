Feature: Delete Rating
	In order for my rating to not appear
	As a user of ratings
	I want to be able to remove a rating

@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Delete ratings when my rating exists
	Given I am making web request
	When I delete a rating with a known unique key
	Then my rating should have been deleted



@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Delete ratings when my rating does not exists
	Given I am making web request
	When I delete a rating that does not exist
	Then my rating should not have been found
