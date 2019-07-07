using System;
using System.Collections.Generic;

namespace Chapter07._01.OOP.DeckOfCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public enum Suit
    {
        Club = 0,
        Dinamond,
        Heart,
        Spade
    }

    public abstract class Card
    {
        public bool IsAvailable { get; set; }

        protected int FaceValue { get; set; }
        protected Suit Suit { get; set; }


        public Card(int value, Suit suit)
        {
            FaceValue = value;
            Suit = suit;
        }

        public abstract int GetValue();

    }

    public abstract class Hand<T> where T: Card
    {
        protected List<T> Cards { get; set; }

        public void AddCard(T card)
        {
            Cards.Add(card);
        }

        public abstract int Score();
    }

    public class Deck<T> where T:Card
    {
        private List<T> AllCards = new List<T>();
        private int dealtIndex = 0;

        public void Shuffe()
        {

        }

        public int RemainingCards()
        {
            return AllCards.Count - dealtIndex;
        }

    }
}
