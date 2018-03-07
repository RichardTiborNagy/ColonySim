using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JobPrototypes
{
    private static readonly Dictionary<string, Job> Jobs;

    public static Job CloneJob(string type)
    {
        return new Job(Jobs[type]);
    }

    static JobPrototypes()
    {
        Jobs = new Dictionary<string, Job>();
        CreatePrototypes();
    }

    private static void CreatePrototypes()
    {
        Jobs.Add("BuildWall", new Job("BuildWall", ((job) => World.Current.Build(BuildingPrototypes.CloneBuilding("Wall"), job.Tile))));
    }
}
