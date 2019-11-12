Feature: Another PokerService
	In order to determine which player wins the pot
	As a dealer
	I want to be told the winning poker hand

Scenario: Royal Flush wins from Four of a Kind
	Given a Royal Flush
	And a Four of a Kind
	When the players play their cards
	Then Royal Flush wins

Scenario: Two Pairs wins from One Pair
	Given a Two Pairs
	And a One Pair
	When the players play their cards
	Then Two Pairs wins
