using System;

namespace Chapter07._01.OOP.DeckOfCard
{
    public class BlackJackCard : Card
    {
        public BlackJackCard(int value, Suit suit) : base(value, suit)
        {
        }

        public override int GetValue()
        {
            if (IsAce())
            {
                return MinValue();
            }
            if (IsFaceCard())
            {
                return 10;
            }
            return FaceValue;
        }

        public int MinValue()
        {
            if (IsAce())
            {
                return 1;
            }
            return FaceValue;
        }

        public int MaxValue()
        {
            if (IsAce())
            {
                return 11;
            }
            return FaceValue;
        }

        public bool IsAce()
        {
            return FaceValue == 1;
        }

        public bool IsFaceCard()
        {
            return FaceValue > 11 && FaceValue <= 13;
        }
    }
}
