using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.XR.WSA.Persistence;

public class World : IDisplayable
{
    private readonly int size;

    public World(int size)
    {
        this.size = size;
        Tiles = new Tile[size,size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Tiles[i, j] = new Tile(i, j);
            }
        }
        Current = this;
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

    public static World Current { get; private set; }

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }
}
