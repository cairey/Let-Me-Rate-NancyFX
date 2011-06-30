Feature: Add Rating
In order to see Ratings
As a user of Ratings
I want to be able to see ratings


@CreateUserAccount
@Clear
Scenario: adding a rating
Given I am making web request
When adding a rating for my account
Then I should be able to see the rating i added
