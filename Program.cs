namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            
            int totalPoints = 0;
            
            const int horPoint = 20;
            const int diagPoint = 30;
            const int jackpot = 100;

            while (playAgain)
            {
                Random rnd = new Random();
                
                int[,] slots = new int[3, 3];
                
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        slots[i, j] = rnd.Next(0, 10);
                    }
                }
                
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("");
                    
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write("   " + slots[i, j]);
                    }
                }

                if (slots[0, 0] == slots[0, 1] && slots[0, 1] == slots[0, 2])
                {
                    Console.WriteLine($"You won {horPoint} points!");
                    totalPoints = totalPoints + horPoint;
                }
                if (slots[1, 0] == slots[1, 1] && slots[1, 1] == slots[1, 2])
                {
                    Console.WriteLine($"You won {horPoint} points!");
                    totalPoints = totalPoints + horPoint;
                }
                if (slots[2, 0] == slots[2, 1] && slots[2, 1] == slots[2, 2])
                {
                    Console.WriteLine($"You won {horPoint} points!");
                    totalPoints = totalPoints + horPoint;
                }
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

                Console.WriteLine($"Your total points are {totalPoints}");
                Console.WriteLine("Do you want to play again? (y/n)");
                string input = Console.ReadLine();

                if (input.ToLower() != "y")
                {
                    playAgain = false;
                }
            }
        }
    }
}
