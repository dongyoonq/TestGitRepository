using System;
using System.Threading;

namespace TestGitRepository
{
    public class Bingo
    {
        public static int COLS = 5;
        public static int ROWS = 5;
        public static int[,] Board = new int[ROWS, COLS];
        public static int Pad = 5;
        public static int bingo = 0;
        public static int userInput;
        public static bool[] rowBingo = new bool[ROWS];
        public static bool[] colBingo = new bool[COLS];
        public static bool[] diagonalBingo = new bool[2];

        private static Bingo Inst;
        public static Bingo GetInstance()
        {
            Inst ??= new Bingo();
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

        public void Render()
        {
            Console.Clear();
            Console.WriteLine("======== 빙고 ========");
            Console.WriteLine("{0}개 빙고\n", bingo);

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (Board[i, j] == 0)
                        Console.Write("#".ToString().PadRight(Pad));
                    else Console.Write(Board[i, j].ToString().PadRight(Pad));
                }
                Console.Write("\n\n\n");
            }

            Console.Write("입력해라 : ");
        }

        public void Run()
        {
            while (!IsSolve())
            {
                Input();

                Update();

                Render();
            }

            Console.Clear();
            Console.WriteLine("축하합니다 !!\n빙고를 모두 맞추셨습니다.");
        }

        private void Input()
        {
            string input = Console.ReadLine();
            // 입력에 대한 예외처리
            if (!int.TryParse(input, out userInput))
            {
                Console.WriteLine("숫자만 입력해주세요.");
                Thread.Sleep(1000);
            }
        }

        private void Update()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (Board[i, j] == userInput)
                        Board[i, j] = 0;
                }
            }

            CheckBingo();
        }

        private void CheckBingo()
        {
            // 가로 체크
            bool rbingo = false;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 1; j < COLS; j++)
                {
                    if (!rowBingo[i])
                    {
                        if (Board[i, 0] == Board[i, j])
                            rbingo = true;
                        else
                        {
                            rbingo = false;
                            break;
                        }
                    }
                }

                if (rbingo)
                {
                    bingo++;
                    rowBingo[i] = true;
                }
            }

            // 세로 체크
            bool cbingo = false;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 1; j < COLS; j++)
                {
                    if (!colBingo[i])
                    {
                        if (Board[0, i] == Board[j, i])
                            cbingo = true;
                        else
                        {
                            cbingo = false;
                            break;
                        }
                    }
                    else
                        continue;
                }

                if (cbingo)
                {
                    bingo++;
                    colBingo[i] = true;
                }
            }

            // 대각선 체크
            bool dbingo = false;
            for (int i = 1; i < ROWS; i++)
            {
                if (!diagonalBingo[0])
                {
                    if (Board[0, 0] == Board[i, i])
                        dbingo = true;
                    else
                    {
                        dbingo = false;
                        break;
                    }
                }
            }

            if (dbingo)
            {
                bingo++;
                diagonalBingo[0] = true;
            }

            dbingo = false;
            for (int i = 1; i < ROWS; i++)
            {
                if (!diagonalBingo[1])
                {
                    if (Board[0, COLS - 1] == Board[i, COLS - 1 - i])
                        dbingo = true;
                    else
                    {
                        dbingo = false;
                        break;
                    }
                }
            }

            if (dbingo)
            {
                bingo++;
                diagonalBingo[1] = true;
            }
        }

        private bool IsSolve()
        {
            if (bingo == 3)
                return true;
            return false;
        }

    }
}
