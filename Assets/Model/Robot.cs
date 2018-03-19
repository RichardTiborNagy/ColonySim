using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Robot : IDisplayable, IPrototypable
{
    public string Type { get; private set; }

    public Tile Tile { get; set; }

    public Tile NexTile { get; set; }

    //public Tile Destination { get; set; }

    public float MovementProgress { get; private set; }

    //temporary
    //public float Distance => Mathf.Sqrt(Mathf.Pow(Tile.X - Destination.X, 2) + Mathf.Pow(Tile.Y - Destination.Y, 2));

    public int Speed { get; private set; }

    public Job Job { get; private set; }

    //public State State { get; private set; }

    private Queue<Tile> Path;

    private void GetJob()
    {
        var job = World.Current.AvailableJobs.FirstOrDefault(j => j.RobotType == this.Type);
        if (job == null)
            return;

        World.Current.TakeJob(job);

        Job = job;

        //hack
        //Destination = job.Tile;
    }

    private void GiveUpJob()
    {
        World.Current.GiveUpJob(Job);
        Job = null;
    }

    private bool HasJob => Job != null;

    private bool FindPathToTile(Tile destination)
    {
        Path = Pathfinder.FindPath(Tile, destination);
        return Path != null;
    }

    private void UpdateMovement(float deltaTime)
    {
        if (Path == null)
        {
            return;
        }

        if (MovementProgress > 1)
        {
            if (Path.Count <= 0)
            {
                Path = null;
                Tile = NexTile;
                MovementProgress = 0;
                return;
            }
            Tile = NexTile;
            NexTile = Path.Dequeue();
            MovementProgress = 0;
        }

        MovementProgress += (Speed / NexTile.MovementCost) * deltaTime;
    }

    private void UpdateWork(float deltaTime)
    {
        if (Job == null)
        {
            GetJob();
            if (Job == null) return;
            if (!FindPathToTile(Job.Tile))
            {
                GiveUpJob();
            }
        }
        else if (Path == null) //reached destination
        {
            Job.Work(deltaTime);
            if (Job.IsComplete)
            {
                Job = null;
                MovementProgress = 0;
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
