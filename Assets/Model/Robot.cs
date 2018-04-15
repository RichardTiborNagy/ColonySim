using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Robot : IDisplayable, IPrototypable
{
    public string Type { get; private set; }

    public Tile Tile { get; set; }

    public Tile NextTile { get; set; }

    public Tile Destination { get; set; }

    public float Charge { get; set; } = 20f;

    public float MovementProgress { get; private set; }

    public int Speed { get; private set; }

    public Job Job { get; private set; }

    //public State State { get; private set; }

    private Queue<Tile> Path;

    private void GetJob()
    {
        Job = World.Current.JobManager.TakeJob(this);
    }

    public void GiveUpJob()
    {
        if (Job.Type == "Charge") return;
        World.Current.JobManager.GiveUpJob(this);
        Job = null;
        Destination = NextTile;
        Path = null;
    }

    private bool HasJob => Job != null;

    private bool FindPathToTile(Tile destination)
    {
        MovementProgress = 0;
        Path = Pathfinder.FindPath(Tile, destination);
        return Path != null;
    }

    private void UpdateCharge(float deltaTime)
    {
        Charge -= deltaTime;
        if (Charge < 10f)
        {
            if (Job != null && Job.Type != "Charge")
            {
                GiveUpJob();
            }
            else if (Job != null)
            {
                return;
            }
            else
            {
                Job = new Job(Prototypes.Jobs.Get("Charge")) { Tile = World.Current.HeadQuarters.Tile, Robot = this };
                Destination = Job.Tile;
            }
        }
    }

    private void UpdateMovement(float deltaTime)
    {
        if (NextTile == null || NextTile == Tile)
        {
            if (Path == null || Path.Count == 0)
            {
                if (!FindPathToTile(Destination))
                {
                    GiveUpJob();
                    return;
                }
            }

            NextTile = Path.Dequeue();
        }

        if (NextTile.MovementCost <= 0)
        {
            if (!FindPathToTile(Destination))
            {
                GiveUpJob();
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
            }
        }
    }

    private void UpdateWork(float deltaTime)
    {
        if (Job == null)
        {
            GetJob();

            if (Job != null)
            {
                Destination = Job.Tile;
            }
        }

        if (Job != null && Tile.IsNeighbor(Job.Tile))
        {
            Job.Work(deltaTime);
            if (Job.IsComplete)
            {
                Job = null;
            }
        }
    }

    public void Update(float deltaTime)
    {
        UpdateCharge(deltaTime);
        UpdateMovement(deltaTime);
        UpdateWork(deltaTime);
        OnChange();
    }

    public Robot(string type, int speed)
    {
        Type = type;
        Speed = speed;
        MovementProgress = 0f;
    }

    public Robot(Robot other)
    {
        Type = other.Type;
        Speed = other.Speed;
    }

    public Robot Clone(Robot other)
    {
        return new Robot(this);
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
