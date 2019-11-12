Feature: PokerService
	In order to determine which player wins the pot
	As a dealer
	I want to be told the winning poker hand

Scenario: Royal Flush wins from Four of a Kind
	Given poker hand JH AH TH KH QH 
	And poker hand JC 7H JS JD JH 
	When the players play their cards
	Then the first hand is the winning hand

Scenario: Two pairs wins from One Pair
	Given poker hand AS 3C KH AD KC 
	And poker hand 8C 4S KH JS 4D 
	When the players play their cards
	Then the first hand is the winning hand

