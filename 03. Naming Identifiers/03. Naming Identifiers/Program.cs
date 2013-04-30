using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Telerik.Mines
{
    public class Mines
    {
        // inner class 
        public class Score
        {
            string name;
            int points;

            public Score()
            {
            }

            public Score(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Points
            {
                get { return points; }
                set { points = value; }
            }
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int column = 0; column < boardColumns; column++)
                {
                    board[row, column] = '?';
                }
            }

            return board;
        }

        private static void DrawGameField(char[,] playField)
        {
            int rows = playField.GetLength(0);
            int columns = playField.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int column = 0; column < columns; column++)
                {
                    Console.Write(string.Format("{0} ", playField[row, column]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] PutBombs()
        {
            int rows = 5; // izkarai gi 
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    gameField[row, column] = '-';
                }
            }

            List<int> bombMap = new List<int>();
            while (bombMap.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!bombMap.Contains(randomNumber))
                {
                    bombMap.Add(randomNumber);
                }
            }

            foreach (int bombLocation in bombMap)
            {
                int column = (bombLocation / columns);
                int row = (bombLocation % columns);
                if (row == 0 && bombLocation != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static void FillSurroundingBombCounts(char[,] field, char[,] bombs, int row, int column)
        {
            char bombCount = GetSurroundingBombCounts(bombs, row, column);
            bombs[row, column] = bombCount;
            field[row, column] = bombCount;
        }

        private static char GetSurroundingBombCounts(char[,] bombs, int row, int column)
        {
            int bombCount = 0;
            int rows = bombs.GetLength(0);
            int columns = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, column] == '*')
                {
                    bombCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (bombs[row + 1, column] == '*')
                {
                    bombCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (bombs[row, column - 1] == '*')
                {
                    bombCount++;
                }
            }

            if (column + 1 < columns)
            {
                if (bombs[row, column + 1] == '*')
                {
                    bombCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (bombs[row - 1, column - 1] == '*')
                {
                    bombCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (bombs[row - 1, column + 1] == '*')
                {
                    bombCount++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (bombs[row + 1, column - 1] == '*')
                {
                    bombCount++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (bombs[row + 1, column + 1] == '*')
                {
                    bombCount++;
                }
            }

            return char.Parse(bombCount.ToString());
        }

        private static void PrintScores(List<Score> points)
        {
            Console.WriteLine("\nScores:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes",
                        i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty score list!\n");
            }
        }          

        static void Main(string[] arguments)
        {
            const int MAX_POINTS = 35;

            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] bombField = PutBombs();
            List<Score> topScores = new List<Score>(6);            

            bool isNewGame = true;           
            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Let's play Minesweeper! :) ");
                    Console.WriteLine("Try to find the cells without bombs!");
                    Console.WriteLine("\n####################################");
                    Console.WriteLine("Menu:");
                    Console.WriteLine("'top' - show the rating");
                    Console.WriteLine("'restart' - start a new game");
                    Console.WriteLine("'exit' - exit the game");
                    Console.WriteLine("'4 7' - example for entering row and col");
                    Console.WriteLine("####################################");
                    DrawGameField(gameField);
                    isNewGame = false;
                }

                
                int row = 0;
                int column = 0;
                Console.Write("Enter row and column: ");                
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column) && row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                int totalPoints = 0;
                bool bombHitted = false;
                bool isWon = false;
                switch (command)
                {
                    case "top":
                        PrintScores(topScores);
                        break;

                    case "restart":
                        gameField = CreateGameField();
                        bombField = PutBombs();
                        DrawGameField(gameField);
                        bombHitted = false;
                        isNewGame = false;
                        break;

                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;

                    case "turn":
                        if (bombField[row, column] != '*')
                        {
                            if (bombField[row, column] == '-')
                            {
                                FillSurroundingBombCounts(gameField, bombField, row, column);
                                totalPoints++;
                            }

                            if (MAX_POINTS == totalPoints)
                            {
                                isWon = true;
                            }
                            else
                            {
                                DrawGameField(gameField);
                            }
                        }
                        else
                        {
                            bombHitted = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError! Unnknown command!\n");
                        break;
                }

                if (bombHitted)
                {
                    DrawGameField(bombField);
                    Console.Write("\nHrrrrrr! You lost! Total score: {0} points. ", totalPoints);

                    Console.WriteLine("Your name: ");
                    string playersNickname = Console.ReadLine();
                    Score newScore = new Score(playersNickname, totalPoints);
                    if (topScores.Count < 5)
                    {
                        topScores.Add(newScore);
                    }
                    else
                    {
                        for (int i = 0; i < topScores.Count; i++)
                        {
                            if (topScores[i].Points < newScore.Points)
                            {
                                topScores.Insert(i, newScore);
                                topScores.RemoveAt(topScores.Count - 1);
                                break;
                            }
                        }
                    }

                    topScores.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    topScores.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    PrintScores(topScores);

                    gameField = CreateGameField();
                    bombField = PutBombs();
                    totalPoints = 0;
                    bombHitted = false;
                    isNewGame = true;
                }

                if (isWon)
                {
                    Console.WriteLine("\nHei, congratulations! You opened all blank places! ");
                    DrawGameField(bombField);

                    Console.WriteLine("Your name: ");
                    string playersName = Console.ReadLine();

                    Score currentScore = new Score(playersName, totalPoints);
                    topScores.Add(currentScore);
                    PrintScores(topScores);

                    gameField = CreateGameField();
                    bombField = PutBombs();
                    totalPoints = 0;
                    isWon = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("Bye!");
            Console.Read();
        }
    }
}
