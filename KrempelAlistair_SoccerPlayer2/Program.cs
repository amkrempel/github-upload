using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace KrempelAlistair_Soccer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Alistair Krempel
            // CISY 2133 Midterm Exam Part 2
            // 03-08-2019

            string inputStr;
            int temp; //required for TryParse because object fields can't be out parameters

            SoccerPlayer.DisplayMotto();

            //instantiating two player objects
            SoccerPlayer player1 = new SoccerPlayer("Katie Schuler", 1, 24, 19);
            SoccerPlayer player2 = new SoccerPlayer();

            //displaying their info
            SoccerPlayer.Display(player1);
            SoccerPlayer.Display(player2);

            //Instantiating 2 more players
            SoccerPlayer player3 = new SoccerPlayer();
            player3.Name = "Joe Johnson";
            player3.Jersey = 14;
            player3.Goals = 10;
            player3.Assists = 32;

            SoccerPlayer player4 = new SoccerPlayer();
            //gets and assigns name
            Write("Please enter the fourth player's name: ");
            inputStr = ReadLine();
            player4.Name = inputStr;

            //gets and assigns jersey #
            Write("Please enter the fourth player's jersey number: ");
            inputStr = ReadLine();
            Int32.TryParse(inputStr, out temp); //tries to convert user input to int
                                                //puts result in a temp variable
            player4.Jersey = temp; //moves temp variable into the player object field

            //gets and assigns # of goals
            Write("Please enter the fourth player's goals this season: ");
            inputStr = ReadLine();
            Int32.TryParse(inputStr, out temp); 
            player4.Goals = temp;

            //gets and assigns # of assists
            Write("Please enter the fourth player's assists this season: ");
            inputStr = ReadLine();
            Int32.TryParse(inputStr, out temp);
            player4.Assists = temp;
            WriteLine();

            //Displaying their info
            SoccerPlayer.Display(player3);
            SoccerPlayer.Display(player4);

            //This player will invoke the 2 parameter overloaded constructor
            SoccerPlayer player5 = new SoccerPlayer("Keisha Jones", 8);
            SoccerPlayer.Display(player5);

            //test cases
            //SoccerPlayer playerT = new SoccerPlayer("Buff Drinklots", 42, 5, 77);
            //SoccerPlayer.Display(playerT);

            ReadKey();
        }
    }

    class SoccerPlayer
    {
        //declaring private fields
        private string name;
        private int jersey;
        private int goals;
        private int assists;
        private int bonus;
        const string MOTTO = "***** Always do what you're afraid to do! *****\n";
        const int MIN_BONUS_LEVEL = 20;

        //defining public accessors
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Jersey
        {
            get
            {
                return jersey;
            }
            set
            {
                jersey = value;
            }
        }

        public int Goals
        {
            get
            {
                return goals;
            }
            set
            {
                goals = value;
            }
        }

        public int Assists
        {
            get
            {
                return assists;
            }
            set
            {
                assists = value;
            }
        }

        //new better getter (no setter!)
        public double Bonus
        {
            get
            {
                if (Goals > MIN_BONUS_LEVEL)
                {
                    bonus = 1000;
                }
                else bonus = 0;

                return bonus;
            }
        }


        //constructor with 4 parameters
        public SoccerPlayer(string aName, int aJersey, int aGoals, int aAssists)
        //using these name variations to pass arguments so I don't get confused
        {
            //each parameter is assigned to its public field
            Name = aName;
            Jersey = aJersey;
            Goals = aGoals;
            Assists = aAssists;
        }

        //constructor with 2 parameters
        public SoccerPlayer(string aName, int aJersey)
        {
            //parameters are assigned to public fields or initialized to 0
            Name = aName;
            Jersey = aJersey;
            Goals = 0;
            Assists = 0;
        }

        //default constructor (0 parameters)
        public SoccerPlayer()
        {
            //each public field is initialized
            Name = "_";
            Jersey = 0;
            Goals = 0;
            Assists = 0;
        }

        //Motto display method is static to be shared by all instances
        public static void DisplayMotto()
        {
            WriteLine(MOTTO);
        }

        //Displays player info fields for an object passed to it
        public static void Display(SoccerPlayer aPlayer)
        {
            WriteLine("Player {0}, {1}, has {2} goals and {3} assists!", aPlayer.Jersey, aPlayer.Name, aPlayer.Goals, aPlayer.Assists);
            //displays different message if player did/didn't earn the bonus
            if (aPlayer.Bonus > 0)
            {
                WriteLine("{0} has earned a {1:C} bonus!", aPlayer.Name, aPlayer.Bonus);
            }
            else
            {
                WriteLine("{0}'s current bonus is {1:C}. Keep practicing!", aPlayer.Name, aPlayer.Bonus);
            }
            WriteLine("***** Go, {0}!! *****\n", aPlayer.Name);
        }
    }
}
