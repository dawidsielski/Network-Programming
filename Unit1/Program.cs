using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    class Program
    {
        static void Main()
        {
            /****************************************************************************
            * Name: static void Main()
            * Description: Main program execution
            * Author: Dawid Sielski 10.10.2017
            ****************************************************************************/

            Console.WriteLine("Hello World!");
            Console.ReadKey();

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

                gotoxy(4, 30, Convert.ToString(sum));
            }
        }

        static void gotoxy(int x, int y, string text)
        {
            /****************************************************************************
            * Name: static void gotoxy(int x, int y, string text)
            * Description: inserts text in a given position in console
            * Arguments: 
            * x (int): x position of a cursor
            * y (int): y position of a cursor
            * text (string): text to display in a given place
            * Author: Dawid Sielski 10.10.2017
            ****************************************************************************/

            int x_oryginal = Console.CursorLeft;
            int y_oryginal = Console.CursorTop;

            Console.CursorTop = Console.WindowTop + x;
            Console.CursorLeft = Console.WindowLeft + y;
            Console.ResetColor();
            Console.Write(text);

            Console.CursorTop = Console.WindowTop + x - 1;
            Console.CursorLeft = Console.WindowLeft + y;

            Console.Write(new string(' ', 40));

            Console.SetCursorPosition(x_oryginal, y_oryginal);
        }
    }
}
