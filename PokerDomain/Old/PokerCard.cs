
using System;

public class OldPokerCard
{
    public OldPokerCard(string card)
    {
        Value = ToNumeric(card.Substring(0, 1));
        Suit = card.Substring(1, 1);
    }

    public int Value { get; private set; }
    public string Suit { get; private set; }

    private int ToNumeric(string value)
    {
        int v;
        if (int.TryParse(value, out v)) return v;

        switch (value)
        {
            case "T": return 10;
            case "J": return 11;
            case "Q": return 12;
            case "K": return 13;
            case "A": return 14;
            default: throw new Exception("Unknown card value '" + value + "'");
        }
    }
}
