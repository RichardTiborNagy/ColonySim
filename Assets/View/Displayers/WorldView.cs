﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class WorldView : View<World>
{
    public World World;

    public Dictionary<Tile, GameObject> TileViews = new Dictionary<Tile, GameObject>();
    public Dictionary<Building, GameObject> BuildingViews = new Dictionary<Building, GameObject>();
    
    private new void Awake()
    {
        World = new World(100);
        SetTarget(World);
        Refresh();
    }

    protected override void Refresh()
    {
        foreach (var tile in World.Tiles)
        {
            if (!TileViews.ContainsKey(tile))
            {
                var tileGo = Instantiate(ViewManager.GetView("Tile"));
                tileGo.GetComponent<TileView>().SetTarget(tile);
                TileViews.Add(tile, tileGo);
            }
        }

        foreach (var building in World.Buildings)
        {
            if (!BuildingViews.ContainsKey(building))
            {
                var buildingGo = Instantiate(ViewManager.GetView("Building"));
                buildingGo.GetComponent<BuildingView>().SetTarget(building);
                BuildingViews.Add(building, buildingGo);
            }
        }

        foreach (var building in BuildingViews.Keys)
        {
            if (!World.Buildings.Contains(building))
            {
                BuildingViews.Remove(building);
                Destroy(BuildingViews[building]);
            }
        }
    }
}