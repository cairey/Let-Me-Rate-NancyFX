Feature: Add Rating
In order to see Ratings
As a user of Ratings
I want to be able to see ratings

Scenario: adding a rating
Given I am using Ratings
When adding a rating for my account
Then I should be able to add my rating based on the score system for my account
Then I should be able to see the rating i added
