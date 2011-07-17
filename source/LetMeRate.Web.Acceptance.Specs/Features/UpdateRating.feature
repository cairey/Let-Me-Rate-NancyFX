Feature: Update ratings
In order for my rating to be updated.
As a user of ratings
I want to send an updated rating.

@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Add two numbers
Given I am making a web request
When I update my rating
Then my rating should be updated.