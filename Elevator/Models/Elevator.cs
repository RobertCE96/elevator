using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Models
{
    class Elevator
    {
        public int ElevatorNumber { get; }
        public int CurrentFloor { get; private set; }
        public bool IsMoving { get; private set; }
        public int Capacity { get; }
        public int CurrentLoad { get; private set; }
        public Direction Direction { get; private set; }

        public Elevator(int elevatorNumber, int capacity)
        {
            ElevatorNumber = elevatorNumber;
            CurrentFloor = 1; 
            IsMoving = false;
            Capacity = capacity;
            CurrentLoad = 0;
            Direction = 0;
        }

        public void MoveToFloor(int floorNumber)
        {
            IsMoving = true;
            Direction = floorNumber > CurrentFloor ? Direction.Up : Direction.Down;
            while (CurrentFloor != floorNumber)
            {
                CurrentFloor += (int)Direction;
                Console.WriteLine($"Elevator {ElevatorNumber} moving to floor {CurrentFloor}");
            }
            IsMoving = false;
            Direction = 0;
        }

        public bool CanAccommodate(int peopleCount)
        {
            return CurrentLoad + peopleCount <= Capacity;
        }

        public void LoadPassengers(int peopleCount)
        {
            if (CanAccommodate(peopleCount))
            {
                CurrentLoad += peopleCount;
            }
        }

        public void UnloadPassengers()
        {
            CurrentLoad = 0;
        }
    }

}
