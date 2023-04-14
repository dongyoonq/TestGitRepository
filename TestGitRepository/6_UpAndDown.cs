using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitRepository
{
    internal class UpAndDown
    {
        static int computerNum, userinput, cnt;
        static bool flag;
        static event Action Hint;

        public static void Run()
        {
            Init();

            while(true)
            {
                Input();
                Update();
                Render();
            }
        }

        private static void Init()
        {
            Console.Clear();
            Random rand = new Random();
            computerNum = rand.Next(0, 1000);
            cnt = 0;
        }

        private static void Input()
        {
            Console.Write("숫자를 입력해주세요 : ");
            string Input = Console.ReadLine();
            if(!int.TryParse(Input, out userinput))
                Console.WriteLine("숫자만 입력해주세요.");
        }

        private static void Update()
        {
            if(userinput == computerNum)
                flag = true;
            else if (userinput > computerNum)
                Hint = () => Console.WriteLine($"Down ! 현재 기회 소모 : {++cnt}");
            else
                Hint = () => Console.WriteLine($"Up ! 현재 기회 소모 : {++cnt}");
        }

        private static void Render()
        {
            if(flag)
            {
                Console.WriteLine("축하합니다 ! 정답을 맞추었습니다.\n게임을 종료합니다.");
                Environment.Exit(0);
            }
            else
            {
                if (cnt == 10)
                {
                    Console.WriteLine("기회를 모두 소진하셨습니다.\n");
                    Console.WriteLine("재시작 하실거면 R 버튼, 종료하실거면 ESC 버튼을 눌러주세요.");
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("종료하셨습니다. + Environment.NewLine");
                            break;
                        case ConsoleKey.R:
                            Init();
                            break;
                    }
                }
                else Hint();
            }
        }
    }
}

