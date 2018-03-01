using System;

public class World : IDisplayable
{
    public World(int size)
    {
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

    public Tile this[int x, int y] => Tiles[x, y];

    public static World Current { get; private set; }

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }
}
