Feature: Security
	In order to very a phase
	As a user
	I want my phase to be securely verified


Scenario: Verify security with correct phase
	Given I have supplied a phase
	And I have generated a salt
	When verifying the hashed phases with a correct phase
	Then the result should be a match


Scenario: Verify security with incorrect phase
	Given I have supplied a phase
	And I have generated a salt
	When verifying the hashed phases with an incorrect phase
	Then the result should not be a match
