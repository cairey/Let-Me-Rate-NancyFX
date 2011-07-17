Feature: Account validation
	In order to validate my account
	As a user of rating
	I want to be emailed a validation link

@mytag
Scenario: Validating account
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
