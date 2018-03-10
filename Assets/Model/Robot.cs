using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Robot : IDisplayable, IPrototypable
{
    public string Type { get; private set; }

    public Tile Tile { get; set; }

    public Tile Destination { get; set; }

    public float MovementProgress { get; private set; }

    //temporary
    public float Distance => Mathf.Sqrt(Mathf.Pow(Tile.X - Destination.X, 2) + Mathf.Pow(Tile.Y - Destination.Y, 2));

    public int Speed { get; private set; }

    public Job Job { get; private set; }

    public State State { get; private set; }

    private void GetJob()
    {
        var job = World.Current.AvailableJobs.FirstOrDefault(j => j.RobotType == this.Type);
        if (job == null)
            return;

        World.Current.TakeJob(job);

        Job = job;

        //hack
        Destination = job.Tile;
    }

    public void Update(float deltaTime)
    {
        if (Job == null)
        {
            //Debug.Log("Looking for a job");
            GetJob();
            return;
        }

        if (Tile == Destination)
        {
            //Debug.Log("Reached destination, completing job");
            Job.Work(deltaTime);
            if(Job.IsComplete)
            {
                Job = null;
                MovementProgress = 0;
            }
            return;
        }

        //temporary move
        if (MovementProgress > 1)
        {
            Tile = Destination;
            return;
        }

        MovementProgress += (Speed / Distance) * deltaTime;
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
