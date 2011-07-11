Feature: Get Ratings
In order to see Ratings
As a user of Ratings
I want to be able to see ratings


@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Getting ratings
Given I am making web request
When getting rating for my account
Then I should be able to see all my ratings



@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Getting ratings between ratings
Given I am making web request
When getting ratings for my account and between 7 and 10
Then I should be able to see all my ratings for my query


@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Getting ratings for my custom parameter
Given I am making web request
When getting ratings for my account and and my custom parameter
Then I should be able to see all my ratings for my custom query


@CreateUserAccounts
@AddRatings
@ClearDatabase
Scenario: Get rating by unique key
Given I am making web request
When getting ratings for my account and unique key
Then I should be able to see my rating for my key

