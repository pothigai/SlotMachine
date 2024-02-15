namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize points for each category
            const int HORPOINT = 20;
            const int DIAGPOINT = 30;
            const int JACKPOT = 100;
            const int MINBUYIN = 500;
            const int MATRIXSIZE = 3;
            const int MAXNUMBER = 10;
            const int PLAYCOST = 50;
            const string YES = "y";
            const string NO = "n";
            const string WINROW = "r";
            const string WINDIAG = "d";
            const string WINJACKPOT = "j";
            const string NOWIN = "l";

            //Ask the user for a min buy in of 500 points
            Console.WriteLine($"Please enter your buy in amount, the minimum is {MINBUYIN} points: ");
            string playerInput = Console.ReadLine();
            int totalPoints;

            while (!Int32.TryParse(playerInput, out totalPoints) || totalPoints < MINBUYIN)
            {
                Console.WriteLine($"The entered amount either does not meet the minimum buy in amount or is not a valid input, please enter a valid amount of aleast {MINBUYIN}:");
                //totalPoints = Convert.ToInt32(Console.ReadLine());
                playerInput = Console.ReadLine();
            }

            string playAgain = YES;

            while (playAgain == YES)
            {
                //Console.Clear();


                //Checking if user has enough points to play
                if (totalPoints <= 0)
                {
                    Console.WriteLine("You do not have enough points, would you like to top up? (y/n): ");
                    string topUp = Console.ReadLine();

                    while (topUp.ToLower() != YES && topUp.ToLower() != NO)
                    {
                        Console.Write($"Invalid input, please enter {YES}/{NO}:");
                        topUp = Console.ReadLine();
                    }

                    if (topUp.ToLower() == YES)
                    {
                        Console.WriteLine("Please enter the amount of points you want to purchase");
                        totalPoints += Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }

                totalPoints -= PLAYCOST;

                //Generate the random 3x3 matrix for the slot machine
                Random rnd = new Random();

                int[,] slots = new int[MATRIXSIZE, MATRIXSIZE];

                for (int i = 0; i < MATRIXSIZE; i++)
                {
                    for (int j = 0; j < MATRIXSIZE; j++)
                    {
                        slots[i, j] = rnd.Next(MAXNUMBER);
                    }
                }

                for (int i = 0; i < MATRIXSIZE; i++)
                {
                    Console.WriteLine("");

                    for (int j = 0; j < MATRIXSIZE; j++)
                    {
                        Console.Write("   " + slots[i, j]);
                    }
                }

                string winFlag = WINJACKPOT;
                int diagonal1 = slots[0, 0];
                int diagonal2 = slots[0, 2];

                for (int i = 0; i < MATRIXSIZE; i++)
                {
                    for (int j = 0; j < MATRIXSIZE; j++)
                    {
                        if (slots[i, j] != diagonal1)
                        {
                            winFlag = NOWIN;
                            break;
                        }
                    }
                    if (winFlag == NOWIN)
                    {
                        break;
                    }
                }

                if (winFlag == WINJACKPOT)
                {
                    Console.WriteLine($"You won the JACKPOT of a {JACKPOT} points!");
                    totalPoints = totalPoints + JACKPOT;
                }

                for (int i = 0; i < MATRIXSIZE; i++)
                {
                    if (slots[i, 0] == slots[i, 1] && slots[i, 1] == slots[i, 2])
                    {
                        //Console.WriteLine($"You won {HORPOINT} points!");
                        winFlag = WINROW;
                        totalPoints = totalPoints + HORPOINT;
                    }
                }

                if (winFlag == WINROW)
                {
                    Console.WriteLine($"You won {HORPOINT} points!");
                }

                for (int i = 1; i < MATRIXSIZE; i++)
                {
                    if (slots[i, i] != diagonal1 || slots[i, MATRIXSIZE - 1 - i] != diagonal2)
                    {
                        winFlag = NOWIN;
                        break;
                    }
                    else
                    {
                        //Console.WriteLine($"You won {DIAGPOINT} points!");
                        winFlag = WINDIAG;
                        totalPoints = totalPoints + DIAGPOINT;
                        break;
                    }
                }

                if (winFlag == WINDIAG)
                {
                    Console.WriteLine($"You won {DIAGPOINT} points!");
                }
                else
                {
                    Console.WriteLine("\nYou lost!");
                }

                //Display round winnings and ask user if they wish to play again
                Console.WriteLine($"Your total points are {totalPoints}");
                Console.WriteLine($"Do you want to play again? {YES}/{NO}");
                playAgain = Console.ReadLine();


                {
                    while (playAgain.ToLower() != YES && playAgain.ToLower() != NO)
                    {
                        Console.WriteLine($"Invalid input. Please enter '{YES}' or '{NO}'.");
                        playAgain = Console.ReadLine();
                    }

                }
            }
        }
    }
}
