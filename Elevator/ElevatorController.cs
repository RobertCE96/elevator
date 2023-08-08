using ElevatorChallenge.Models;

namespace ElevatorChallenge
{
    class ElevatorController
    {
        private List<Floor> floors;
        private List<Elevator> elevators;

        public ElevatorController(int numFloors, int numElevators, int elevatorCapacity)
        {
            floors = new List<Floor>();
            elevators = new List<Elevator>();

            for (int i = 0; i < numFloors; i++)
            {
                floors.Add(new Floor(i));
            }

            for (int i = 0; i < numElevators; i++)
            {
                elevators.Add(new Elevator(i, elevatorCapacity));
            }
        }

        public void SetPeopleWaiting(int floorNumber, int count)
        {
            Floor floor = floors.FirstOrDefault(f => f.FloorNumber == floorNumber);
            if (floor != null)
            {
                floor.PeopleWaiting = count;
            }
        }

        public void CallElevator(int floorNumber)
        {
            Floor floor = floors.FirstOrDefault(f => f.FloorNumber == floorNumber);
            if (floor == null)
            {
                Console.WriteLine($"Invalid floor number {floorNumber}.");
                return;
            }

            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;
            foreach (Elevator elevator in elevators)
            {
                if (!elevator.IsMoving)
                {
                    int distance = Math.Abs(elevator.CurrentFloor - floorNumber);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestElevator = elevator;
                    }
                }
            }

            if (nearestElevator == null)
            {
                Console.WriteLine("No elevator available");
                return;
            }

            nearestElevator.MoveToFloor(floorNumber);
            int passengersToLoad = Math.Min(floor.PeopleWaiting, nearestElevator.Capacity - nearestElevator.CurrentLoad);
            nearestElevator.LoadPassengers(passengersToLoad);
            floor.PeopleWaiting -= passengersToLoad;

            ResetElevator(nearestElevator);

        }
        public void ResetElevator(Elevator elevator)
        {
            elevator.MoveToFloor(1);
            elevator.UnloadPassengers();
        }

        public void DisplayStatus()
        {
            Console.WriteLine("\nElevator Status:");
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator: {elevator.ElevatorNumber}" +
                    $"Floor: {elevator.CurrentFloor}" +
                    $"Direction: {elevator.Direction} " +
                    $"Moving: {elevator.IsMoving} " +
                    $"Load: {elevator.CurrentLoad}/{elevator.Capacity} people");
            }

            Console.WriteLine("\nPeople Waiting on Floors:");
            foreach (var floor in floors)
            {
                Console.WriteLine($"Floor {floor.FloorNumber}" +
                    $" Waiting: {floor.PeopleWaiting}");
            }
        }
    }
}


