using System;
using System.Collections.Generic;
using System.Linq;

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

        Jobs = new Queue<Job>();
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

    public Queue<Job> Jobs { get; private set; }

    public void Update(float deltaTime)
    {
        foreach (var robot in Robots)
        {
            robot.Update(deltaTime);
        }
    }

    public void CreateRobot(Robot protoRobot, Tile tile)
    {
        Robot robotToCreate = new Robot(protoRobot);
        Robots.Add(robotToCreate);
        robotToCreate.Tile = tile;
        robotToCreate.Destination = tile;
        OnChange();
    }

    public void NewJob(Job protoJob, Tile tile)
    {
        Job jobToCreate = new Job(protoJob);
        jobToCreate.Tile = tile;
        Jobs.Enqueue(jobToCreate);
    }

    public void Build(Building protoBuilding, Tile tile)
    {
        if (!tile.CanBuildHere())
        {
            return;
        }
        Building buildingToCreate = new Building(protoBuilding);
        Buildings.Add(buildingToCreate);
        buildingToCreate.Tile = tile;
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
