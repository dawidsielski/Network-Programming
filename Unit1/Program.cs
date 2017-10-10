using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.ReadKey();

            Random r = new Random();

            double n = 1, a_n = 0, sum = 0;
            while (!Console.KeyAvailable)
            {
                a_n = (Math.Pow(-1, n - 1)) / (2 * n - 1);
                sum += a_n;
                Console.BackgroundColor = (ConsoleColor)r.Next(0, 16);
                Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
                Console.WriteLine(Convert.ToString(a_n));
                System.Threading.Thread.Sleep(100);
                n++;

                //gotoxy(1, 40, Convert.ToString(sum));

                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                Console.CursorTop = Console.WindowTop + 5;
                Console.CursorLeft = Console.WindowLeft + 30;
                Console.ResetColor();
                Console.Write(Convert.ToString(sum));

                Console.CursorTop = Console.WindowTop + 4;
                Console.CursorLeft = Console.WindowLeft + 30;

                Console.Write(new string(' ', 40));

                Console.SetCursorPosition(x, y);

                #region
                //Console.ResetColor();
                //int currentLineCursor = Console.CursorTop;
                //Console.SetCursorPosition(0, Console.CursorTop);
                //Console.Write(new string(' ', Console.WindowWidth));
                //Console.SetCursorPosition(0, currentLineCursor);

                //int x = Console.CursorLeft;
                //int y = Console.CursorTop;
                //Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1;
                //Console.CursorLeft = Console.WindowLeft + Console.WindowWidth - 50;
                //Console.Write(Convert.ToString(sum));
                //Console.SetCursorPosition(x, y);
                #endregion
            }
        }

        static void gotoxy(int x, int y, string text)
        {
            int x_original = Console.CursorLeft;
            int y_original = Console.CursorTop;

            Console.ResetColor();
            int currentLineCursor = Console.CursorTop;  
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);

            Console.CursorTop = Console.WindowTop + Console.WindowHeight - x;
            Console.CursorLeft = Console.WindowLeft + Console.WindowWidth - y;
            Console.Write(text);
            Console.SetCursorPosition(x_original, y_original);
        }
    }
}
