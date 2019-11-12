using PokerExample.Domain.Old;
using System.Collections.Generic;
using System.Linq;

namespace PokerExample.Domain
{
    public class PokerService
    {
        public string GetWinningHand(List<string> pokerHands)
        {
            var hands = pokerHands.Select(x => new OldPokerHand(x));
                
            var highest = hands.First();

            foreach(var hand in hands)
            {
                if (highest.CompareWith(hand) == OldPokerResult.Loss)
                {
                    highest = hand;
                }
            }

            return highest.OriginalCardCodes;
        }
    }
}
