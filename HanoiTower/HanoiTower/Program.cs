using System;
using System.Collections.Generic;

namespace HanoiTower
{
    internal class Program
    {
        public class Disk
        {
            public int x;
            public int y;
            public int size;
            public string color;

            //hangi çubukta oldugunu göstermek için bir degisken ekleyebilirsin.
            public Disk(int _x, int _y, int _size, string _color)
            {
                x = _x;
                y = _y;
                size = _size;
                color = _color;

            }

            public override string ToString()
            {
                return $"Disk: x={x}, y={y}, size={size}, color={color}";
            }
        }

        static void Main(string[] args)
        {
            //Variables
            int numberOfDisks = 3;
            int numberOfRods = 3;
            List<int[]> rods = new()
            {
                new[] {0, 0},
                new[] {1, 0},
                new[] {2, 0}
            };

            int[] inWhichRod = rods[0];
            //Console.WriteLine(inWhichRod[0]);

            Disk[] diskArray = new Disk[3]
            {
                new Disk(0, 1, 30,"red"),
                new Disk(0, 2, 20,"blue"),
                new Disk(0, 3, 15,"green")
            };

            /*
            foreach (Disk disk in diskArray)
            {
                Console.WriteLine(disk);
            }
            */

            // disks and rods:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(diskArray[0].x, diskArray[0].y); Console.WriteLine("<=====> ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(diskArray[1].x, diskArray[1].y); Console.WriteLine("<=========> ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(diskArray[2].x, diskArray[2].y); Console.WriteLine("<==============> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(inWhichRod[0], inWhichRod[1]);
            //Console.Write("|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|");

            bool isGameContinue = true;

            //Loops
            while (isGameContinue)
            {
                MoveTo();
            }

            HaveYouSucceeded();
        }

        static void HaveYouSucceeded()
        {
            //view
        }

        static void MoveTo()
        {
            //model function
        }
    }
}
