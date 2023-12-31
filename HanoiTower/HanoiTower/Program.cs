﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata.Ecma335;

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
                new Disk(6,"red"),
                new Disk(4,"green"),
                new Disk(2,"blue")
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

                while (isGameContinue)
                {
                    int fromWhichRod = 0;
                    int toWhichRod = 0;
                    ViewDisk(rods, maxSizeOfTheRod);
                    MoveTo(rods, ref validRodNum, ref fromWhichRod, ref toWhichRod);
                    HaveYouSucceeded(rods, ref isGameContinue);

                }

                DoYouWantToContinue();

            }


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
        static void MoveTo(List<Disk>[] rods, ref int[] validRodNum, ref int fromWhichRod, ref int toWhichRod)

        {

            while (true)
            {

                Console.WriteLine("From which rod do you want to move the disc ? (1, 2 or 3)");

                fromWhichRod = int.Parse(Console.ReadLine());

                if (!validRodNum.Contains(fromWhichRod))
                {
                    Console.WriteLine("This is not a valid rod number. Please enter a valid rod number!");
                    continue;
                }
                if (rods[fromWhichRod - 1].Count == 0)
                {
                    Console.WriteLine("There is not any disk to move");
                    continue;
                }
                if (FindMax(rods, rods[fromWhichRod - 1].Last().size) && rods[1].Count != 0 && rods[2].Count != 0)
                {
                    Console.WriteLine("This is the biggest disk, you cant move this rigt now to anywhere! ");
                    continue;
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("To Which rod do you want to move the disc ? (1, 2 or 3)");
                toWhichRod = int.Parse(Console.ReadLine());
                if (!validRodNum.Contains(toWhichRod))
                {
                    Console.WriteLine("This is not a valid rod number. Please enter a valid rod number!");
                    continue;
                }
                if (rods[toWhichRod - 1].LastOrDefault() != null)
                {
                    if (rods[toWhichRod - 1].Last().size < rods[fromWhichRod - 1].Last().size)
                    {
                        Console.WriteLine("You cant put a larger disk on a smaller disk! Choose a smaller disk to put on it.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;

                }


            }

            var theMovingDisk = rods[fromWhichRod - 1].LastOrDefault(); //tipi disk
            rods[fromWhichRod - 1].RemoveAt(rods[fromWhichRod - 1].Count - 1); // tipi int olmali
            rods[toWhichRod - 1].Add(theMovingDisk);
            Console.Clear();

        }
        static void HaveYouSucceeded(List<Disk>[] rods, ref bool isGameContinue)
        {
            if (rods[1].Count == 3 || rods[2].Count == 3)
            {
                Console.WriteLine("Congrats! You won");
                isGameContinue = false;
            }

        }

        static void DoYouWantToContinue()
        {
            Console.WriteLine("Do you want to continue ?");
        }


        static bool FindMax(List<Disk>[] rods, int lastDisk)
        {
            int maxSize = 0;
            List<int> sizes = new List<int> { };
            for (int i = 0; i < rods.Length; i++)
            {
                for (int j = 0; j < rods[i].Count; j++)
                {
                    sizes.Add(rods[i][j].size);
                }
            }
            for (int i = 0; i < sizes.Count; i++)
            {
                if (sizes[i] > maxSize)
                {
                    maxSize = sizes[i];
                }
            }
            //Console.WriteLine(maxSize);
            if (maxSize == lastDisk)
            {
                return true;
            }
            return false;
        }

    }
}

