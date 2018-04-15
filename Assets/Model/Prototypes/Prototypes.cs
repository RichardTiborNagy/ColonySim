using System.Linq;
using UnityEngine;

public static class Prototypes
{
    public static readonly PrototypeManager<Robot> Robots;
    public static readonly PrototypeManager<Job> Jobs;
    public static readonly PrototypeManager<Building> Buildings;
    public static readonly PrototypeManager<Enemy> Enemies;

    static Prototypes()
    {
        Robots = new PrototypeManager<Robot>();
        Jobs = new PrototypeManager<Job>();
        Buildings = new PrototypeManager<Building>();
        Enemies = new PrototypeManager<Enemy>();
        CreatePrototypes();
    }

    private static void CreatePrototypes()
    {
        CreateRobotPrototypes();
        CreateJobPrototypes();
        CreateBuildingPrototypes();
        CreateEnemyPrototypes();
    }

    private static void CreateBuildingPrototypes()
    {
        Buildings.Add(new Building("HeadQuarter", 3, 0f));
        Buildings.Add(new Building("Wall", 1, 0f, true));
        Buildings.Add(new Building("Tree", 1, 2f));
        Buildings.Add(new Building("Spawner", 3, 0f, false, 5,
            b => { World.Current.CreateEnemy(Prototypes.Enemies.Get($"Enemy{Random.Range(0, 3)}"), b.Tile); }));
    }

    private static void CreateJobPrototypes()
    {
        Jobs.Add(new Job("BuildWall",
            job => World.Current.CreateBuilding(new Building(Buildings.Get("Wall")), job.Tile),
            2,
            "Construction",
            tile => tile.Empty));

        Jobs.Add(new Job("Demolish",
            job => World.Current.DemolishBuilding(job.Tile),
            5,
            "Construction",
            tile => tile.HasBuilding));

        Jobs.Add(new Job("Gather",
            job => World.Current.DemolishBuilding(job.Tile),
            4,
            "Gatherer",
            tile => tile.HasBuildingWithType("Tree")
            ));

        Jobs.Add(new Job("Charge",
            job => job.Robot.Charge = 100f,
            5,
            "All",
            t => true
        ));
    }

    private static void CreateRobotPrototypes()
    {
        Robots.Add(new Robot("Construction", 20));
        Robots.Add(new Robot("Gatherer", 30));
    }

    private static void CreateEnemyPrototypes()
    {
        Enemies.Add(new Enemy("Enemy0", 15, 5));
        Enemies.Add(new Enemy("Enemy1", 10, 15));
        Enemies.Add(new Enemy("Enemy2", 5, 50));
    }
}