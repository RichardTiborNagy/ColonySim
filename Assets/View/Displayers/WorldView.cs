using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WorldView : View<World>
{
    public World World;

    public Dictionary<Tile, GameObject> TileViews = new Dictionary<Tile, GameObject>();
    public Dictionary<Building, GameObject> BuildingViews = new Dictionary<Building, GameObject>();
    public Dictionary<Robot, GameObject> RobotViews = new Dictionary<Robot, GameObject>();
    public Dictionary<Job, GameObject> JobViews = new Dictionary<Job, GameObject>();
    public Dictionary<Enemy, GameObject> EnemyViews = new Dictionary<Enemy, GameObject>();
    public Dictionary<Projectile, GameObject> ProjectileViews = new Dictionary<Projectile, GameObject>();

    public GameObject GameplayCanvas;
    public GameObject MenuCanvas;

    public GameObject ResourceWidget;
    public GameObject HealthWidget;
    public GameObject TimeWidget;
    public GameObject Text;

    private new void Awake()
    {
        World = new World(Difficulty.Easy);
        SetTarget(World);
        Refresh();
    }

    public void NewGame(int difficulty)
    {
        World = new World((Difficulty)difficulty);
        foreach (var keyValuePair in TileViews)
        {
            Destroy(keyValuePair.Value);
        }
        foreach (var keyValuePair in BuildingViews)
        {
            Destroy(keyValuePair.Value);
        }
        foreach (var keyValuePair in RobotViews)
        {
            Destroy(keyValuePair.Value);
        }
        foreach (var keyValuePair in JobViews)
        {
            Destroy(keyValuePair.Value);
        }
        foreach (var keyValuePair in EnemyViews)
        {
            Destroy(keyValuePair.Value);
        }
        foreach (var keyValuePair in ProjectileViews)
        {
            Destroy(keyValuePair.Value);
        }
        TileViews = new Dictionary<Tile, GameObject>();
        BuildingViews = new Dictionary<Building, GameObject>();
        RobotViews = new Dictionary<Robot, GameObject>();
        JobViews = new Dictionary<Job, GameObject>();
        EnemyViews = new Dictionary<Enemy, GameObject>();
        ProjectileViews = new Dictionary<Projectile, GameObject>();
        SetTarget(World);
        Refresh();
        Pause();
    }

    public void BuyRobot(string type)
    {
        World.CreateRobot(Prototypes.Robots.Get(type), World.HeadQuarters.Tile);
    }

    public void Update()
    {
        World.Update(Time.deltaTime);
        ResourceWidget.GetComponentInChildren<Text>().text = $"Resources: {World.Resources}";
        HealthWidget.GetComponentInChildren<Text>().text = $"Health: {World.Health}";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        TimeWidget.GetComponentInChildren<Text>().text = $"Time left: {Mathf.RoundToInt(World.RemainingTime)}";
        if (!World.Paused)
        {
            CheckGameOver();
        }
    }

    private void Pause()
    {
        World.Paused = !World.Paused;
        GameplayCanvas.SetActive(!GameplayCanvas.active);
        MenuCanvas.SetActive(!MenuCanvas.active);
    }

    private void CheckGameOver()
    {
        if (World.RemainingTime < 0)
        {
            Text.GetComponentInChildren<Text>().text = "You won!";
            Pause();
        }
        else if (World.Health < 0)
        {
            Text.GetComponentInChildren<Text>().text = "You lost!";
            Pause();
        }
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

        var newEnemiesToDisplay = World.Current.Enemies.Where(e => !EnemyViews.ContainsKey(e)).ToList();
        foreach (var enemy in newEnemiesToDisplay)
        {
            var enemyGo = Instantiate(ViewManager.GetView("Enemy"));
            enemyGo.GetComponent<EnemyView>().SetTarget(enemy);
            EnemyViews.Add(enemy, enemyGo);
        }

        var enemiesToDestroy = EnemyViews.Keys.Where(e => !World.Enemies.Contains(e)).ToList();
        foreach (var enemy in enemiesToDestroy)
        {
            Destroy(EnemyViews[enemy]);
            EnemyViews.Remove(enemy);
        }

        var newProjectilesToDisplay = World.Current.Projectiles.Where(p => !ProjectileViews.ContainsKey(p)).ToList();
        foreach (var projectile in newProjectilesToDisplay)
        {
            var projectileGo = Instantiate(ViewManager.GetView("Projectile"));
            projectileGo.GetComponent<ProjectileView>().SetTarget(projectile);
            ProjectileViews.Add(projectile, projectileGo);
        }

        var projectilesToDestroy = ProjectileViews.Keys.Where(p => !World.Projectiles.Contains(p)).ToList();
        foreach (var projectile in projectilesToDestroy)
        {
            Destroy(ProjectileViews[projectile]);
            ProjectileViews.Remove(projectile);
        }

    }
}
