namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialize constants
            const int HOR_POINT = 20;
            const int DIAG_POINT = 30;
            const int JACKPOT = 100;
            const int MIN_BUYIN = 500;
            const int MATRIX_SIZE = 3;
            const int MAX_NUMBER = 10;
            const int PLAY_COST = 50;
            const string POSITVE_INPUT = "y";
            const string NEGATIVE_INPUT = "n";

            Random rnd = new Random();

            //Ask the user for a min buy in of 500 points
            Console.WriteLine($"Please enter your buy in amount, the minimum is {MIN_BUYIN} points: ");
            string playerInput = Console.ReadLine();
            int totalPoints;

            while (!Int32.TryParse(playerInput, out totalPoints) || totalPoints < MIN_BUYIN)
            {
                Console.WriteLine($"The entered amount either does not meet the minimum buy in amount or is not a valid input, please enter a valid amount of aleast {MIN_BUYIN}:");
                playerInput = Console.ReadLine();
            }

            string playAgain = POSITVE_INPUT;

            while (playAgain == POSITVE_INPUT)
            {
                Console.Clear();

                //Checking if user has enough points to play
                if (totalPoints <= 0)
                {
                    Console.WriteLine($"You do not have enough points, would you like to top up? ({POSITVE_INPUT}/{NEGATIVE_INPUT}): ");
                    string topUp = Console.ReadLine();

                    while (topUp.ToLower() != POSITVE_INPUT && topUp.ToLower() != NEGATIVE_INPUT)
                    {
                        Console.Write($"Invalid input, please enter {POSITVE_INPUT}/{NEGATIVE_INPUT}:");
                        topUp = Console.ReadLine();
                    }

                    if (topUp.ToLower() == POSITVE_INPUT)
                    {
                        Console.WriteLine("Please enter the amount of points you want to purchase");
                        totalPoints += Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }

                totalPoints -= PLAY_COST;

                //Generate the random 3x3 matrix for the slot machine

                int[,] slots = new int[MATRIX_SIZE, MATRIX_SIZE];

                for (int i = 0; i < MATRIX_SIZE; i++)
                {
                    for (int j = 0; j < MATRIX_SIZE; j++)
                    {
                        slots[i, j] = rnd.Next(MAX_NUMBER);
                    }
                }

                //Print the matrix to display to the user
                for (int i = 0; i < MATRIX_SIZE; i++)
                {
                    Console.WriteLine("");

                    for (int j = 0; j < MATRIX_SIZE; j++)
                    {
                        Console.Write("   " + slots[i, j]);
                    }
                }

                Console.WriteLine("");

                bool rowMatch = false;
                bool diagonalMatch = false;
                bool allValuesMatch = true;
                //Check rows for a match in values
                for (int i = 0; i < MATRIX_SIZE; i++)
                {
                    int rowValue = slots[i, 0];

                    bool allRowSame = true;

                    for (int j = 1; j < MATRIX_SIZE; j++)
                    {
                        if (slots[i, j] != rowValue)
                        {
                            allRowSame = false;
                            break;
                        }
                    }
                    if (allRowSame)
                    {
                        Console.WriteLine($"You won {HOR_POINT} points, all values in row {i + 1} match!");
                        totalPoints = totalPoints + HOR_POINT;
                        rowMatch = true;
                    }
                }

                bool diagonal1 = true;
                bool diagonal2 = true;
                //Check the diagonals for a match
                for (int i = 1; i < MATRIX_SIZE; i++)
                {
                    if (slots[0, 0] != slots[i, i])
                    {
                        diagonal1 = false;
                    }
                    if (slots[0, MATRIX_SIZE - 1] != slots[i, MATRIX_SIZE - 1 - i])
                    {
                        diagonal2 = false;
                    }
                }

                if (diagonal1)
                {
                    Console.WriteLine($"You won {DIAG_POINT} points, all values in first diagonal match!");
                    totalPoints += DIAG_POINT;
                    diagonalMatch = true;
                }
                if (diagonal2)
                {
                    Console.WriteLine($"You won {DIAG_POINT} points, all values in second diagonal match!");
                    totalPoints += DIAG_POINT;
                    diagonalMatch = true;
                }

                int firstValue = slots[0, 0];
                //Check if all 9 values are a match
                for (int i = 0; i < MATRIX_SIZE; i++)
                {
                    for (int j = 0; j < MATRIX_SIZE; j++)
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
                    totalPoints = totalPoints + JACKPOT;
                }
                if (!rowMatch && !diagonalMatch && !allValuesMatch)
                {
                    Console.WriteLine("You lost!");
                }

                //Display round winnings and ask user if they wish to play again
                Console.WriteLine($"Your total points are {totalPoints}");
                Console.WriteLine($"Do you want to play again? {POSITVE_INPUT}/{NEGATIVE_INPUT}");
                playAgain = Console.ReadLine();

                while (playAgain.ToLower() != POSITVE_INPUT && playAgain.ToLower() != NEGATIVE_INPUT)
                {
                    Console.WriteLine($"Invalid input. Please enter '{POSITVE_INPUT}' or '{NEGATIVE_INPUT}'.");
                    playAgain = Console.ReadLine();
                }


            }
        }
    }
}
