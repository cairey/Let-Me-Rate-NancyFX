Feature: Delete Rating
	In order for my rating to not appear
	As a user of ratings
	I want to be able to remove a rating


Scenario: Delete ratings
	Given I am making web request
	When I delete ratings
	Then my rating should have been deleted
