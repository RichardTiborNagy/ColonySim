using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.XR.WSA.Persistence;

public class World : IDisplayable
{
    private readonly int size;

    public World(int size)
    {
        this.size = size;
        Buildings = new List<Building>();
        Tiles = new Tile[size,size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Tiles[i, j] = new Tile(i, j);
            }
        }
        Current = this;
        OnChange();
    }

    public Tile[,] Tiles { get; }
    
    public Tile this[int x, int y]
    {
        get
        {
            if (x < 0 || x >= size || y < 0 || y >= size)
                return null;
            return Tiles[x, y];
        }
    }

    public List<Building> Buildings { get; private set; }

    public void Build(Building building, Tile tile)
    {
        Buildings.Add(building);
        building.Tile = tile;
        tile.Building = building;
        if (building.Type == "Wall")
        {
            foreach (var tileNeighbor in tile.Neighbors.Where(x => x.Building?.Type == "Wall"))
            {
                tileNeighbor.Building?.OnChange();
            }
        }
        OnChange();
    }

    public static World Current { get; private set; }

    public int X => 0;
    public int Y => 0;

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }
}
