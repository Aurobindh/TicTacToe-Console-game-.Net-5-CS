using System;

namespace ConsoleApp20_challenge_game
{
    class Program
    {
        static string[,] tictactoe = new string[3, 3];
        static byte inpnum, player = 1,turns=0;
        static void Main(string[] args)
        {
            Resetgame();
            while (true)
            {
                Console.Clear();
                ShowTable();
                //Console.WriteLine("counter: {0}", counter);
                while (!GetInp())
                {
                    continue;
                }
                if (IsValidInp(inpnum))
                {
                    turns++;
                    UpdateTable();
                }
                else
                {
                    Console.WriteLine("Incorrect input! Please use another field!");
                    while (!GetInp())
                        continue;
                }
                if (CheckWinPlayer1())
                {
                    Console.Clear();
                    ShowTable();
                    Console.WriteLine($"Player 1 has won!\nPress any key to reset the Game");
                    Console.ReadKey();
                    Resetgame();
                }
                else if (CheckWinPlayer2())
                {
                    Console.Clear();
                    ShowTable();
                    Console.WriteLine($"Player 2 has won!\nPress any key to reset the Game");
                    Console.ReadKey();
                    Resetgame();
                }
                else if (turns == 9)
                {
                    Console.Clear();
                    ShowTable();
                    Console.WriteLine("DRAW");
                    Console.ReadKey();
                    Resetgame();
                }
                else
                {
                    continue;
                }
            }
        }
        public static bool GetInp()
        {
            Console.Write($"Player {player}: Choose your field! ");
            if (byte.TryParse(Console.ReadLine(), out inpnum))
                return true;
            else
            {
                Console.WriteLine("\nPlease enter a number!\n\n" +
               "Incorrect input! Please use another field!\n");
                return false;
            }
        }
        public static bool IsValidInp(byte num)
        {
            foreach (string i in tictactoe)
            {
                if (i.Equals(Convert.ToString(num)))
                {
                    return true;
                }   
            }
            return false;
        }
        public static void UpdateTable()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (tictactoe[i, j].Equals(Convert.ToString(inpnum)))
                    {
                        tictactoe[i, j] = player.Equals(1) ? "O" : "X";
                        player = player.Equals(1) ? (byte)2 : (byte)1;
                        break;
                    }
                }
            }
        }
        public static bool CheckWinPlayer2()
        {
            byte counter = 0;
            if (!counter.Equals(3))
            {
                //checking left up to right bottom diagonal
                for (int i = 0; i < 3; i++)
                {
                    if (tictactoe[i, i].Equals("X"))
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }

                }
            }
            
            if (!counter.Equals(3))
            {
                counter = 0;
                //checking right up to left bottom diagonal
                for (int i = 0, j = 2; i < 3; i++, j--)
                {
                    if (tictactoe[i, j].Equals("X"))
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }
                }
            }
            if (!counter.Equals(3))
            {
                //checking rows
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tictactoe[i, j].Equals("X"))
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            counter = 0;
                            break;
                        }
                    }
                    if (counter.Equals(3))
                        break;
                    else
                        continue;
                }
            }
            if (!counter.Equals(3))
            {
                //checking columns
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tictactoe[j, i].Equals("X"))
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            counter = 0;
                            break;
                        }
                    }
                    if (counter.Equals(3))
                        break;
                    else
                        continue;
                }
            }
            
            
            if (counter.Equals(3))
                return true;
            else
                return false;

        }

        public static bool CheckWinPlayer1()
        {
            byte counter = 0;
            if (!counter.Equals(3))
            {
                //checking left up to right bottom diagonal
                for (int i = 0; i < 3; i++)
                {
                    if (tictactoe[i, i].Equals("O"))
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }

                }
            }

            if (!counter.Equals(3))
            {
                counter = 0;
                //checking right up to left bottom diagonal
                for (int i = 0, j = 2; i < 3; i++, j--)
                {
                    if (tictactoe[i, j].Equals("O"))
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }
                }
            }
            if (!counter.Equals(3))
            {
                //checking rows
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tictactoe[i, j].Equals("O"))
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            counter = 0;
                            break;
                        }
                    }
                    if (counter.Equals(3))
                        break;
                    else
                        continue;
                }
            }
            if (!counter.Equals(3))
            {
                //checking columns
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tictactoe[j, i].Equals("O"))
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            counter = 0;
                            break;
                        }
                    }
                    if (counter.Equals(3))
                        break;
                    else
                        continue;
                }
            }


            if (counter.Equals(3))
                return true;
            else
                return false;

        }
        public static void Resetgame()
        {
            byte counter = 1;
            for(int i = 0; i < tictactoe.GetLength(0); i++)
            {
                for(int j = 0; j < tictactoe.GetLength(1); j++)
                {
                    tictactoe[i, j] = Convert.ToString(counter++);
                }
            }
            turns = 0;
            player = 1;
        }
        public static void ShowTable()
        {
            
            for (int i = 0; i < tictactoe.GetLength(0); i++)
            {
                Console.WriteLine("     |     |    ");
                for (int j = 0; j < tictactoe.GetLength(1); j++)
                {
                    Console.Write(j.Equals(2) ? "  " + tictactoe[i, j] + " "  : "  " + tictactoe[i, j] + " " + " |");
                }
                Console.WriteLine();
                Console.WriteLine(i.Equals(2)? "     |     |      ":"_____|_____|_____");
            }
            Console.WriteLine();
        }
        
    }
}