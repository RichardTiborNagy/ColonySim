namespace ColonySim
{
    using System.Linq;
    using UnityEngine;

    public static class Prototypes
    {
        public static readonly PrototypeManager<Robot> Robots;
        public static readonly PrototypeManager<Job> Jobs;
        public static readonly PrototypeManager<Building> Buildings;
        public static readonly PrototypeManager<Enemy> Enemies;
        public static readonly PrototypeManager<Projectile> Projectiles;

        static Prototypes()
        {
            Robots = new PrototypeManager<Robot>();
            Jobs = new PrototypeManager<Job>();
            Buildings = new PrototypeManager<Building>();
            Enemies = new PrototypeManager<Enemy>();
            Projectiles = new PrototypeManager<Projectile>();
            CreatePrototypes();
        }

        private static void CreatePrototypes()
        {
            CreateRobotPrototypes();
            CreateJobPrototypes();
            CreateBuildingPrototypes();
            CreateEnemyPrototypes();
            CreateProjectilePrototypes();
        }

        private static void CreateProjectilePrototypes()
        {
            Projectiles.Add(new Projectile("TurretProjectile", 20, projectile => projectile.Target.Health -= 3));
            Projectiles.Add(new Projectile("FreezerProjectile", 10,
                projectile => projectile.Target.Speed = Mathf.Max(projectile.Target.Speed - 1, 1)));
        }

        private static void CreateBuildingPrototypes()
        {
            Buildings.Add(new Building("HeadQuarter", 3, 0f));
            Buildings.Add(new Building("Wall", 1, 0f, true));
            Buildings.Add(new Building("Tree", 1, 2f));
            Buildings.Add(new Building("Road", 1, 0.75f));
            Buildings.Add(new Building("Spawner", 3, 0f, false, 5,
                b => { World.Current.CreateEnemy(Enemies.Get($"Enemy{Random.Range(0, 3)}"), b.Tile); }));
            Buildings.Add(new Building("Turret", 1, 0, false, 1f,
                b =>
                {
                    var enemyInRange =
                        World.Current.Enemies.FirstOrDefault(e => b.Tile.TilesInRange(4).Contains(e.Tile));
                    if (enemyInRange != null)
                    {
                        World.Current.CreateProjectile(Projectiles.Get("TurretProjectile"), b.Tile,
                            enemyInRange);
                    }

                    ;
                }));
            Buildings.Add(new Building("Freezer", 1, 0, false, 1f,
                b =>
                {
                    var enemyInRange =
                        World.Current.Enemies.FirstOrDefault(e => b.Tile.TilesInRange(5).Contains(e.Tile));
                    if (enemyInRange != null)
                    {
                        World.Current.CreateProjectile(Projectiles.Get("FreezerProjectile"), b.Tile,
                            enemyInRange);
                    }

                    ;
                }));
        }

        private static void CreateJobPrototypes()
        {
            Jobs.Add(new Job("BuildWall",
                job => World.Current.CreateBuilding(new Building(Buildings.Get("Wall")), job.Tile),
                3,
                "Construction",
                tile => tile.Empty,
                50));

            Jobs.Add(new Job("BuildRoad",
                job => World.Current.CreateBuilding(new Building(Buildings.Get("Road")), job.Tile),
                3,
                "Construction",
                tile => tile.Empty,
                25));

            Jobs.Add(new Job("BuildTurret",
                job => World.Current.CreateBuilding(new Building(Buildings.Get("Turret")), job.Tile),
                5,
                "Construction",
                tile => tile.Empty,
                75));

            Jobs.Add(new Job("BuildFreezer",
                job => World.Current.CreateBuilding(new Building(Buildings.Get("Freezer")), job.Tile),
                8,
                "Construction",
                tile => tile.Empty,
                100));

            Jobs.Add(new Job("Demolish",
                job => World.Current.DemolishBuilding(job.Tile),
                5,
                "Construction",
                tile => tile.HasBuilding && tile.Building.Type != "Spawner" && tile.Building.Type != "HeadQuarter",
                0));

            Jobs.Add(new Job("Gather",
                job =>
                {
                    World.Current.DemolishBuilding(job.Tile);
                    World.Current.CreateBuilding(Buildings.Get("Tree"),
                        World.Current.Tiles[Random.Range(0, 50), Random.Range(0, 50)]);
                    World.Current.Resources += 25;
                },
                4,
                "Gatherer",
                tile => tile.HasBuildingWithType("Tree"),
                0));

            Jobs.Add(new Job("Charge",
                job => job.Robot.Charge = 100f,
                5,
                "All",
                t => true,
                0
            ));
        }

        private static void CreateRobotPrototypes()
        {
            Robots.Add(new Robot("Construction", 20, 25));
            Robots.Add(new Robot("Gatherer", 30, 20));
        }

        private static void CreateEnemyPrototypes()
        {
            Enemies.Add(new Enemy("Enemy0", 15, 5));
            Enemies.Add(new Enemy("Enemy1", 10, 15));
            Enemies.Add(new Enemy("Enemy2", 5, 50));
        }
    }
}