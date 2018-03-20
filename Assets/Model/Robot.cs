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

    public float MovementProgress { get; private set; }
    
    public int Speed { get; private set; }

    public Job Job { get; private set; }
    
    //public State State { get; private set; }

    private Queue<Tile> Path;

    private void GetJob()
    {
        var job = World.Current.AvailableJobs.FirstOrDefault(j => j.RobotType == this.Type && Pathfinder.FindPath(Tile, j.Tile) != null);
        if (job == null)
            return;

        World.Current.TakeJob(job);

        Job = job;
        
    }

    private void GiveUpJob()
    {
        World.Current.GiveUpJob(Job);
        Job = null;
        NextTile = Destination = Tile;
        Path = null;
    }

    private bool HasJob => Job != null;

    private bool FindPathToTile(Tile destination)
    {
        Path = Pathfinder.FindPath(Tile, destination);
        return Path != null;
    }

    private void UpdateMovement(float deltaTime)
    {
        if (Destination.IsNeighbor(Tile))
        {
            Path = null;
            return;
        }

        if (NextTile == null || NextTile == Tile)
        {
            if (Path == null || Path.Count == 0)
            {
                FindPathToTile(Destination);
                if (Path == null /*|| Path.Count == 0*/)
                {
                    GiveUpJob();
                    Path = null;
                    return;
                }
            }
            
            NextTile = Path.Dequeue();
        }

        if (NextTile.MovementCost == 0)
        {
            FindPathToTile(Destination);
            if (Path == null /*|| Path.Count == 0*/)
            {
                GiveUpJob();
                Path = null;
                return;
            }
            NextTile = Path.Dequeue();
        }
        
        MovementProgress += Speed * deltaTime / NextTile.MovementCost;
        
        if (MovementProgress >= 1)
        {
            Tile = NextTile;
            MovementProgress = 0;
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
