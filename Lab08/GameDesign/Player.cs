namespace FountainOfObjects.GameDesign
{
    public class Player
    {
        public Location Location { get; set; }
        public bool IsAlive { get; private set; } = true;
        public string CauseOfDeath { get; private set; } = "";
        public int ArrowsRemaining { get; private set; }

        public Player(Location start, int initialArrows = 5)
        {
            Location = start;
            ArrowsRemaining = initialArrows;
        }

        public void Move(Direction direction)
        {
            Location = Location.Move(direction);
        }

        public void Kill(string cause)
        {
            IsAlive = false;
            CauseOfDeath = cause;
        }

        //attempts to use one arrow, returns true if an arrow was used, false if none available//
        public bool UseArrow()
        {
            if (ArrowsRemaining <= 0)
                return false;
            ArrowsRemaining--;
            return true;
        }
    }
}