using System.Reflection.Metadata.Ecma335;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize points for each category
            const int horPoint = 20;
            const int diagPoint = 30;
            const int jackpot = 100;
            const int minBuyin = 500;
            const int matrixSize = 3;
            const int maxNumber = 10;
            const int playCost = 50;

            //Ask the user for a min buy in of 500 points
            Console.WriteLine($"Please enter your buy in amount, the minimum is {minBuyin} points: ");
            string playerInput = Console.ReadLine();
            int totalPoints;

            while (!Int32.TryParse(playerInput, out totalPoints) || totalPoints < minBuyin)
            {
                Console.WriteLine($"The entered amount either does not meet the minimum buy in amount or is not a valid input, please enter a valid amount of aleast {minBuyin}:");
                //totalPoints = Convert.ToInt32(Console.ReadLine());
                playerInput = Console.ReadLine();
            }

            string playAgain = "y";

            while (playAgain == "y")
            {
                //Console.Clear();


                //Checking if user has enough points to play
                if (totalPoints <= 0)
                {
                    Console.WriteLine("You do not have enough points, would you like to top up? (y/n): ");
                    string topUp = Console.ReadLine();

                    while (topUp.ToLower() != "y" && topUp.ToLower() != "n")
                    {
                        Console.Write("Invalid input, please enter y/n:");
                        topUp = Console.ReadLine();
                    }

                    if (topUp.ToLower() == "y")
                    {
                        Console.WriteLine("Please enter the amount of points you want to purchase");
                        totalPoints += Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }

                totalPoints -= playCost;
                
                //Generate the random 3x3 matrix for the slot machine
                Random rnd = new Random();

                int[,] slots = new int[matrixSize, matrixSize];

                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        slots[i, j] = rnd.Next(maxNumber);
                    }
                }

                for (int i = 0; i < matrixSize; i++)
                {
                    Console.WriteLine("");

                    for (int j = 0; j < matrixSize; j++)
                    {
                        Console.Write("   " + slots[i, j]);
                    }
                }

                for (int i = 0; i < matrixSize; i ++)
                {
                    if (slots[i, 0] == slots[i, 1] && slots[i, 1] == slots[i, 2])
                    {
                        Console.WriteLine($"You won {horPoint} points!");
                        totalPoints = totalPoints + horPoint;
                    }
                }

                //for (int i = 0; i < matrixSize; i++)
                //{
                //    if (slots[i, i] == slots[0, 0] || slots[i, matrixSize - 1 - i] == slots[0, matrixSize - 1])
                //    {
                //        Console.WriteLine($"You won {diagPoint} points!");
                //        totalPoints = totalPoints + diagPoint;  
                //    }
                //}

                if (slots[0, 0] == slots[1, 1] && slots[1, 1] == slots[2, 2])
                {
                    Console.WriteLine($"You won {diagPoint} points!");
                    totalPoints = totalPoints + diagPoint;
                }
                if (slots[2, 0] == slots[1, 1] && slots[1, 1] == slots[0, 2])
                {
                    Console.WriteLine($"You won {diagPoint} points!");
                    totalPoints = totalPoints + diagPoint;
                }
                if (slots[0, 0] == slots[0, 1] && slots[0, 1] == slots[0, 2] && slots[0, 2] == slots[1, 0] && slots[1, 0] == slots[1, 1] && slots[1, 1] == slots[1, 2] && slots[1, 2] == slots[2, 0] && slots[2, 0] == slots[2, 1] && slots[2, 1] == slots[2, 2])
                {
                    Console.WriteLine($"You won the jackpot of a {jackpot} points!");
                    totalPoints = totalPoints + jackpot;
                }
                else
                {
                    Console.WriteLine("\nYou lost!");
                }

                //Display round winnings and ask user if they wish to play again
                Console.WriteLine($"Your total points are {totalPoints}");
                Console.WriteLine("Do you want to play again? (y/n)");
                playAgain = Console.ReadLine();


                {
                    while (playAgain.ToLower() != "y" && playAgain.ToLower() != "n")
                    {
                        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                        playAgain = Console.ReadLine();
                    }

                }
            }
        }
    }
}
