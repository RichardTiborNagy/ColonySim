using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingPrototypes
{
    private static Dictionary<string, Building> buildings;

    public static Building CloneBuilding(string type)
    {
        return new Building(buildings[type]);
    }

    static BuildingPrototypes()
    {
        buildings = new Dictionary<string, Building>();
        CreatePrototypes();
    }

    private static void CreatePrototypes()
    {
        buildings.Add("Wall", new Building("Wall", 1, 1, 100, true));
    }
}
