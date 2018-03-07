using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingPrototypes //: PrototypeManager<Building>
{
    private static readonly Dictionary<string, Building> Buildings;

    public static Building CloneBuilding(string type)
    {
        return new Building(Buildings[type]);
    }

    static BuildingPrototypes()
    {
        Buildings = new Dictionary<string, Building>();
        CreatePrototypes();
    }

    private static void CreatePrototypes()
    {
        Buildings.Add("Wall", new Building("Wall", 1, 1, 100, true));
    }
}
