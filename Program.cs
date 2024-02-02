namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            int totalpoints = 0;
            
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
                
                Console.WriteLine("   " + slots[0, 0] + " " + slots[0, 1] + " " + slots[0, 2]);
                Console.WriteLine("   " + slots[1, 0] + " " + slots[1, 1] + " " + slots[1, 2]);
                Console.WriteLine("   " + slots[2, 0] + " " + slots[2, 1] + " " + slots[2, 2]);
                
                if (slots[0, 0] == slots[0, 1] && slots[0, 1] == slots[0, 2])
                {
                    Console.WriteLine("You won 20 points!");
                    totalpoints = totalpoints + 20;
                }
                if (slots[1, 0] == slots[1, 1] && slots[1, 1] == slots[1, 2])
                {
                    Console.WriteLine("You won 20 points!");
                    totalpoints = totalpoints + 20;
                }
                if (slots[2, 0] == slots[2, 1] && slots[2, 1] == slots[2, 2])
                {
                    Console.WriteLine("You won 20 points!");
                    totalpoints = totalpoints + 20;
                }
                if (slots[0, 0] == slots[1, 1] && slots[1, 1] == slots[2, 2])
                {
                    Console.WriteLine("You won 30 points!");
                    totalpoints = totalpoints + 30;
                }
                if (slots[2, 0] == slots[1, 1] && slots[1, 1] == slots[0, 2])
                {
                    Console.WriteLine("You won 30 points!");
                    totalpoints = totalpoints + 30;
                }
                if (slots[0, 0] == slots[0, 1] && slots[0, 1] == slots[0, 2] && slots[0, 2] == slots[1, 0] && slots[1, 0] == slots[1, 1] && slots[1, 1] == slots[1, 2] && slots[1, 2] == slots[2, 0] && slots[2, 0] == slots[2, 1] && slots[2, 1] == slots[2, 2])
                {
                    Console.WriteLine("You won the jackpot!");
                    totalpoints = totalpoints + 100;
                }
                else
                {
                    Console.WriteLine("You lost!");
                }

                Console.WriteLine($"Your total points are {totalpoints}");
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
