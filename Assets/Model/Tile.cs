namespace ColonySim
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class Tile : IDisplayable
    {
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

    public Building Building { get; set; }
    
    public int X { get; }
    public int Y { get; }

    public bool Empty => Building == null && (World.Current?.JobManager?.Jobs?.All(j => j.Tile != this) ?? false);
        public bool HasBuilding => Building != null;

        public bool HasBuildingWithType(string type) => Building != null && Building.Type == type;
        
        public List<Tile> Neighbors
        {
            get
            {
                var neighbors = new List<Tile>(4) {Up, Right, Down, Left};
                return neighbors.Where(t => t != null).ToList();
            }
        }

    public bool HasBuildingWithType(string type) => Building != null && Building.Type == type;

    
    public List<Tile> Neighbors
    {
        get
        {
            return Mathf.Abs(X - other.X) + Mathf.Abs(Y - other.Y) <= 1;
        }

    public bool IsNeighbor(Tile other)
    {
        if (other == null) return false;
        try
        {
            return Mathf.Abs(X - other.X) + Mathf.Abs(Y - other.Y) <= 1;
        }
        catch
        {
            return false;
        }
    }

    public Tile Up => World.Current?[X, Y + 1];
    public Tile Down => World.Current?[X, Y - 1];
    public Tile Right => World.Current?[X + 1, Y];
    public Tile Left => World.Current?[X - 1, Y];

    public IEnumerable<Tile> TilesInRange(int range)
    {
        if (range == 0) return new List<Tile>()
        {
            this
        };
        List<Tile> inRange = new List<Tile>();

        for (int i = -range; i <= range; i++)
        {
            List<Tile> inRange = new List<Tile>();

            for (int i = -range; i <= range; i++)
            {
                for (int j = -range; j <= range; j++)
                {
                    inRange.Add(World.Current[X + i, Y + j]);
                }
            }

            return inRange.Where(t => t != null);
        }

        public bool CanBuildHere()
        {
            return Building == null;
        }

        private const float BaseMovementCost = 10f;

        public float MovementCost => BaseMovementCost * (Building?.MovementModifier ?? 1);

        public bool Enterable => MovementCost > 0;

        public event Action Changed;

        public void OnChange()
        {
            Changed?.Invoke();
        }
    }
}