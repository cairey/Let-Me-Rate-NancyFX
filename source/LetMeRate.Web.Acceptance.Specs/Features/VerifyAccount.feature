Feature: Account validation
	In order to validate my account
	As a user of rating
	I want to be sent a validation link

@CreateUserAccounts
Scenario: Validating account
	Given I am making web request
	When sending my validation key
	Then I should see a result that I am validated
