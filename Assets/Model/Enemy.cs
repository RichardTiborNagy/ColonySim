using System;
using System.Collections.Generic;

namespace ColonySim
{
    public class Enemy : IDisplayable, IPrototypable
    {
        private Queue<Tile> Path;

        public Enemy(string type, int speed, int maxHealth)
        {
            Type = type;
            Speed = speed;
            MaxHealth = maxHealth;
            Health = maxHealth;
            MovementProgress = 0f;
        }

        public Enemy(Enemy other)
        {
            if (other == null) return;
            Type = other.Type;
            Health = other.MaxHealth;
            MaxHealth = other.MaxHealth;
            Speed = other.Speed;
            MovementProgress = 0f;
        }

        public event Action Changed;

        public Tile Destination { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public float MovementProgress { get; private set; }

        public Tile NextTile { get; set; }

        public int Speed { get; set; }

        public Tile Tile { get; set; }
        public string Type { get; }

        public int X => Tile.X;
        public int Y => Tile.Y;

        public Enemy Clone(Enemy other)
        {
            return new Enemy(this);
        }

        public void OnChange()
        {
            Changed?.Invoke();
        }

        public void Update(float deltaTime)
        {
            if (Health <= 0) World.Current.DestroyEnemy(this);

            if (NextTile == null || NextTile == Tile)
            {
                if (Path == null || Path.Count == 0)
                    if (!FindPathToHeadQuarter())
                        return;

                NextTile = Path.Dequeue();
            }

            if (NextTile.MovementCost <= 0)
            {
                if (!FindPathToHeadQuarter()) return;

                NextTile = Path.Dequeue();
            }

            MovementProgress += Speed * deltaTime / NextTile.MovementCost;

            if (MovementProgress >= 1)
            {
                Tile = NextTile;
                MovementProgress = 0;
                if (Destination.IsNeighbor(Tile))
                {
                    Path = null;
                    World.Current.Health -= Health;
                    World.Current.DestroyEnemy(this);
                }
            }

            OnChange();
        }

        private bool FindPathToHeadQuarter()
        {
            Destination = World.Current.HeadQuarters.Tile;
            MovementProgress = 0;
            Path = Pathfinder.FindPath(Tile, World.Current.HeadQuarters.Tile);
            if (Path == null)
            {
                World.Current.NoPathToHeadQuarter = true;
            }
            return Path != null;
        }
    }
}