using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;

public class WorldView : View<World>
{
    public World World;

    public Dictionary<Tile, GameObject> TileViews = new Dictionary<Tile, GameObject>();
    public Dictionary<Building, GameObject> BuildingViews = new Dictionary<Building, GameObject>();
    public Dictionary<Robot, GameObject> RobotViews = new Dictionary<Robot, GameObject>();
    public Dictionary<Job, GameObject> JobViews = new Dictionary<Job, GameObject>();

    
    private new void Awake()
    {
        World = new World(50);
        SetTarget(World);
        Refresh();
    }

    public void Update()
    {
        World.Update(Time.deltaTime);
        //Debug.Log(JobViews.Count);
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

        var newBuildingsToDisplay = World.Current.Buildings.Where(b => !BuildingViews.ContainsKey(b)).ToList();
        foreach (var building in newBuildingsToDisplay)
        {
            var buildingGo = Instantiate(ViewManager.GetView("Building"));
            buildingGo.GetComponent<BuildingView>().SetTarget(building);
            BuildingViews.Add(building, buildingGo);
        }

        var buildingsToDestroy = BuildingViews.Keys.Where(b => !World.Current.Buildings.Contains(b)).ToList();
        foreach (var building in buildingsToDestroy)
        {
            Destroy(BuildingViews[building]);
            BuildingViews.Remove(building);
        }

        var newRobotsToDisplay = World.Current.Robots.Where(r => !RobotViews.ContainsKey(r)).ToList();
        foreach (var robot in newRobotsToDisplay)
        {
            var robotGo = Instantiate(ViewManager.GetView("Robot"));
            robotGo.GetComponent<RobotView>().SetTarget(robot);
            RobotViews.Add(robot, robotGo);
        }

        var robotsToDestroy = RobotViews.Keys.Where(r => !World.Robots.Contains(r)).ToList();
        foreach (var robot in robotsToDestroy)
        {
            Destroy(RobotViews[robot]);
            RobotViews.Remove(robot);
        }

        var newJobsToDisplay = World.JobManager.Jobs.Where(j => !JobViews.ContainsKey(j)).ToList();
        foreach (var job in newJobsToDisplay)
        {
            var jobGo = Instantiate(ViewManager.GetView("Job"));
            jobGo.GetComponent<JobView>().SetTarget(job);
            JobViews.Add(job, jobGo);
        }

        var jobsToDestroy = JobViews.Keys.Where(j => !World.JobManager.Jobs.Contains(j)).ToList();
        foreach (var job in jobsToDestroy)
        {
            var jobGo = JobViews[job];
            Destroy(jobGo);
            JobViews.Remove(job);
        }

    }
}
