using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ColonySim
{
    public class Tile : IDisplayable
    {
        private const float BaseMovementCost = 10f;

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public event Action Changed;

        public Building Building { get; set; }
        public Tile Down => World.Current?[X, Y - 1];

        public bool Empty => Building == null && (World.Current?.JobManager?.Jobs?.All(j => j.Tile != this) ?? false);

        public bool Enterable => MovementCost > 0;

        public bool HasBuilding => Building != null;
        public Tile Left => World.Current?[X - 1, Y];

        public float MovementCost => BaseMovementCost * (Building?.MovementModifier ?? 1);


        public List<Tile> Neighbors
        {
            get
            {
                var neighbors = new List<Tile>(4) {Up, Right, Down, Left};
                return neighbors.Where(t => t != null).ToList();
            }
        }

        public Tile Right => World.Current?[X + 1, Y];

        public Tile Up => World.Current?[X, Y + 1];

        public int X { get; }
        public int Y { get; }

        public bool CanBuildHere()
        {
            return Building == null;
        }

        public bool HasBuildingWithType(string type)
        {
            return Building != null && Building.Type == type;
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

        public void OnChange()
        {
            Changed?.Invoke();
        }

        public IEnumerable<Tile> TilesInRange(int range)
        {
            if (range == 0)
                return new List<Tile>
                {
                    this
                };
            var inRange = new List<Tile>();

            for (var i = -range; i <= range; i++)
            for (var j = -range; j <= range; j++)
                inRange.Add(World.Current[X + i, Y + j]);

            return inRange.Where(t => t != null);
        }
    }
}