using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

public class World : IDisplayable
{
    private readonly int _size;

    public World(int size)
    {
        this._size = size;
        Buildings = new List<Building>();
        Tiles = new Tile[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Tiles[i, j] = new Tile(i, j);
            }
        }

        AvailableJobs = new List<Job>();
        TakenJobs = new List<Job>();
        Robots = new List<Robot>();
        Current = this;
        OnChange();
    }

    public Tile[,] Tiles { get; }

    public Tile this[int x, int y]
    {
        get
        {
            if (x < 0 || x >= _size || y < 0 || y >= _size)
                return null;
            return Tiles[x, y];
        }
    }

    public List<Building> Buildings { get; private set; }

    public List<Robot> Robots { get; private set; }

    public List<Job> AvailableJobs { get; private set; }

    public List<Job> TakenJobs { get; private set; }

    public void TakeJob(Job job)
    {
        AvailableJobs.Remove(job);
        TakenJobs.Add(job);
    }

    public IEnumerable<Job> Jobs => AvailableJobs.Concat(TakenJobs);

    public void Update(float deltaTime)
    {
        Robots.ForEach(robot => robot.Update(deltaTime));

        Buildings.ForEach(building => building.Update(deltaTime));

        if (TakenJobs.RemoveAll(job => job.IsComplete) > 0)
            OnChange();
    }


    public void CreateRobot(Robot protoRobot, Tile tile)
    {
        var robotToCreate = new Robot(protoRobot);
        Robots.Add(robotToCreate);
        robotToCreate.Tile = tile;
        robotToCreate.Destination = tile;
        OnChange();
    }

    public void CreateJob(Job protoJob, Tile tile)
    {
        if (!protoJob.CanCreate(tile))
            return;
        var jobToCreate = new Job(protoJob) {Tile = tile};
        AvailableJobs.Add(jobToCreate);
        OnChange();
    }

    public void CreateBuilding(Building protoBuilding, Tile tile)
    {
        if (!tile.CanBuildHere())
        {
            return;
        }

        var buildingToCreate = new Building(protoBuilding) {Tile = tile};

        Buildings.Add(buildingToCreate);
        tile.Building = buildingToCreate;
        OnChange();
    }

    public static World Current { get; private set; }

    public int X => 0;

    public int Y => 0;

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }
}
