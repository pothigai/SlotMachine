namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialize constants
            const int HORPOINT = 20;
            const int DIAGPOINT = 30;
            const int JACKPOT = 100;
            const int MINBUYIN = 500;
            const int MATRIXSIZE = 3;
            const int MAXNUMBER = 10;
            const int PLAYCOST = 50;
            const string YES = "y";
            const string NO = "n";

            //Ask the user for a min buy in of 500 points
            Console.WriteLine($"Please enter your buy in amount, the minimum is {MINBUYIN} points: ");
            string playerInput = Console.ReadLine();
            int totalPoints;

            while (!Int32.TryParse(playerInput, out totalPoints) || totalPoints < MINBUYIN)
            {
                Console.WriteLine($"The entered amount either does not meet the minimum buy in amount or is not a valid input, please enter a valid amount of aleast {MINBUYIN}:");
                playerInput = Console.ReadLine();
            }

            string playAgain = YES;

            while (playAgain == YES)
            {
                Console.Clear();

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

                //Print the matrix to display to the user
                for (int i = 0; i < MATRIXSIZE; i++)
                {
                    Console.WriteLine("");

                    for (int j = 0; j < MATRIXSIZE; j++)
                    {
                        Console.Write("   " + slots[i, j]);
                    }
                }

                Console.WriteLine("");

                bool rowMatch = false;
                bool diagonalMatch = false;
                bool allValuesMatch = true;
                //Check rows for a match in values
                for (int i = 0; i < MATRIXSIZE; i++)
                {
                    if (slots[i, 0] == slots[i, 1] && slots[i, 1] == slots[i, 2])
                    {
                        Console.WriteLine($"You won {HORPOINT} points, all values in row {i + 1} match!");
                        totalPoints = totalPoints + HORPOINT;
                        rowMatch = true;
                    }
                }

                bool diagonal1 = true;
                bool diagonal2 = true;
                //Check the diagonals for a match
                for (int i = 1; i < MATRIXSIZE; i++)
                {
                    if (slots[0, 0] != slots[i, i])
                    {
                        diagonal1 = false;
                    }
                    if (slots[0, 2] != slots[i, 2 - i])
                    {
                        diagonal2 = false;
                    }
                }

                if (diagonal1)
                {
                    Console.WriteLine($"You won {DIAGPOINT} points, all values in first diagonal match!");
                    totalPoints += DIAGPOINT;
                    diagonalMatch = true;
                }
                if (diagonal2)
                {
                    Console.WriteLine($"You won {DIAGPOINT} points, all values in second diagonal match!");
                    totalPoints += DIAGPOINT;
                    diagonalMatch = true;
                }

                int firstValue = slots[0, 0];
                //Check if all 9 values are a match
                for (int i = 0; i < MATRIXSIZE; i++)
                {
                    for (int j = 0; j < MATRIXSIZE; j++)
                    {
                        if (slots[i, j] != firstValue)
                        {
                            allValuesMatch = false;
                            break;
                        }
                    }
                    if (!allValuesMatch)
                    {
                        break;
                    }
                }

                if (allValuesMatch)
                {
                    Console.WriteLine($"You won {JACKPOT} points, all values in the slot match!");
                }
                if (!rowMatch && !diagonalMatch && !allValuesMatch)
                {
                    Console.WriteLine("You lost!");
                }

                //Display round winnings and ask user if they wish to play again
                Console.WriteLine($"Your total points are {totalPoints}");
                Console.WriteLine($"Do you want to play again? {YES}/{NO}");
                playAgain = Console.ReadLine();

                while (playAgain.ToLower() != YES && playAgain.ToLower() != NO)
                {
                    Console.WriteLine($"Invalid input. Please enter '{YES}' or '{NO}'.");
                    playAgain = Console.ReadLine();
                }


            }
        }
    }
}
