using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;


namespace Games_Logic_Library {
    public class Twenty_One_Game {
        private CardPile cardPile;
        private Hand[] hands;
        private int[] totalPoints = new[] { 0, 0 };
        public int[] numOfGamesWon = new[] { 0, 0 };
        private int numOfUserAcesWithValueOne;
        const int NUM_OF_PLAYERS = 2;
        const int NUM_OF_CARDS = 2;
        public void SetUpGame() {
            cardPile = new CardPile(true);
            cardPile.Shuffle();
            hands = new Hand[NUM_OF_PLAYERS];
            hands[0] = new Hand(cardPile.DealCards(NUM_OF_CARDS));
            hands[1] = new Hand(cardPile.DealCards(NUM_OF_CARDS));
            numOfUserAcesWithValueOne = 0;
        }

        public int CalculateHandTotal(int who) {
            int total = 0;
            int aceCount = 0;
            foreach (Card card in hands[who]) {
                if (who == 0 && card.GetFaceValue() == FaceValue.Ace && aceCount <= numOfUserAcesWithValueOne) {
                    aceCount++;
                    total++;
                } else {
                    switch(card.GetFaceValue()) {
                        case FaceValue.Ace:
                            total += 11;
                            break;
                        case FaceValue.Two:
                            total += 2;
                            break;
                        case FaceValue.Three:
                            total += 3;
                            break;
                        case FaceValue.Four:
                            total += 4;
                            break;
                        case FaceValue.Five:
                            total += 5;
                            break;
                        case FaceValue.Six:
                            total += 6;
                            break;
                        case FaceValue.Seven:
                            total += 7;
                            break;
                        case FaceValue.Eight:
                            total += 8;
                            break;
                        case FaceValue.Nine:
                            total += 9;
                            break;
                        case FaceValue.Ten:
                        case FaceValue.Jack:
                        case FaceValue.Queen:
                        case FaceValue.King:
                            total += 10;
                            break;
                    }
                }

            }
            totalPoints[who] = total;
            return total;
        }
        public Card DealOneCardTo(int who) {
            Card card = cardPile.DealOneCard();
            hands[who].Add(card);
            return card;
        }

        public void PlayForDealer() {
            DealOneCardTo(1);
        }

        public Hand GetHand(int who) {
            return hands[who];
        }

        public int GetTotalPoints(int who) {
            return totalPoints[who];
        }

        public int GetNumberOfGamesWon(int who) {
            return numOfGamesWon[who];
        }
        public int GetNumOfUserAcesWithValueOne() {
            return numOfUserAcesWithValueOne;
        }

        public void IncrementNumOfUserAcesWithValueOne() {
            numOfUserAcesWithValueOne++;
        }

        public void ResetTotals() {
            for (int i = 0; i < 2; i++) {
                numOfGamesWon[i] = 0;
                totalPoints[i] = 0;
            }
        }
    }
}
