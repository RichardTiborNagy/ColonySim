using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class World : IDisplayable
{
    private const float StartingTime = 300f;

    private readonly int _size;

    public bool Paused { get; set; } = true;

    public float RemainingTime { get; set; } 

    public World(Difficulty difficulty, int size = 50)
    {
        Current = this;
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
        
        Robots = new List<Robot>();

        Enemies = new List<Enemy>();

        Projectiles = new List<Projectile>();

        JobManager = new JobManager();

        Graph = new Graph(this);
        
        OnChange();

        GenerateEnvironment(size, difficulty);

        RemainingTime = StartingTime;
    }

    private void GenerateEnvironment(int size, Difficulty difficulty)
    {
        CreateBuilding(Prototypes.Buildings.Get("HeadQuarter"), Tiles[24,24]);
        switch (difficulty)
        {
            case Difficulty.Easy:
                CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[3, 3]);
                break;
            case Difficulty.Medium:
                CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[3, 3]);
                CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[size - 6, 3]);
                break;
            case Difficulty.Hard:
                CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[3, 3]);
                CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[size - 6, 3]);
                CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[3, size - 6]);
                CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[size - 6, size - 3]);
                break;
            default:
                return;
        }
        for (int i = 0; i < 200; i++)
        {
            var x = Random.Range(0, size);
            var y = Random.Range(0, size);
            CreateBuilding(Prototypes.Buildings.Get("Tree"), Tiles[x, y]);
        }
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

    public Graph Graph { get; private set; }

    public List<Building> Buildings { get; private set; }

    public List<Robot> Robots { get; private set; }

    public List<Enemy> Enemies { get; private set; }

    public List<Projectile> Projectiles { get; private set; }

    public JobManager JobManager { get; private set; }

    public void Update(float deltaTime)
    {
        if (Paused) return;
        RemainingTime -= deltaTime;
        UpdateRobots(deltaTime);
        UpdateEnemies(deltaTime);
        UpdateBuildings(deltaTime);
        UpdateProjectiles(deltaTime);
        JobManager.Update(deltaTime);
    }

    private void UpdateRobots(float deltaTime)
    {
        Robots.ForEach(robot => robot.Update(deltaTime));
    }

    private void UpdateEnemies(float deltaTime)
    {
        Enemies.ForEach(enemy => enemy.Update(deltaTime));
    }

    private void UpdateBuildings(float deltaTime)
    {
        Buildings.ForEach(building => building.Update(deltaTime));
        var spawnerInterval = Mathf.Max(1f, RemainingTime / StartingTime * 5);
        foreach (var building in Buildings.Where(b => b.Type == "Spawner"))
        {
            building.UpdateInterval = spawnerInterval;
        }
    }

    private void UpdateProjectiles(float deltaTime)
    {
        Projectiles.ForEach(projectile => projectile.Update(deltaTime));
    }


    public void CreateRobot(Robot protoRobot, Tile tile)
    {
        if (protoRobot.Cost > Resources) return;
        var robotToCreate = new Robot(protoRobot);
        Robots.Add(robotToCreate);
        robotToCreate.Tile = robotToCreate.Destination = robotToCreate.NextTile = tile;
        Resources -= robotToCreate.Cost;
        OnChange();
    }

    public void CreateProjectile(Projectile protoProjectile, Tile tile, Enemy target)
    {
        var projectileToCreate = new Projectile(protoProjectile);
        projectileToCreate.Target = target;
        projectileToCreate.Position = new Vector2(tile.X, tile.Y);
        Projectiles.Add(projectileToCreate);
        OnChange();
    }

    public void DestroyProjectile(Projectile projectile)
    {
        Projectiles.Remove(projectile);
        OnChange();
    }

    public void CreateEnemy(Enemy protoEnemy, Tile tile)
    {
        var enemyToCreate = new Enemy(protoEnemy);
        Enemies.Add(enemyToCreate);
        enemyToCreate.Tile = enemyToCreate.NextTile = tile;
        //enemyToCreate.Destination = HeadQuarters.Tile;
        OnChange();
    }

    public void DestroyEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
        OnChange();
    }

    public void CreateBuilding(Building protoBuilding, Tile tile)
    {
        if (tile.HasBuilding) return;

        var tilesToOccupy = new List<Tile>();

        for (int i = 0; i < protoBuilding.Size; i++)
        {
            for (int j = 0; j < protoBuilding.Size; j++)
            {
                var tileToOccupy = Tiles[tile.X + i, tile.Y + j];
                if (tileToOccupy == null) return;
                tilesToOccupy.Add(tileToOccupy);
            }
        }

        if (tilesToOccupy.Any(t => !t.CanBuildHere()))
        {
            return;
        }

        var buildingToCreate = new Building(protoBuilding) {Tile = tile};

        Buildings.Add(buildingToCreate);
        tilesToOccupy.ForEach(t => t.Building = buildingToCreate);
        tilesToOccupy.ForEach(t => t.Neighbors.Where(n => n.Building?.Conjoined ?? false).ToList().ForEach(n => n?.Building?.OnChange()));
        tilesToOccupy.ForEach(t => Graph.RecreateEdges(t));

        buildingToCreate.OnChange();

        OnChange();
    }

    public void DemolishBuilding(Tile tile)
    {
        if (!tile.HasBuilding) return;
        var buildingToDemolish = tile.Building;
        var mainTile = buildingToDemolish.Tile;
        var tilesToDemolish = new List<Tile>();

        for (int i = 0; i < buildingToDemolish.Size; i++)
        {
            for (int j = 0; j < buildingToDemolish.Size; j++)
            {
                var tileToDemolish = Tiles[mainTile.X + i, mainTile.Y + j];
                tilesToDemolish.Add(tileToDemolish);
            }
        }

        buildingToDemolish.Tile = null;
        Buildings.Remove(buildingToDemolish);
        tilesToDemolish.ForEach(t => t.Building = null);
        tilesToDemolish.ForEach(t => Graph.RecreateEdges(t));

        foreach (var tileToDemolish in tilesToDemolish)
        {
            foreach (var neighbor in tileToDemolish.Neighbors)
            {
                neighbor?.Building?.OnChange();
            }
        }

        OnChange();
    }

    public Building HeadQuarters => /*Buildings.Find(b => b.Type == "HeadQuarter");//*/ Buildings[0];

    public static World Current { get; private set; }

    public int X => 0;

    public int Y => 0;
    public int Resources { get; set; } = 800;
    public int Health { get; set; } = 100;

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }
}
