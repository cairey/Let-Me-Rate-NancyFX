Feature: Account Key Generation
	In order for users to access Let Me Rate securely
	As a user of ratings
	I want to be able to generate a unqique account key


Scenario: Generate Account Key
	Given I have an account key generator
	When I generate an account key
	Then I should get back a unique key
