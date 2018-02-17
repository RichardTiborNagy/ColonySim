﻿using System;

public class World : IDisplayable
{
    public World(int size)
    {
        Tiles = new Tile[size,size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Tiles[i, j] = new Tile(i, j, TileType.Ground);
            }
        }
    }

    public Tile[,] Tiles { get; }
    

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }
}