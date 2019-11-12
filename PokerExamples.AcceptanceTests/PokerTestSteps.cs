using PokerExample.Domain;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace PokerExample.AcceptanceTests
{

    [Binding]
    public class PokerServiceSteps
    {
        private List<string> _pokerHands;
        private string _winningHand;
        private Dictionary<string, string> _examples;

        [BeforeScenario]
        public void Initialize()
        {
            _pokerHands = new List<string>();

            _examples = new Dictionary<string, string>
            {
                { "Royal Flush","JH AH TH KH QH" },
                { "Four of a Kind","JC 7H JS JD JH" },
                { "One Pair","8C 4S KH JS 4D" },
                { "Two Pairs","AS 3C KH AD KC" }
            };
        }

        [Given(@"a (.*)")]
        public void GivenA(string handRanking)
        {
            if (_examples.ContainsKey(handRanking))
            {
                _pokerHands.Add(_examples[handRanking]);
            }
        }

        [Given(@"poker hand (.*)")]
        public void GivenAPokerHand(string pokerHand)
        {
            _pokerHands.Add(pokerHand);
        }

        [When(@"the players play their cards")]
        public void WhenThePlayersPlayTheirCards()
        {
            var service = new PokerService();

            _winningHand = service.GetWinningHand(_pokerHands);
        }

        [Then(@"the first hand is the winning hand")]
        public void ThenTheFirstHandWins()
        {
            var expected = _pokerHands.First();

            _winningHand.Should().Be(expected);
        }

        [Then(@"(.*) wins")]
        public void ThenWins(string pokerHand)
        {
            var expected = _examples[pokerHand];

            _winningHand.Should().Be(expected);
        }

        [Then(@"the winning hand is (.*)")]
        public void ThenTheWinningHandIsJHHTHKHQH(string expected)
        {
            _winningHand.Should().Be(expected);
        }
    }
}
