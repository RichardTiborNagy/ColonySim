﻿using System;
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
            var neighbors = new List<Tile>(4) {Up, Right, Down, Left};
            return neighbors.Where(t => t != null);
        }
    }

    public bool IsNeighbor(Tile other)
    {
        return Mathf.Abs(X - other.X) + Mathf.Abs(Y - other.Y) <= 1;
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

    private const float BaseMovementCost = 10f;

    public float MovementCost => BaseMovementCost * (Building?.MovementModifier ?? 1);

    public bool Enterable => MovementCost > 0;

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }

}