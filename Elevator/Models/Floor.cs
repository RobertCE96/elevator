namespace ElevatorChallenge.Models
{
    class Floor
    {
        public int FloorNumber { get; }
        public int PeopleWaiting { get; set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            PeopleWaiting = 0;
        }
    }
}
