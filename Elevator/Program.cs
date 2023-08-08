namespace ElevatorChallenge
{
    class Program
    {
        //Should come from config
        private static readonly int NumberOfFloors = 8;
        private static readonly int NumberOfElevators = 2;
        private static readonly int Capacity = 3;

        static void Main(string[] args)
        {
            var controller = new ElevatorController(NumberOfFloors, NumberOfElevators, Capacity);

            controller.SetPeopleWaiting(1, 5);
            controller.SetPeopleWaiting(2, 5);
            controller.SetPeopleWaiting(3, 5);
            controller.SetPeopleWaiting(4, 2);

            while (true)
            {
                controller.DisplayStatus();
                Console.WriteLine("\nEnter destionation floor:");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int floorNum))
                {
                    if (floorNum >= 1 && floorNum <= NumberOfFloors)
                    {
                        controller.CallElevator(floorNum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid floor number");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid destination");
                }
            }
        }
    }
}