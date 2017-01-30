using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public class Crazy_Eights_Game {
        /// <summary>
        /// cardPile of cards
        /// </summary>
        private CardPile cardPile;
        /// <summary>
        /// Array of hand
        /// </summary>
        private Hand[] hands;
        /// <summary>
        /// Number of hands
        /// </summary>
        const int NUM_OF_PLAYERS = 3;
        /// <summary>
        /// Number of Cards to deal to the players
        /// </summary>
        const int NUM_OF_CARDS = 8;
        /// <summary>
        /// current suit of the top card
        /// </summary>
        private Suit current;

        /// <summary>
        /// Initalizes the values of the game
        /// </summary>
        public void SetUpGame() {
            cardPile = new CardPile(true);
            cardPile.Shuffle();
            hands = new Hand[NUM_OF_PLAYERS];
            hands[0] = new Hand(cardPile.DealCards(NUM_OF_CARDS));
            hands[1] = new Hand(cardPile.DealCards(NUM_OF_CARDS));
            hands[2] = new Hand();
        }
        /// <summary>
        /// Draws a card and adds it to a players hand
        /// </summary>
        /// <param name="who"></param>
        /// <returns>card</returns>
        public Card DrawTopCard(int who) {
            if (cardPile.GetCount() == 0) {
                cardPile = new CardPile(true);
                cardPile.Shuffle();
            }
            Card card = cardPile.DealOneCard();
            hands[who].Add(card);
            return card;
        }
        /// <summary>
        /// Adds a new top card to the discard pile
        /// </summary>
        /// <param name="card"></param>
        /// <param name="who"></param>
        /// <returns></returns>
        public Card NewTopCard(Card card, int who) {
            hands[2].RemoveAt(0);
            hands[who].Remove(card);
            hands[2].Add(card);
            SetCurrentSuit(card.GetSuit());
            return card;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public Hand GetHand(int who) {
            return hands[who];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="who"></param>
        public void SortHand(int who) {
            hands[who].Sort();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public int GetHandSize(int who) {
            return hands[who].GetCount();
        }
        /// <summary>
        /// Get the current suit
        /// </summary>
        /// <returns></returns>
        public Suit GetCurrentSuit() {
            return current;
        }
        /// <summary>
        /// Sets the current suit
        /// </summary>
        /// <param name="suit"></param>
        public void SetCurrentSuit(Suit suit) {
            current = suit;
        }
        /// <summary>
        /// Get the suit of the top card from a hand
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public Suit GetTopSuit(int who) {
            return GetTopCard(who).GetSuit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public FaceValue GetTopFaceValue(int who) {
            return GetTopCard(who).GetFaceValue();
        }
        /// <summary>
        /// Get the top card from a hand
        /// </summary>
        /// <param name="who"></param>
        /// <returns></returns>
        public Card GetTopCard(int who) {
            return hands[who].GetCard(0);
        }
        /// <summary>
        /// Check to see if any moves are available
        /// </summary>
        /// <param name="who"></param>
        /// <returns>moves bool</returns>
        public bool GetAvailableMoves(int who) {
            bool moves = false;
            foreach (Card card in GetHand(who)) {
                if (card.GetFaceValue() == GetTopFaceValue(2)) {
                    moves = true;
                    break;
                } else if (card.GetSuit() == GetTopSuit(2)) {
                    moves = true;
                    break;
                } else if (card.GetFaceValue() == FaceValue.Eight) {
                    moves = true;
                    break;
                } else {
                    moves = false;
                }
            }
            return moves;
        }
        /// <summary>
        /// Plays for the computer
        /// </summary>
        public void PlayForComputer() {
            bool done = false;
            foreach (Card card in GetHand(1)) {
                if (card.GetFaceValue() == GetTopFaceValue(2)) {
                    NewTopCard(card, 1);
                    SetCurrentSuit(card.GetSuit());
                    done = false;
                    break;
                } else if (card.GetSuit() == GetTopSuit(2)) {
                    NewTopCard(card, 1);
                    done = false;
                    break;
                } else if (card.GetFaceValue() == FaceValue.Eight) {
                    NewTopCard(card, 1);
                    done = false;
                    break;
                } else {

                    done = true;
                }
            }
            if (done) {
                DrawTopCard(1);
            }

        }
    }
}

