using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ColonySim
{
    public class World : IDisplayable, IXmlSerializable
    {
        private const float StartingTime = 300f;

        private int _size;

        public World(Difficulty difficulty, int size = 50)
        {
            Current = this;
            size = Mathf.Max(size, 10);
            _size = size;
            Tiles = new Tile[size, size];
            for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
                Tiles[i, j] = new Tile(i, j);

            Buildings = new List<Building>();

            Robots = new List<Robot>();

            Enemies = new List<Enemy>();

            Projectiles = new List<Projectile>();

            JobManager = new JobManager();

            Graph = new Graph(this);

            OnChange();

            GenerateEnvironment(size, difficulty);

            RemainingTime = StartingTime;
        }

        public World()
        {
            Current = this;

            Buildings = new List<Building>();

            Robots = new List<Robot>();

            Enemies = new List<Enemy>();

            Projectiles = new List<Projectile>();

            JobManager = new JobManager();
        }

        public event Action Changed;

        public static World Current { get; private set; }

        public List<Building> Buildings { get; private set; }

        public List<Enemy> Enemies { get; private set; }

        public Graph Graph { get; private set; }

        public Building HeadQuarters => /*Buildings.Find(b => b.Type == "HeadQuarter");//*/ Buildings[0];
        public int Health { get; set; } = 100;

        public JobManager JobManager { get; private set; }

        public bool Paused { get; set; } = true;

        public List<Projectile> Projectiles { get; private set; }

        public float RemainingTime { get; set; }
        public int Resources { get; set; } = 800;

        public List<Robot> Robots { get; private set; }

        public Tile[,] Tiles { get; set; }

        public int X => 0;

        public int Y => 0;

        public Tile this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= _size || y < 0 || y >= _size)
                    return null;
                return Tiles[x, y];
            }
        }

        public void CreateBuilding(Building protoBuilding, Tile tile)
        {
            if (tile.HasBuilding) return;

            var tilesToOccupy = new List<Tile>();

            for (var i = 0; i < protoBuilding.Size; i++)
            for (var j = 0; j < protoBuilding.Size; j++)
            {
                var tileToOccupy = Tiles[tile.X + i, tile.Y + j];
                if (tileToOccupy == null) return;
                tilesToOccupy.Add(tileToOccupy);
            }

            if (tilesToOccupy.Any(t => !t.CanBuildHere())) return;

            var buildingToCreate = new Building(protoBuilding) {Tile = tile};

            Buildings.Add(buildingToCreate);
            tilesToOccupy.ForEach(t => t.Building = buildingToCreate);
            tilesToOccupy.ForEach(t =>
                t.Neighbors.Where(n => n.Building?.Conjoined ?? false).ToList().ForEach(n => n?.Building?.OnChange()));
            tilesToOccupy.ForEach(t => Graph.RecreateEdges(t));

            buildingToCreate.OnChange();

            OnChange();
        }

        public void CreateEnemy(Enemy protoEnemy, Tile tile, int speed = 0, int health = 0)
        {
            var enemyToCreate = new Enemy(protoEnemy);
            Enemies.Add(enemyToCreate);
            enemyToCreate.Tile = enemyToCreate.NextTile = tile;
            if (speed > 0 && health > 0)
            {
                enemyToCreate.Speed = speed;
                enemyToCreate.Health = health;
            }

            OnChange();
        }

        public void CreateProjectile(Projectile protoProjectile, Tile tile, Enemy target)
        {
            var projectileToCreate = new Projectile(protoProjectile)
            {
                Target = target,
                Position = new Vector2(tile.X, tile.Y)
            };
            Projectiles.Add(projectileToCreate);
            OnChange();
        }


        public void CreateRobot(Robot protoRobot, Tile tile, float charge = 0)
        {
            if (protoRobot.Cost > Resources && charge == 0) return;
            var robotToCreate = new Robot(protoRobot);
            Robots.Add(robotToCreate);
            robotToCreate.Tile = robotToCreate.Destination = robotToCreate.NextTile = tile;
            if (charge == 0) Resources -= robotToCreate.Cost;
            if (charge > 0) robotToCreate.Charge = charge;

            OnChange();
        }

        public void DemolishBuilding(Tile tile)
        {
            if (!tile.HasBuilding) return;
            var buildingToDemolish = tile.Building;
            var mainTile = buildingToDemolish.Tile;
            var tilesToDemolish = new List<Tile>();

            for (var i = 0; i < buildingToDemolish.Size; i++)
            for (var j = 0; j < buildingToDemolish.Size; j++)
            {
                var tileToDemolish = Tiles[mainTile.X + i, mainTile.Y + j];
                tilesToDemolish.Add(tileToDemolish);
            }

            buildingToDemolish.Tile = null;
            Buildings.Remove(buildingToDemolish);
            tilesToDemolish.ForEach(t => t.Building = null);
            tilesToDemolish.ForEach(t => Graph.RecreateEdges(t));

            foreach (var tileToDemolish in tilesToDemolish)
            foreach (var neighbor in tileToDemolish.Neighbors)
                neighbor?.Building?.OnChange();

            OnChange();
        }

        public void DestroyEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
            OnChange();
        }

        public void DestroyProjectile(Projectile projectile)
        {
            Projectiles.Remove(projectile);
            OnChange();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void OnChange()
        {
            Changed?.Invoke();
        }

        public void ReadXml(XmlReader reader)
        {
            _size = int.Parse(reader.GetAttribute("Size"));
            Resources = int.Parse(reader.GetAttribute("Resources"));
            RemainingTime = float.Parse(reader.GetAttribute("RemainingTime"));
            Health = int.Parse(reader.GetAttribute("Health"));

            Current = this;
            Tiles = new Tile[_size, _size];
            for (var i = 0; i < _size; i++)
            for (var j = 0; j < _size; j++)
                Tiles[i, j] = new Tile(i, j);

            Buildings = new List<Building>();

            Robots = new List<Robot>();

            Enemies = new List<Enemy>();

            Projectiles = new List<Projectile>();

            JobManager = new JobManager();

            Graph = new Graph(this);

            OnChange();

            while (reader.Read())
                switch (reader.Name)
                {
                    case "Buildings":
                        ReadXmlBuildings(reader);
                        break;
                    case "Robots":
                        ReadXmlRobots(reader);
                        break;
                    case "Enemies":
                        ReadXmlEnemies(reader);
                        break;
                    case "Jobs":
                        ReadXmlJobs(reader);
                        break;
                }
        }

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

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Size", _size.ToString());
            writer.WriteAttributeString("Resources", Resources.ToString());
            writer.WriteAttributeString("RemainingTime", RemainingTime.ToString());
            writer.WriteAttributeString("Health", Health.ToString());

            writer.WriteStartElement("Buildings");
            foreach (var building in Buildings)
            {
                writer.WriteStartElement("Building");
                writer.WriteAttributeString("Type", building.Type);
                writer.WriteAttributeString("X", building.X.ToString());
                writer.WriteAttributeString("Y", building.Y.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteStartElement("Robots");
            foreach (var robot in Robots)
            {
                writer.WriteStartElement("Robot");
                writer.WriteAttributeString("Type", robot.Type);
                writer.WriteAttributeString("X", robot.X.ToString());
                writer.WriteAttributeString("Y", robot.Y.ToString());
                writer.WriteAttributeString("Charge", robot.Charge.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteStartElement("Enemies");
            foreach (var enemy in Enemies)
            {
                writer.WriteStartElement("Enemy");
                writer.WriteAttributeString("Type", enemy.Type);
                writer.WriteAttributeString("X", enemy.X.ToString());
                writer.WriteAttributeString("Y", enemy.Y.ToString());
                writer.WriteAttributeString("Speed", enemy.Speed.ToString());
                writer.WriteAttributeString("Health", enemy.Health.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteStartElement("Jobs");
            foreach (var job in JobManager.Jobs)
            {
                writer.WriteStartElement("Job");
                writer.WriteAttributeString("Type", job.Type);
                writer.WriteAttributeString("X", job.X.ToString());
                writer.WriteAttributeString("Y", job.Y.ToString());
                writer.WriteAttributeString("AmountDone", job.AmountDone.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private void GenerateEnvironment(int size, Difficulty difficulty)
        {
            CreateBuilding(Prototypes.Buildings.Get("HeadQuarter"), Tiles[24, 24]);
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

            for (var i = 0; i < 200; i++)
            {
                var x = Random.Range(0, size);
                var y = Random.Range(0, size);
                CreateBuilding(Prototypes.Buildings.Get("Tree"), Tiles[x, y]);
            }
        }

        private void ReadXmlBuildings(XmlReader reader)
        {
            if (!reader.ReadToDescendant("Building")) return;
            do
            {
                CreateBuilding(Prototypes.Buildings.Get(reader.GetAttribute("Type")),
                    Tiles[int.Parse(reader.GetAttribute("X")), int.Parse(reader.GetAttribute("Y"))]);
            } while (reader.ReadToNextSibling("Building"));
        }

        private void ReadXmlEnemies(XmlReader reader)
        {
            if (!reader.ReadToDescendant("Enemy")) return;
            do
            {
                CreateEnemy(Prototypes.Enemies.Get(reader.GetAttribute("Type")),
                    Tiles[int.Parse(reader.GetAttribute("X")), int.Parse(reader.GetAttribute("Y"))],
                    int.Parse(reader.GetAttribute("Speed")),
                    int.Parse(reader.GetAttribute("Health")));
            } while (reader.ReadToNextSibling("Enemy"));
        }

        private void ReadXmlJobs(XmlReader reader)
        {
            if (!reader.ReadToDescendant("Job")) return;
            do
            {
                JobManager.CreateJob(Prototypes.Jobs.Get(reader.GetAttribute("Type")),
                    Tiles[int.Parse(reader.GetAttribute("X")), int.Parse(reader.GetAttribute("Y"))],
                    float.Parse(reader.GetAttribute("AmountDone")));
            } while (reader.ReadToNextSibling("Job"));
        }

        private void ReadXmlRobots(XmlReader reader)
        {
            if (!reader.ReadToDescendant("Robot")) return;
            do
            {
                CreateRobot(Prototypes.Robots.Get(reader.GetAttribute("Type")),
                    Tiles[int.Parse(reader.GetAttribute("X")), int.Parse(reader.GetAttribute("Y"))],
                    float.Parse(reader.GetAttribute("Charge")));
            } while (reader.ReadToNextSibling("Robot"));
        }

        private void UpdateBuildings(float deltaTime)
        {
            Buildings.ForEach(building => building.Update(deltaTime));
            var spawnerInterval = Mathf.Max(1f, RemainingTime / StartingTime * 5);
            foreach (var building in Buildings.Where(b => b.Type == "Spawner"))
                building.UpdateInterval = spawnerInterval;
        }

        private void UpdateEnemies(float deltaTime)
        {
            Enemies.ForEach(enemy => enemy.Update(deltaTime));
        }

        private void UpdateProjectiles(float deltaTime)
        {
            Projectiles.ForEach(projectile => projectile.Update(deltaTime));
        }

        private void UpdateRobots(float deltaTime)
        {
            Robots.ForEach(robot => robot.Update(deltaTime));
        }
    }
}