using System.Xml;
using System.Xml.Schema;
using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for World</summary>
    [TestClass]
    [PexClass(typeof(World))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class WorldTest
    {

        /// <summary>Test stub for .ctor(Difficulty, Int32)</summary>
        [PexMethod]
        public World ConstructorTest(Difficulty difficulty, int size)
        {
            World target = new World(difficulty, size);
            return target;
            // TODO: add assertions to method WorldTest.ConstructorTest(Difficulty, Int32)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public World ConstructorTest01()
        {
            World target = new World();
            return target;
            // TODO: add assertions to method WorldTest.ConstructorTest01()
        }

        /// <summary>Test stub for CreateBuilding(Building, Tile)</summary>
        [PexMethod]
        public void CreateBuildingTest(
            [PexAssumeUnderTest]World target,
            Building protoBuilding,
            Tile tile
        )
        {
            target.CreateBuilding(protoBuilding, tile);
            // TODO: add assertions to method WorldTest.CreateBuildingTest(World, Building, Tile)
        }

        /// <summary>Test stub for CreateEnemy(Enemy, Tile, Int32, Int32)</summary>
        [PexMethod]
        public void CreateEnemyTest(
            [PexAssumeUnderTest]World target,
            Enemy protoEnemy,
            Tile tile,
            int speed,
            int health
        )
        {
            target.CreateEnemy(protoEnemy, tile, speed, health);
            // TODO: add assertions to method WorldTest.CreateEnemyTest(World, Enemy, Tile, Int32, Int32)
        }

        /// <summary>Test stub for CreateProjectile(Projectile, Tile, Enemy)</summary>
        [PexMethod]
        public void CreateProjectileTest(
            [PexAssumeUnderTest]World target01,
            Projectile protoProjectile,
            Tile tile,
            Enemy target
        )
        {
            target01.CreateProjectile(protoProjectile, tile, target);
            // TODO: add assertions to method WorldTest.CreateProjectileTest(World, Projectile, Tile, Enemy)
        }

        /// <summary>Test stub for CreateRobot(Robot, Tile, Single)</summary>
        [PexMethod]
        public void CreateRobotTest(
            [PexAssumeUnderTest]World target,
            Robot protoRobot,
            Tile tile,
            float charge
        )
        {
            target.CreateRobot(protoRobot, tile, charge);
            // TODO: add assertions to method WorldTest.CreateRobotTest(World, Robot, Tile, Single)
        }

        /// <summary>Test stub for DemolishBuilding(Tile)</summary>
        [PexMethod]
        public void DemolishBuildingTest([PexAssumeUnderTest]World target, Tile tile)
        {
            target.DemolishBuilding(tile);
            // TODO: add assertions to method WorldTest.DemolishBuildingTest(World, Tile)
        }

        /// <summary>Test stub for DestroyEnemy(Enemy)</summary>
        [PexMethod]
        public void DestroyEnemyTest([PexAssumeUnderTest]World target, Enemy enemy)
        {
            target.DestroyEnemy(enemy);
            // TODO: add assertions to method WorldTest.DestroyEnemyTest(World, Enemy)
        }

        /// <summary>Test stub for DestroyProjectile(Projectile)</summary>
        [PexMethod]
        public void DestroyProjectileTest([PexAssumeUnderTest]World target, Projectile projectile)
        {
            target.DestroyProjectile(projectile);
            // TODO: add assertions to method WorldTest.DestroyProjectileTest(World, Projectile)
        }

        /// <summary>Test stub for GetSchema()</summary>
        [PexMethod]
        public XmlSchema GetSchemaTest([PexAssumeUnderTest]World target)
        {
            XmlSchema result = target.GetSchema();
            return result;
            // TODO: add assertions to method WorldTest.GetSchemaTest(World)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]World target)
        {
            target.OnChange();
            // TODO: add assertions to method WorldTest.OnChangeTest(World)
        }

        /// <summary>Test stub for ReadXml(XmlReader)</summary>
        [PexMethod]
        public void ReadXmlTest([PexAssumeUnderTest]World target, XmlReader reader)
        {
            target.ReadXml(reader);
            // TODO: add assertions to method WorldTest.ReadXmlTest(World, XmlReader)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]World target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method WorldTest.UpdateTest(World, Single)
        }

        /// <summary>Test stub for WriteXml(XmlWriter)</summary>
        [PexMethod]
        public void WriteXmlTest([PexAssumeUnderTest]World target, XmlWriter writer)
        {
            target.WriteXml(writer);
            // TODO: add assertions to method WorldTest.WriteXmlTest(World, XmlWriter)
        }

        /// <summary>Test stub for get_HeadQuarters()</summary>
        [PexMethod]
        public Building HeadQuartersGetTest([PexAssumeUnderTest]World target)
        {
            Building result = target.HeadQuarters;
            return result;
            // TODO: add assertions to method WorldTest.HeadQuartersGetTest(World)
        }

        /// <summary>Test stub for get_Item(Int32, Int32)</summary>
        [PexMethod]
        public Tile ItemGetTest(
            [PexAssumeUnderTest]World target,
            int x,
            int y
        )
        {
            Tile result = target[x, y];
            return result;
            // TODO: add assertions to method WorldTest.ItemGetTest(World, Int32, Int32)
        }

        /// <summary>Test stub for get_X()</summary>
        [PexMethod]
        public int XGetTest([PexAssumeUnderTest]World target)
        {
            int result = target.X;
            return result;
            // TODO: add assertions to method WorldTest.XGetTest(World)
        }

        /// <summary>Test stub for get_Y()</summary>
        [PexMethod]
        public int YGetTest([PexAssumeUnderTest]World target)
        {
            int result = target.Y;
            return result;
            // TODO: add assertions to method WorldTest.YGetTest(World)
        }
    }
}
