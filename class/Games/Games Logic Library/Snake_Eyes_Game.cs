using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;



namespace Games_Logic_Library {
    public static class Snake_Eyes_Game {
        private static int rollTotal;
        private static int playerTotal;
        private static int houseTotal;
        private static int possiblePoints;
        private static Die[] dice;

        public static void SetUpGame() {
            dice = new Die[2];
            dice[0] = new Die();
            dice[1] = new Die();
            playerTotal = 0;
            rollTotal = 0;
            houseTotal = 0;
            possiblePoints = 0;
        }
        public static bool FirstRoll() {
            dice[0].RollDie();
            dice[1].RollDie();
            possiblePoints = 0;

            rollTotal = dice[0].GetFaceValue() + dice[1].GetFaceValue();
            if (rollTotal == 2) {
                playerTotal = playerTotal + 2;
                return false;
            } else if (rollTotal == 7 || rollTotal == 11) {
                playerTotal = playerTotal + 1;
                return false;
            } else if (rollTotal == 3 || rollTotal == 12) {
                houseTotal = houseTotal + 1;
                return false;
            } else {
                possiblePoints = rollTotal;
                return true;
            }

        }

        public static bool AnotherRoll() {
            dice[0].RollDie();
            dice[1].RollDie();
            rollTotal = dice[0].GetFaceValue() + dice[1].GetFaceValue();
            if (rollTotal == 2) {
                playerTotal = playerTotal + 2;
                return false;
            } else if (rollTotal == possiblePoints) {
                playerTotal += possiblePoints;
                return false;
            } else if (rollTotal == 7) {
                houseTotal += 2;
                return false;
            } else {
                return true;
            }
        }

        public static int GetDiceFacevalue(int whichDie) {
            return dice[whichDie].GetFaceValue();
        }

        public static int GetPlayersPoints() {
            return playerTotal;
        }

        public static int GetHousePoints() {
            return houseTotal;
        }

        public static int GetPossiblePoints() {
            return possiblePoints;
        }

        public static int GetRollTotal() {
            return rollTotal;
        }

        public static string GetRollOutcome() {
            if (rollTotal == 2 && possiblePoints == 0) {
                return "Won";
            } else if (rollTotal == possiblePoints) {
                return "Won";
            } else if (rollTotal == 7 && possiblePoints != 0) {
                return "Lost";
            } else if ((rollTotal == 7 || rollTotal == 11) && possiblePoints == 0) {
                return "Won";
            } else if ((rollTotal == 3 || rollTotal == 12) && possiblePoints == 0) {
                return "Lost";
            } else {
                return "No outcome";
            }

        }
    }
}
