using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter07._01.OOP.DeckOfCard
{
    public class BlackJackHand<T> : Hand<T> where T : BlackJackCard
    {
        public BlackJackHand()
        {

        }

        public override int Score()
        {
            // calculates score based on available scores;
            var scores = GetAvailableScores();

            var minScore = int.MaxValue;
            var maxScore = int.MinValue;

            foreach (var score in scores)
            {
                if (score > 21 && score < minScore)
                {
                    minScore = score;
                }
                else if (score <= 21 && score > maxScore)
                {
                    maxScore = score;
                }
            }

            return maxScore == int.MinValue ? minScore : maxScore;
        }

        public bool IsBusted()
        {
            return Score() > 21;
        }

        public bool Is21()
        {
            return Score() == 21;
        }

        public bool IsBlackJack()
        {
            if (Cards.Count == 2)
            {
                var firstCard = Cards[0];
                var secondCard = Cards[1];

                return ((firstCard.IsAce() && secondCard.IsAce())
                    || (firstCard.IsAce() && secondCard.IsFaceCard())
                    || (firstCard.IsFaceCard() && secondCard.IsAce()));
            }

            return false;
        }

        private List<int> GetAvailableScores()
        {
            var results = new List<int>();

            if (IsBlackJack())
            {
                results.Add(21);
                return results;
            }

            var total = new List<List<int>>() { new List<int>() };

            foreach (var item in Cards)
            {
                if (item.IsAce())
                {
                    foreach (var totalItem in total)
                    {
                        var newList = totalItem.ToArray().ToList();
                        totalItem.Add(item.MinValue());
                        newList.Add(item.MaxValue());
                        total.Add(newList);
                    }
                }
                else
                {
                    foreach (var totalItem in total)
                    {
                        totalItem.Add(item.GetValue());
                    }
                }
            }
            foreach (var item in total)
            {
                var sum = 0;
                foreach (var score in item)
                {
                    sum += score;
                }
                results.Add(sum);
            }

            return results;
        }
    }
}
