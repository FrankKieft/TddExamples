using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerExample.Domain.Old
{
    public class OldPokerHand
    {
        public OldPokerHand(string hand)
        {
            OriginalCardCodes = hand;
            Cards = OriginalCardCodes.Split(' ').Select(x => new OldPokerCard(x)).ToList();
        }

        public List<OldPokerCard> Cards { get; set; }
        public string OriginalCardCodes { get; }

        public OldPokerResult CompareWith(OldPokerHand hand)
        {
            var result = OldPokerResult.Tie;

            if (!TryGetResult(hand.Cards, GetStraightFlush, ref result) &&
                !TryGetResult(hand.Cards, GetFourOfAKind, ref result) &&
                !TryGetResult(hand.Cards, GetFullHouse, ref result) &&
                !TryGetResult(hand.Cards, GetFlush, ref result) &&
                !TryGetResult(hand.Cards, GetStraight, ref result) &&
                !TryGetResult(hand.Cards, GetThreeOfAKind, ref result) &&
                !TryGetResult(hand.Cards, GetTwoPairs, ref result) &&
                !TryGetResult(hand.Cards, GetPair, ref result) &&
                !TryGetResult(hand.Cards, GetSortedHand, ref result))
            {
            }

            return result;
        }

        private bool TryGetResult(List<OldPokerCard> cards, Func<List<OldPokerCard>, List<OldPokerCard>> get, ref OldPokerResult r)
        {
            var p = get(Cards);
            var o = get(cards);
            if (p == null && o == null) return false;

            var i = 0;
            while (i < 5 && r == OldPokerResult.Tie)
            {
                if (p != null && (o == null || p[i].Value > o[i].Value)) r = OldPokerResult.Win;
                if (o != null && (p == null || p[i].Value < o[i].Value)) r = OldPokerResult.Loss;
                i++;
            }
            return r != OldPokerResult.Tie;
        }

        private List<OldPokerCard> GetStraightFlush(List<OldPokerCard> cards)
        {
            var f = GetFlush(cards);
            if (f != null && GetStraight(cards) != null) return f;
            return null;
        }

        private List<OldPokerCard> GetStraight(List<OldPokerCard> cards)
        {
            var r = cards.OrderByDescending(x => x.Value).ToList();
            if (r[0].Value - r[1].Value == 1 &&
                r[1].Value - r[2].Value == 1 &&
                r[2].Value - r[3].Value == 1 &&
                r[3].Value - r[4].Value == 1)
            {
                return r;
            }
            return null;
        }

        private List<OldPokerCard> GetFlush(List<OldPokerCard> cards)
        {
            if (cards.GroupBy(x => x.Suit).ToList().Count == 1)
            {
                return GetSortedHand(cards, cards.OrderByDescending(x => x.Value));
            }
            return null;
        }

        private List<OldPokerCard> GetFourOfAKind(List<OldPokerCard> cards)
        {
            var r = cards.GroupBy(x => x.Value).FirstOrDefault(x => x.Count() == 4);
            if (r != null)
            {
                return GetSortedHand(cards, cards.Where(x => x.Value == r.Key));
            }
            return null;
        }

        private List<OldPokerCard> GetPair(List<OldPokerCard> cards)
        {
            var r = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ToList();
            if (r.Count == 4)
            {
                return GetSortedHand(cards, cards.Where(x => x.Value == r[0].Key));
            }
            return null;
        }

        private List<OldPokerCard> GetTwoPairs(List<OldPokerCard> cards)
        {
            var r = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ToList();
            if (r.Count == 3 && r[0].Count() == 2)
            {
                return GetSortedHand(cards, cards.Where(x => x.Value == r[0].Key),
                                            cards.Where(x => x.Value == r[1].Key));
            }
            return null;
        }

        private List<OldPokerCard> GetThreeOfAKind(IEnumerable<OldPokerCard> cards)
        {
            var r = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ToList();
            if (r.Count == 3 && r[0].Count() == 3)
            {
                return GetSortedHand(cards, cards.Where(x => x.Value == r[0].Key));
            }
            return null;
        }

        private List<OldPokerCard> GetFullHouse(IEnumerable<OldPokerCard> cards)
        {
            var r = cards.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ToList();
            if (r.Count == 2 && r[0].Count() == 3 && r[1].Count() == 2)
            {
                return GetSortedHand(cards, cards.Where(x => x.Value == r[0].Key),
                                            cards.Where(x => x.Value == r[1].Key));
            }
            return null;
        }

        private List<OldPokerCard> GetSortedHand(IEnumerable<OldPokerCard> hand, params IEnumerable<OldPokerCard>[] ranges)
        {
            var r = new List<OldPokerCard>();
            ranges.ToList().ForEach(x => r.AddRange(x.OrderByDescending(y => y.Value)));
            r.AddRange(hand.Where(x => !r.Contains(x)).OrderByDescending(x => x.Value));
            return r;
        }

        private List<OldPokerCard> GetSortedHand(List<OldPokerCard> hand)
        {
            return hand.OrderByDescending(x => x.Value).ToList();
        }
    }
}