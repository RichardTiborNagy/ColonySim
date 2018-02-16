using System.Collections;
using System;

public class Tile : IDisplayable
{
    public Tile(int x, int y, TileType type)
    {
        X = x;
        Y = y;
        Type = type;
    }

    public int X { get; }
    public int Y { get; }
    public TileType Type { get; private set; }

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }

}
