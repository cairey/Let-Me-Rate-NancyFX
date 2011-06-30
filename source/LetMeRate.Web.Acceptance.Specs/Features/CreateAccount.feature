Feature: Create Account
In order to manage my account
As a user of ratings
I want to be able to create an account

@Clear
Scenario: Create Account
Given I am making web request
When creating an account with my email and password
Then I should be able to see my created account
