
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
            List<Disk>[] rods = new[]{
              new List<Disk>
              {
                new Disk(0, 1, 8,"red"),
                new Disk(0, 2, 6,"blue"),
                new Disk(0, 3, 4,"green"),
                new Disk(0,4,2,"red")
              },
               new List<Disk>
              {
                
              },
                new List<Disk>
              {
                
              }
            };

            int maxSizeOfTheRod = 21;

            viewDisk(rods, maxSizeOfTheRod);
            Console.WriteLine("hangi cubuktan tasimak istiyorsunuz? (1,2,3)");
            var soru = Console.ReadLine().ToString();
            if(int.TryParse(soru, out int firstRod))
            {
                Console.WriteLine("hangi cubuga tasimak istiyorsunuz? (1,2,3)");
                if(int.TryParse(Console.ReadLine().ToString(), out int lastRod))
                {
                    var lastDisk = rods[firstRod-1].Last();
                    rods[firstRod-1].RemoveAt(rods[firstRod-1].Count - 1);
                    rods[lastRod-1].Add(lastDisk);
                }
            }
            Console.Clear();
            viewDisk(rods, maxSizeOfTheRod);
            
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

        static void viewDisk(List<Disk>[] rods, int maxSizeOfRod)
        {
            for (int j = 10; j >= 0; j--)
            {
                for (int i = 0; i < rods.Length; i++)
                {
                    var disks = rods[i];
                   
                    if(j >= disks.Count)
                    {
                        Console.Write(new String(' ', maxSizeOfRod/2));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.Write(new String(' ', maxSizeOfRod / 2));

                    }
                    else
                    {
                        var disk = disks[j];
                        int emptySpaces = (maxSizeOfRod - disk.size) / 2;
                        Console.Write(new String(' ', emptySpaces));
                        var color = ConsoleColor.White;
                        if (disk.color == "red")
                        {
                            color = ConsoleColor.Red;
                        }
                        if (disk.color == "blue")
                        {
                            color = ConsoleColor.Blue;
                        }
                        if (disk.color == "green")
                        {
                            color = ConsoleColor.Green;
                        }
                        Console.ForegroundColor = color;
                        Console.Write(new String('■', disk.size/2));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.ForegroundColor = color;
                        Console.Write(new String('■', disk.size / 2));

                        Console.Write(new String(' ', emptySpaces));

                    }
                    
                    
                }
                 Console.WriteLine();
            }

        }
    }
}