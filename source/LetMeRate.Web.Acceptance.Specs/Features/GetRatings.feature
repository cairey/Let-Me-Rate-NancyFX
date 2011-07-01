Feature: Get Ratings
In order to see Ratings
As a user of Ratings
I want to be able to see ratings


#@CreateUserAccounts
#@AddRatings
#@Clear
#Scenario: Getting rattings
#Given I am making web request
#When getting rating for my account
#Then I should be able to see all my ratings



@CreateUserAccounts
@AddRatings
@Clear
Scenario: Getting ratings for my query
Given I am making web request
When getting ratings for my account and query parameters
Then I should be able to see all my ratings for my query