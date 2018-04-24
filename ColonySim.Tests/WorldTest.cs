using System.Xml;
using System.Xml.Schema;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for World</summary>
    [TestClass]
    [PexClass(typeof(global::World))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class WorldTest
    {

        /// <summary>Test stub for .ctor(Difficulty, Int32)</summary>
        [PexMethod]
        public global::World ConstructorTest(global::Difficulty difficulty, int size)
        {
            global::World target = new global::World(difficulty, size);
            return target;
            // TODO: add assertions to method WorldTest.ConstructorTest(Difficulty, Int32)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public global::World ConstructorTest01()
        {
            global::World target = new global::World();
            return target;
            // TODO: add assertions to method WorldTest.ConstructorTest01()
        }

        /// <summary>Test stub for CreateBuilding(Building, Tile)</summary>
        [PexMethod]
        public void CreateBuildingTest(
            [PexAssumeUnderTest]global::World target,
            global::Building protoBuilding,
            global::Tile tile
        )
        {
            target.CreateBuilding(protoBuilding, tile);
            // TODO: add assertions to method WorldTest.CreateBuildingTest(World, Building, Tile)
        }

        /// <summary>Test stub for CreateEnemy(Enemy, Tile, Int32, Int32)</summary>
        [PexMethod]
        public void CreateEnemyTest(
            [PexAssumeUnderTest]global::World target,
            global::Enemy protoEnemy,
            global::Tile tile,
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
            [PexAssumeUnderTest]global::World target01,
            global::Projectile protoProjectile,
            global::Tile tile,
            global::Enemy target
        )
        {
            target01.CreateProjectile(protoProjectile, tile, target);
            // TODO: add assertions to method WorldTest.CreateProjectileTest(World, Projectile, Tile, Enemy)
        }

        /// <summary>Test stub for CreateRobot(Robot, Tile, Single)</summary>
        [PexMethod]
        public void CreateRobotTest(
            [PexAssumeUnderTest]global::World target,
            global::Robot protoRobot,
            global::Tile tile,
            float charge
        )
        {
            target.CreateRobot(protoRobot, tile, charge);
            // TODO: add assertions to method WorldTest.CreateRobotTest(World, Robot, Tile, Single)
        }

        /// <summary>Test stub for DemolishBuilding(Tile)</summary>
        [PexMethod]
        public void DemolishBuildingTest([PexAssumeUnderTest]global::World target, global::Tile tile)
        {
            target.DemolishBuilding(tile);
            // TODO: add assertions to method WorldTest.DemolishBuildingTest(World, Tile)
        }

        /// <summary>Test stub for DestroyEnemy(Enemy)</summary>
        [PexMethod]
        public void DestroyEnemyTest([PexAssumeUnderTest]global::World target, global::Enemy enemy)
        {
            target.DestroyEnemy(enemy);
            // TODO: add assertions to method WorldTest.DestroyEnemyTest(World, Enemy)
        }

        /// <summary>Test stub for DestroyProjectile(Projectile)</summary>
        [PexMethod]
        public void DestroyProjectileTest([PexAssumeUnderTest]global::World target, global::Projectile projectile)
        {
            target.DestroyProjectile(projectile);
            // TODO: add assertions to method WorldTest.DestroyProjectileTest(World, Projectile)
        }

        /// <summary>Test stub for GetSchema()</summary>
        [PexMethod]
        public XmlSchema GetSchemaTest([PexAssumeUnderTest]global::World target)
        {
            XmlSchema result = target.GetSchema();
            return result;
            // TODO: add assertions to method WorldTest.GetSchemaTest(World)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]global::World target)
        {
            target.OnChange();
            // TODO: add assertions to method WorldTest.OnChangeTest(World)
        }

        /// <summary>Test stub for ReadXml(XmlReader)</summary>
        [PexMethod]
        public void ReadXmlTest([PexAssumeUnderTest]global::World target, XmlReader reader)
        {
            target.ReadXml(reader);
            // TODO: add assertions to method WorldTest.ReadXmlTest(World, XmlReader)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]global::World target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method WorldTest.UpdateTest(World, Single)
        }

        /// <summary>Test stub for WriteXml(XmlWriter)</summary>
        [PexMethod]
        public void WriteXmlTest([PexAssumeUnderTest]global::World target, XmlWriter writer)
        {
            target.WriteXml(writer);
            // TODO: add assertions to method WorldTest.WriteXmlTest(World, XmlWriter)
        }

        /// <summary>Test stub for get_HeadQuarters()</summary>
        [PexMethod]
        public global::Building HeadQuartersGetTest([PexAssumeUnderTest]global::World target)
        {
            global::Building result = target.HeadQuarters;
            return result;
            // TODO: add assertions to method WorldTest.HeadQuartersGetTest(World)
        }

        /// <summary>Test stub for get_Item(Int32, Int32)</summary>
        [PexMethod]
        public global::Tile ItemGetTest(
            [PexAssumeUnderTest]global::World target,
            int x,
            int y
        )
        {
            global::Tile result = target[x, y];
            return result;
            // TODO: add assertions to method WorldTest.ItemGetTest(World, Int32, Int32)
        }
    }
}
