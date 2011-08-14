Feature: Authorisation
	In order to be able to submit ratings
	As a user of ratings
	I want to be supplied with temp credentials, that will allow me to rate

@CreateUserAccounts
@ClearDatabase
Scenario: Authorisation with my secret account key and IP Address
	Given I am making web request
	When I want temp credetials supplying an IP Address and my secret account key
	Then I should receive temp credentials
