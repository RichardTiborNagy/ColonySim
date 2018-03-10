using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public class Tile : IDisplayable
{
    public Tile(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Building Building { get; set; }

    public Resource Resource { get; set; }

    public int X { get; }
    public int Y { get; }

    public bool Empty => Building == null && Resource == null && World.Current.Jobs.All(j => j.Tile != this);

    public bool HasBuildingWithType(string type) => Building != null && Building.Type == type;

    public bool HasResourceWithType(string type) => Resource != null && Resource.Type == type;

    public IEnumerable<Tile> Neighbors
    {
        get
        {
            Tile[] neighbors = new Tile[4];
            neighbors[0] = Up;
            neighbors[1] = Right;
            neighbors[2] = Down;
            neighbors[3] = Left;
            return neighbors.Where(t => t != null);
        }
    }

    public Tile Up => World.Current[X, Y + 1];
    public Tile Down => World.Current[X, Y - 1];
    public Tile Right => World.Current[X + 1, Y];
    public Tile Left => World.Current[X - 1, Y];

    public IEnumerable<Tile> TilesInRange(int range)
    {
        List<Tile> inRange = new List<Tile>();

        for (int i = -range; i <= range; i++)
        {
            for (int j = -range; j <= range; j++)
            {
                inRange.Add(World.Current[X+i, Y+j]);
            }
        }

        return inRange.Where(t => t != null);
    }

    public bool CanBuildHere()
    {
        return Building == null;
    }

    private const int BaseMovementCost = 10;

    public int MovementCost => BaseMovementCost + (Building?.MovementCost ?? 0);

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }

}