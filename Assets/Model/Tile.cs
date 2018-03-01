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

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }

}