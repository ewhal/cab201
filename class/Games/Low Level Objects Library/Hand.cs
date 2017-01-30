using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Low_Level_Objects_Library {
    public class Hand : IEnumerable {
        private List<Card> hand = new List<Card>();

        public int GetCount() {
            return hand.Count;
        }

        public Hand() {

        }
        public Hand(List<Card> cards) {
            hand.AddRange(cards);
        }
        public Card GetCard(int index) {
            return hand[index];

        }
        public void Add(Card card) {
            hand.Add(card);
        }

        public bool Contains(Card card) {
            return hand.Contains(card);
        }
        public bool Remove(Card card) {
            return hand.Remove(card);
        }
        public void RemoveAt(int index) {
            hand.RemoveAt(index);
        }
        public void Sort() {
            hand.Sort();
        }

        public IEnumerator GetEnumerator() {
            return hand.GetEnumerator();
        }


    }
}
