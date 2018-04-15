using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class World : IDisplayable
{
    private readonly int _size;

    public World(int size)
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

        JobManager = new JobManager();

        Graph = new Graph(this);
        
        OnChange();

        GenerateEnvironment();
    }

    private void GenerateEnvironment()
    {
        CreateBuilding(Prototypes.Buildings.Get("HeadQuarter"), Tiles[24,24]);
        CreateBuilding(Prototypes.Buildings.Get("Spawner"), Tiles[3, 3]);
        for (int i = 0; i < 200; i++)
        {
            var x = Random.Range(0, 50);
            var y = Random.Range(0, 50);
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

    public JobManager JobManager { get; private set; }

    public void Update(float deltaTime)
    {
        Robots.ForEach(robot => robot.Update(deltaTime));

        try
        {
            Enemies.ForEach(enemy => enemy.Update(deltaTime));
        }
        catch
        {
        }

        Buildings.ForEach(building => building.Update(deltaTime));

        JobManager.Update(deltaTime);
    }


    public void CreateRobot(Robot protoRobot, Tile tile)
    {
        var robotToCreate = new Robot(protoRobot);
        Robots.Add(robotToCreate);
        robotToCreate.Tile = robotToCreate.Destination = robotToCreate.NextTile = tile;
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
    public int Health { get; set; } = 500;

    public event Action Changed;

    public void OnChange()
    {
        Changed?.Invoke();
    }
}
