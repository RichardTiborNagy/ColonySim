using System.Linq;

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
        Buildings.Add(new Building("Wall", 1, 0f, true, null));
        Buildings.Add(new Building("Tree", 1, 2f, false, null));
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
    }

    private static void CreateRobotPrototypes()
    {
        Robots.Add(new Robot("Construction", 20));
        Robots.Add(new Robot("Gatherer", 30));
    }
}