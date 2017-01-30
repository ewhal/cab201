using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public static class Two_Up_Game {
        private static Coin coin1;
        private static Coin coin2;
        private static int playersScore;
        private static int computersScore;

        public static void SetUpGame() {
            coin1 = new Coin();
            coin2 = new Coin();
            playersScore = 0;
            computersScore = 0;
        }

        public static void TossCoins() {
            coin1.Flip();
            coin2.Flip();
        }

        public static string TossOutcome() {
            if (coin1.IsHeads() && coin2.IsHeads()) {
                playersScore++;
                return "Heads";
            } else if (coin1.IsHeads() == false && coin2.IsHeads() == false) {
                computersScore++;
                return "Tails";
            } else {
                return "Odds";
            }

        }

        public static bool IsHeads(int whichCoin) {
            if (whichCoin == 1) {
                return coin1.IsHeads();
            } else {
                return coin2.IsHeads();
            }
        }

        public static int GetPlayersScore() {
            return playersScore;
        }

        public static int GetComputerScore() {
            return computersScore;
        }


    }
}
