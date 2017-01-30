using System;
using System.Globalization;

namespace TrainTimetable {

    enum Stations { Central, Roma_Street, Milton, Auchenflower, Toowong, Taringa, Indooroopilly };

    class Program {

        public const int NUMBER_OF_TRAINS = 76;
        public const int NUMBER_OF_STATIONS = 7;
        static int[,] timeTable = new int[NUMBER_OF_STATIONS, NUMBER_OF_TRAINS];

        static string departFrom = "\n Which station are you leaving from?\n"
                              + "\n1) Central"
                              + "\n2) Roma Street"
                              + "\n3) Milton"
                              + "\n4) Auchenflower"
                              + "\n5) Toowong"
                              + "\n6) Taringa"
                              + "\n\nEnter your option(1-6 or 0 to exit): ";

        static string arriveAt = "\n Which station are you going to?\n"
                           + "\n1) Roma Street"
                           + "\n2) Milton"
                           + "\n3) Auchenflower"
                           + "\n4) Toowong"
                           + "\n5) Taringa"
                           + "\n6) Indooroopilly"
                           + "\n\nEnter your option(1-6 or 0 to exit): ";

        static void Main() {
            const int EXIT = 0;

            // ********** Do not remove the following statement ******************
            timeTable = Timetables.CreateTimeTable();

            //*********** Start your code for Main below this line  ******************
            int depart = GetStation(departFrom, -1);

            // check if user wants to exit program 
            if (depart == EXIT) {
                ExitProgram();
                return;
            }
            int arrive = GetStation(arriveAt, depart);
            // check if user wants to exit program 
            if (arrive == EXIT) {
                ExitProgram();
                return;
            }
            // correct depart array location
            depart = depart - 1;

            int time = GetArrivalAndSearch(timeTable, arrive);

            PrintStation(timeTable, arrive, depart, time);
            
            ExitProgram();
        }// end Main

        /// <summary>
        /// Prints the two lines of station information to the user.
        /// </summary>
        /// <param name="timeTable"></param>
        /// <param name="arrive"></param>
        /// <param name="depart"></param>
        /// <param name="array"></param>
        static void PrintStation(int[,] timeTable, int arrive, int depart, int array ) {
            Console.WriteLine("To arrive at {0} by {1}", (Stations)arrive, ConvertTime(timeTable[arrive, array]));
            Console.WriteLine("You have to catch the {0} train from {1} station", ConvertTime(timeTable[depart, array]), (Stations)depart);
        }

        /// <summary>
        /// Converts an int in hhmm format to 12 hour HH:mm TT format
        /// </summary>
        /// <param name="time"></param>
        /// <returns>12 hour time in string format HH:mm TT</returns>
        static string ConvertTime(int time) {
            string s = time.ToString();
            char[] numbers = s.ToCharArray();
            string hours;
            string minutes;
            string output;
            if (numbers.Length == 4) {
                hours = numbers[0].ToString() + numbers[1].ToString();
                minutes = numbers[2].ToString() + numbers[3].ToString();
            } else {
                hours = numbers[0].ToString();
                minutes = numbers[1].ToString() + numbers[2].ToString();              
            }

            if (Convert.ToInt32(hours) <= 12) {
                output = hours + ":" + minutes + " AM";
            } else {
                int tempHours = int.Parse(hours) - 12;
                output = tempHours.ToString() + ":" + minutes + " PM";
            }

            return output;
        }
        /// <summary>
        /// Get the Station input
        /// </summary>
        /// <param name="message"></param>
        /// <param name="station"></param>
        /// <returns>Station number between 0-6</returns>
        static int GetStation(string message, int station) {
            int output;
            bool ok;

            do {
                Console.Write(message);
                ok = int.TryParse(Console.ReadLine(), out output);

                if (output > 6 || output < station) {
                    ok = false;
                }
            } while (!ok);
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeTable"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        static int GetArrivalAndSearch(int[,] timeTable, int depart) {
            int output = 0;
            bool ok = true;
            do {

                int hoursAndMinutes = GetArrivalTime();
                
                output = FindDepartTime(timeTable, depart, hoursAndMinutes);
                ok = true;
                if (output == -1) {
                    Console.WriteLine("\tCannot catch train at this time");
                    ok = false;
                }

            } while (!ok);

            return output;
        }
        /// <summary>
        /// Takes in arrival time in hh:mm
        /// </summary>
        /// <returns> Arrival time in hhmm format</returns>
        static int GetArrivalTime() {
            bool ok;
            int output;
            do {
                Console.Write("Arrival time: ");
                string rawInput = Console.ReadLine();
                string[] userArrivalTime = rawInput.Split(':');
                // parse the strings into an int
                ok = int.TryParse(userArrivalTime[0].ToString() + userArrivalTime[1].ToString(), out output);

            } while (!ok);
            return output;
        }
        /// <summary>
        /// Binary search function which checks timeTable for arrivalTime
        /// </summary>
        /// <param name="timeTable"></param>
        /// <param name="depart"></param>
        /// <param name="arrival"></param>
        /// <returns> Int location of found time or -1 if nothing is found </returns>
        static int FindDepartTime(int [,] timeTable, int station, int arrivalTime) {
            int lower = 0;
            int upper = NUMBER_OF_TRAINS;
            int middle;

            while (lower <= upper) {
                middle = (lower + upper) / 2;
                if (timeTable[station, middle] == arrivalTime) {
                    return middle;
                } else if (timeTable[station, middle] > arrivalTime) {
                    upper = middle - 1;
                } else if (timeTable[station, middle] < arrivalTime) {
                    lower = middle + 1;
                }
            }
            return -1;
            
        }
        /// <summary>
        /// Will exit the project once the user has pressed any key
        /// </summary>
        static void ExitProgram() {
            Console.Write("\n\n\t Press any key to terminate program ...");
            Console.ReadKey();
        }//end ExitProgram

    }//end class
}//end nameSpace
