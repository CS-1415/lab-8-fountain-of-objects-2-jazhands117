using FountainOfObjects.GameDesign;
namespace FountainOfObjects.Monsters
{
    public abstract class Monster
    {
        public Location Location { get; protected set; }
        public bool IsAlive { get; protected set; } = true;

        public Monster(Location position)
        {
            Location = position;
        }
        
        public virtual void Activate(Game game)
        {
            Act(game.Player, game.Map);
        }

        //method to mark a monster as dead//
        public void Kill()
        {
            IsAlive = false;
        }

        public abstract void Act(Player player, Map map);
    }
}