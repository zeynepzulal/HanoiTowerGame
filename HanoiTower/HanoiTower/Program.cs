namespace HanoiTower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variablen
            int numberOfDisks = 3;
            int numberOfRods = 3;
            

            List<int[]> disks = new()
            {
                new[] {1,1},
                new[] {1,2},
                new[] {1,3}
            };

            List<int[]> rods = new()
            {
                new[]{1,0},
                new[] {2,0},
                new[] {3,0 }
            };
            
            int[] defaultRod = rods[0];
            Console.WriteLine(defaultRod[0]); // 1

            bool isGameContinue = true;


            //Loops
            while (isGameContinue)
            {
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
}