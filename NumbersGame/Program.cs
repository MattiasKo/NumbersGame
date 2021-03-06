//Mattias Kokkonen SUT21
using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.StartGame();
        }
        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome! can you guess what number i'm thinking off? You got 5 tries, Select difficulty" +
                "\n1: Easy, number between 1-10" +
                "\n2: Normal, number between 1-20" +
                "\n3: Hard, number between 1 - 50"+
                "\n4: Very hard, number between 1 - 100");

            byte Difficulty = byte.Parse(Console.ReadLine());
            int DiffNum = 10;
            switch (Difficulty)
            {
                case 1:
                    DiffNum = 10;
                    break;

                case 2:
                    DiffNum = 20;
                    break;

                case 3:
                    DiffNum = 50;
                    break;

                case 4:
                    DiffNum = 100;
                    break;

                default:
                    DiffNum = 10;
                    break;
            }
            Console.WriteLine("Guess the number, between 1 and " + DiffNum);
            byte GLeft = 5;
            Random random = new Random();

            int RightNum = random.Next(1, DiffNum+1);               

                GuessN(RightNum, GLeft, DiffNum);

        }
      
        public static void GuessN(int RightNum, byte GLeft, int Diffnum)
        {
            do
            {
                GLeft--;
                int GuessNum = int.Parse(Console.ReadLine());
                double CloseNum = Diffnum * 0.1;
                double FarOff = Diffnum * 0.75;
                if (RightNum == GuessNum)
                {
                    Console.WriteLine("Winner correct number!");
                    GLeft = 0;
                    Program.EndOfGame();
                }
                else
                {                   
                    Console.WriteLine("Incorrect! ");
                }
                if (GuessNum < RightNum)
                { 
                    Console.Write("To low.");
                }
                if (GuessNum > RightNum)
                {
                    Console.Write("To high.");
                }
                if (GuessNum - RightNum >= -CloseNum && GuessNum - RightNum <= CloseNum && RightNum != GuessNum) // om numret är 10% ifrån rätt svar och samtidigt felsvar säg får man ett extra meddelande "close!"
                {
                    Console.Write(" close!");
                }
              

                if (GLeft == 0 && GuessNum != RightNum)
                {
                    Console.WriteLine(" You lost!");
                    Program.EndOfGame();
                }
                if (1 < GLeft && GuessNum != RightNum)
                {
                    Console.WriteLine(" You have " + GLeft + " guesses left. Guess agian!");
                }
                if (1 == GLeft && GuessNum != RightNum)
                {
                    Console.WriteLine(" You have " + GLeft + " guess left. Guess agian!");
                }

            } while (0 < GLeft);

        }
        public static void EndOfGame()
        {
            Console.WriteLine("Try agian? (Y/N)");
            string YorN = Console.ReadLine();
            if (YorN == "Y" || YorN == "y")
            {
                Program.StartGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing, bye!");
            }


        }
    }
}
    