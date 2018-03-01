using System.Collections;
using System;
using System.Reflection;

public class Tile : IDisplayable
{
    public Tile(int x, int y)
    {
        X = x;
        Y = y;
        //Type = type;
    }

    public Building Building { get; set; }

    public Resource Resource { get; set; }

    public int X { get; }
    public int Y { get; }
    //public TileType Type { get; private set; }

    public Tile[] Neighbors
    {
        get
        {
            Tile[] neighbors = new Tile[4];
            neighbors[0] = World.Current[X + 1, Y];
            neighbors[1] = World.Current[X, Y + 1];
            neighbors[2] = World.Current[X - 1, Y];
            neighbors[3] = World.Current[X, Y - 1];
            return neighbors;
        }
    }

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }

}