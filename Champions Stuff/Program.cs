using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Champions_Stuff
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SpeedTest();
            LiftTest();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        /// <summary>
        /// Takes in the SPD characteristic value and returns a set of phases that speed can act one
        /// </summary>
        /// <param name="speed">The value of the speed characteristic</param>
        /// <returns>Returns a HashSet of integers for the phases the given speed can act on NOTE: It does not hold index values, but real values</returns>
        public static HashSet<int> SpeedPhases(int speed)
        {
            HashSet<int> ret = new HashSet<int>();

            decimal increment, count;

            if (speed <= 0)
                increment = 100;
            else if (speed == 1)
                increment = 7;
            else
                increment = speed <= 11 ? (12 / (decimal)speed) : 1;

            count = increment;

            while(count <= 12)
            {
                ret.Add((int)Math.Ceiling(count));
                count += increment;
            }

            return ret;
        }

        static void SpeedTest()
        {
            string line = "\t";
            for(int i = 1; i <= 12; ++i)
            {
                line += string.Format("{0}\t", i);
            }

            Console.WriteLine(line);
            for(int i = 1; i <= 12; ++i)
            {
                line = "";
                line += string.Format("{0}:\t", i);
                HashSet<int> track = Program.SpeedPhases(i);

                for (int j = 1; j <= 12; ++j)
                {
                    line += string.Format("{0}\t", track.Contains(j) ? 'X' : ' ');
                }

                Console.BackgroundColor = i % 2 == 1 ? ConsoleColor.DarkBlue : ConsoleColor.Black;
                Console.WriteLine(line);
            }    
        }

        public static int Lift(int strength)
        {
            int weight = 0;

            switch(strength)
            {
                case 0:
                    weight = 0;
                    break;
                case 1:
                    weight = 8;
                    break;
                case 2:
                    weight = 16;
                    break;
                case 3:
                    weight = 25;
                    break;
                case 4:
                    weight = 38;
                    break;
                default:
                    weight = (int)(50 * Math.Pow(2, strength/5.0 - 1));
                    if(weight % 5 != 0)
                        weight = (int)Math.Floor(weight / 10m) * 10;
                    break;

            }

            return weight;
        }

        public static int Throw(int strength)
        {
            int dist = 0;

            switch (strength)
            {
                case 0:
                    dist = 0;
                    break;
                case 1:
                    dist = 2;
                    break;
                case 2:
                    dist = 3;
                    break;
                case 3:
                    dist = 4;
                    break;
                case 4:
                    dist = 6;
                    break;
                default:
                    dist = (int)(8 * strength / 5.0);
                    break;

            }

            return dist;
        }

        public static decimal Damage(int strength)
        {
            decimal dice = (strength / 5) + (strength % 5 >= 3 ? .5m : 0);
            return dice;
        }

        static void LiftTest()
        {
            Console.WriteLine("Strength\tLift(kg)\t\tDamage\t\tThrow\t\t");
            int[] strengths = new int[]
            {
                0,1,2,3,4,5,8,10,13,15,
                18,20,23,25,28,30,35,40,
                45,50,55,60,65,70,75,80,
                85,90,95,100
            };

            foreach(int strength in strengths)//Enumerable.Range(0, 101))
            {
                
                Console.WriteLine(string.Format("{0}\t\t{1:N0}\t\t{2}d6\t\t{3}", strength, Lift(strength), Damage(strength), Throw(strength)));
            }    
        }
    }
}
