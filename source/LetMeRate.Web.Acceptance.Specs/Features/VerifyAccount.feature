Feature: Account validation
	In order to validate my account
	As a user of rating
	I want to be sent a validation link

@CreateUserAccounts
@ClearDatabase
Scenario: Validating account that is valid
	Given I am making web request
	When sending my validation key
	Then I should see a result that I am validated


@CreateUserAccounts
@ClearDatabase
Scenario: Validating account that's not valid
Given I am making web request
When sending my validation key that is invalid
Then I should see a result that I am not validated
