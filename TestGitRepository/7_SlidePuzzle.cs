using System;

namespace TestGitRepository
{
    public class SlidePuzzle
    {
        public static int COLS = 5;
        public static int ROWS = 5;
        public static int[,] Board = new int[ROWS, COLS];
        public static int Empty = 0;
        public static int Pad = 5;

        private static SlidePuzzle Inst;
        public static SlidePuzzle GetInstance()
        {
            Inst ??= new SlidePuzzle();
            return Inst;
        }

        public void Init()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Board[i, j] = ROWS * i + j + 1;
                }
            }

            Board[ROWS - 1, COLS - 1] = Empty;

            // 랜덤 섞기
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Random rand = new Random();
                    int randCOLS = rand.Next(COLS);
                    int randROWS = rand.Next(ROWS);

                    int temp = Board[i, j];
                    Board[i, j] = Board[randROWS, randCOLS];
                    Board[randROWS, randCOLS] = temp;
                }
            }
        }

        public void PrintBoard()
        {
            Console.Clear();

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (Board[i, j] != 0)
                        Console.Write(Board[i, j].ToString().PadRight(Pad));
                    else
                        Console.Write("".ToString().PadRight(Pad));
                }
                Console.Write("\n\n\n");
            }

            Console.WriteLine("\n← : 왼쪽 → : 오른쪽 ↑ : 위쪽 ↓ : 아래쪽");
        }

        public void Run()
        {
            while (!IsSolve())
            {
                ConsoleKeyInfo Input = Console.ReadKey();
                switch (Input.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (CanMoveUp())
                            MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        if (CanMoveDown())
                            MoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (CanMoveLeft())
                            MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        if (CanMoveRight())
                            MoveRight();
                        break;
                    case ConsoleKey.F1:
                        for (int i = 0; i < ROWS; i++)
                            for (int j = 0; j < COLS; j++)
                                Board[i, j] = ROWS * i + j + 1;
                        Board[ROWS - 1, COLS - 2] = Empty;
                        Board[ROWS - 1, COLS - 1] = 24;
                        PrintBoard();
                        break;
                }

                PrintBoard();
            }

            Console.Clear();
            Console.WriteLine("축하합니다 !!\n슬라이드 퍼즐을 모두 맞추셨습니다.");
        }

        private bool CanMoveUp()
        {
            int emptyRow = 0;
            int emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            return emptyRow < ROWS - 1;
        }

        private bool CanMoveDown()
        {
            int emptyRow = 0;
            int emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            return emptyRow > 0;
        }

        private bool CanMoveLeft()
        {
            int emptyRow = 0;
            int emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            return emptyCol < COLS - 1;
        }

        private bool CanMoveRight()
        {
            int emptyRow = 0;
            int emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            return emptyCol > 0;
        }

        private void MoveUp()
        {
            int emptyRow = 0, emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            int tmp = Board[emptyRow, emptyCol];
            Board[emptyRow, emptyCol] = Board[emptyRow + 1, emptyCol];
            Board[emptyRow + 1, emptyCol] = tmp;
        }

        private void MoveDown()
        {
            int emptyRow = 0, emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            int tmp = Board[emptyRow, emptyCol];
            Board[emptyRow, emptyCol] = Board[emptyRow - 1, emptyCol];
            Board[emptyRow - 1, emptyCol] = tmp;
        }

        private void MoveLeft()
        {
            int emptyRow = 0, emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            int tmp = Board[emptyRow, emptyCol];
            Board[emptyRow, emptyCol] = Board[emptyRow, emptyCol + 1];
            Board[emptyRow, emptyCol + 1] = tmp;
        }

        private void MoveRight()
        {
            int emptyRow = 0, emptyCol = 0;
            FindEmptySpace(out emptyRow, out emptyCol);

            int tmp = Board[emptyRow, emptyCol];
            Board[emptyRow, emptyCol] = Board[emptyRow, emptyCol - 1];
            Board[emptyRow, emptyCol - 1] = tmp;
        }

        private bool IsSolve()
        {
            int number = 1;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (i == ROWS - 1 && j == COLS - 1)
                        continue;

                    if (Board[i, j] != number)
                    {
                        return false;
                    }
                    number++;

                }
            }

            return true;
        }

        private void FindEmptySpace(out int Row, out int Col)
        {
            Row = 0; Col = 0;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (Board[i, j] == 0)
                    {
                        Row = i;
                        Col = j;
                        break;
                    }

                }
            }
        }
    }
}
