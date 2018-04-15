using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IDisplayable, IPrototypable
{
    public string Type { get; private set; }

    public int Health { get; set; }

    public int MaxHealth { get; set; }

    public Tile Tile { get; set; }

    public Tile NextTile { get; set; }

    public Tile Destination { get; set; }
    
    public float MovementProgress { get; private set; }

    public int Speed { get; private set; }

    private Queue<Tile> Path;

    private bool FindPathToHeadQuarter()
    {
        Destination = World.Current.HeadQuarters.Tile;
        MovementProgress = 0;
        Path = Pathfinder.FindPath(Tile, World.Current.HeadQuarters.Tile);
        return Path != null;
    }

    public void Update(float deltaTime)
    {
        if (Health <= 0)
        {
            World.Current.DestroyEnemy(this);
        }

        if (NextTile == null || NextTile == Tile)
        {
            if (Path == null || Path.Count == 0)
            {
                if (!FindPathToHeadQuarter())
                {
                    //GiveUpJob();
                    return;
                }
            }

            NextTile = Path.Dequeue();
        }

        if (NextTile.MovementCost <= 0)
        {
            if (!FindPathToHeadQuarter())
            {
                //GiveUpJob();
                return;
            }

            NextTile = Path.Dequeue();
        }

        MovementProgress += Speed * deltaTime / NextTile.MovementCost;

        if (MovementProgress >= 1)
        {
            Tile = NextTile;
            MovementProgress = 0;
            if (Destination.IsNeighbor(Tile))
            {
                Path = null;
                World.Current.Health -= this.Health;
                World.Current.DestroyEnemy(this);
            }
        }

        OnChange();
    }

    public Enemy(string type, int speed, int maxHealth)
    {
        Type = type;
        Speed = speed;
        MaxHealth = maxHealth;
        Health = maxHealth;
        MovementProgress = 0f;
    }

    public Enemy(Enemy other)
    {
        Type = other.Type;
        Health = other.MaxHealth;
        MaxHealth = other.MaxHealth;
        Speed = other.Speed;
        MovementProgress = 0f;
    }

    public Enemy Clone(Enemy other)
    {
        return new Enemy(this);
    }

    #region IDisplayable interface implementation

    public int X => Tile.X;
    public int Y => Tile.Y;

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }

    #endregion
}
