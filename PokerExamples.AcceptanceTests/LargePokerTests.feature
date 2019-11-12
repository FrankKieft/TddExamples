Feature: Large PokerService
	In order to determine which player wins the pot
	As a dealer
	I want to be told the winning poker hand

Scenario: A lot of players
	Given poker hand JH AH TH KH QH 
	And poker hand JC 7H JS JD JH 
	And poker hand 4S 3H 2C 7S 5H
    And poker hand 9D 8H 2C 6S 7H
    And poker hand 2D 6D 9D TH 7D
    And poker hand TS KS 5S 9S AC
    And poker hand KD 6S 9D TH AD
    And poker hand KS 8D 4D 9S 4S
    And poker hand 8C 4S KH JS 4D
    And poker hand QH 8H KD JH 8S
    And poker hand KC 4H KS 2H 8D
    And poker hand KD 4S KC 3H 8S
    And poker hand AH 8S AS KC JH
    And poker hand 3H 4C 4H 3S 2H
    And poker hand 5S 5D 2C KH KC
    And poker hand 3C KH 5D 5S KC
    And poker hand AS 3C KH AD KC
    And poker hand 7C 7S 3S 7H 5S
    And poker hand 7C 7S KH 2H 7H
	And poker hand JH AH TH KH QH
    And poker hand AC KH QH AH AS
    And poker hand 3C 5C 4C 2C 6H
    And poker hand 6S 8S 7S 5H 9H
    And poker hand JS QS 9H TS KH
    And poker hand QC KH TS JS AH
    And poker hand 8C 9C 5C 3C TC
    And poker hand 3S 8S 9S 5S KS
    And poker hand 4C 5C 9C 8C KC
    And poker hand JH 8H AH KH QH
    And poker hand 3D 2H 3H 2C 2D
    And poker hand 2H 2C 3S 3H 3D
    And poker hand KH KC 3S 3H 3D
    And poker hand 5C 6C 3C 7C 4C
    And poker hand JH 9H TH KH QH

	When the players play their cards

	Then the winning hand is JH AH TH KH QH

