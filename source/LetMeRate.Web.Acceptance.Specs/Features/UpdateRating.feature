Feature: Update ratings
In order for my rating to be updated.
As a user of ratings
I want to send an updated rating.

@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Updating a rating when it exists
Given I am making web request
When I update my rating that exists
Then my rating should be updated


@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Updating a rating when it does not exist
Given I am making web request
When I update my rating that does not exists
Then my rating should not be updated