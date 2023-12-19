
using System;
using System.Collections.Generic;

namespace HanoiTower
{
    internal class Program
    {
        public class Disk
        {

            public int size;
            public string color;
            public Disk(int _size, string _color)
            {
                size = _size;
                color = _color;

            }

            public override string ToString()
            {
                return $"Disk: size={size}, color={color}";
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
                new Disk(8,"red"),
                new Disk(6,"blue"),
                new Disk(4,"green"),
                new Disk(2,"yellow")
              },
               new List<Disk>{},
               new List<Disk>{}
            };

            int maxSizeOfTheRod = 21;
            bool isGameContinue = true;
            int[] validRodNum = new int[3] { 1, 2, 3 };





            //Loops
            while (isGameContinue)
            {
                int fromWhichRod;
                int toWhichrod;
                while (isGameContinue)
                {
                    ViewDisk(rods, maxSizeOfTheRod);
                    MoveTo(rods, validRodNum);
                   
                }
            }

            HaveYouSucceeded();
        }

        static void HaveYouSucceeded()
        {
            //view
        }

        static void ViewDisk(List<Disk>[] rods, int maxSizeOfRod)
        {
            for (int j = 10; j >= 0; j--)
            {
                for (int i = 0; i < rods.Length; i++)
                {
                    var disks = rods[i];

                    if (j >= disks.Count)
                    {
                        Console.Write(new String(' ', maxSizeOfRod / 2));
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
                        if (disk.color == "yellow")
                        {
                            color = ConsoleColor.Yellow;
                        }
                        Console.ForegroundColor = color;
                        Console.Write(new String('■', disk.size / 2));
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
        static void MoveTo(List<Disk>[] rods, int[] validRodNum)
        {
            Console.WriteLine("hangi cubuktan tasimak istiyorsunuz? (1,2,3)");
            var fromWhich = Console.ReadLine().ToString();
            if (int.TryParse(fromWhich, out int firstRod))
            {
                Console.WriteLine("hangi cubuga tasimak istiyorsunuz? (1,2,3)");
                if (int.TryParse(Console.ReadLine().ToString(), out int lastRod)) // girilien sayi 1,2 veya 3 den baska bir sey olmamali buna dikkat et.
                {
                    var lastDisk = rods[firstRod - 1].Last();
                    rods[firstRod - 1].RemoveAt(rods[firstRod - 1].Count - 1);
                    rods[lastRod - 1].Add(lastDisk);
                }
            }
            Console.Clear();
        }
        
    }

}