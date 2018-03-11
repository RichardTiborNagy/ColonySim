using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prototypes
{
    public static readonly PrototypeManager<Robot> Robots;
    public static readonly PrototypeManager<Job> Jobs;
    public static readonly PrototypeManager<Building> Buildings;

    static Prototypes()
    {
        Robots = new PrototypeManager<Robot>();
        Jobs = new PrototypeManager<Job>();
        Buildings = new PrototypeManager<Building>();
        CreatePrototypes();
    }

    private static void CreatePrototypes()
    {
        CreateRobotPrototypes();
        CreateJobPrototypes();
        CreateBuildingPrototypes();
    }

    private static void CreateBuildingPrototypes()
    {
        Buildings.Add(new Building("Wall", 1, 1, 100, true, null));
    }

    private static void CreateJobPrototypes()
    {
        Jobs.Add(new Job("BuildWall",
            (job) => World.Current.CreateBuilding(new Building(Prototypes.Buildings.Get("Wall")), job.Tile),
            2,
            "Construction",
            (tile) => tile.Empty));
    }

    private static void CreateRobotPrototypes()
    {
        Robots.Add(new Robot("Construction", 5));
    }
}
