using System.Collections.Generic;
using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Tile</summary>
    [TestClass]
    [PexClass(typeof(Tile))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TileTest
    {

        /// <summary>Test stub for .ctor(Int32, Int32)</summary>
        [PexMethod]
        public Tile ConstructorTest(int x, int y)
        {
            Tile target = new Tile(x, y);
            return target;
            // TODO: add assertions to method TileTest.ConstructorTest(Int32, Int32)
        }

        /// <summary>Test stub for CanBuildHere()</summary>
        [PexMethod]
        public bool CanBuildHereTest([PexAssumeUnderTest]Tile target)
        {
            bool result = target.CanBuildHere();
            return result;
            // TODO: add assertions to method TileTest.CanBuildHereTest(Tile)
        }

        /// <summary>Test stub for HasBuildingWithType(String)</summary>
        [PexMethod]
        public bool HasBuildingWithTypeTest([PexAssumeUnderTest]Tile target, string type)
        {
            bool result = target.HasBuildingWithType(type);
            return result;
            // TODO: add assertions to method TileTest.HasBuildingWithTypeTest(Tile, String)
        }

        /// <summary>Test stub for IsNeighbor(Tile)</summary>
        [PexMethod]
        public bool IsNeighborTest([PexAssumeUnderTest]Tile target, Tile other)
        {
            bool result = target.IsNeighbor(other);
            return result;
            // TODO: add assertions to method TileTest.IsNeighborTest(Tile, Tile)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]Tile target)
        {
            target.OnChange();
            // TODO: add assertions to method TileTest.OnChangeTest(Tile)
        }

        /// <summary>Test stub for TilesInRange(Int32)</summary>
        [PexMethod]
        public IEnumerable<Tile> TilesInRangeTest([PexAssumeUnderTest]Tile target, int range)
        {
            IEnumerable<Tile> result = target.TilesInRange(range);
            return result;
            // TODO: add assertions to method TileTest.TilesInRangeTest(Tile, Int32)
        }

        /// <summary>Test stub for get_Down()</summary>
        [PexMethod]
        public Tile DownGetTest([PexAssumeUnderTest]Tile target)
        {
            Tile result = target.Down;
            return result;
            // TODO: add assertions to method TileTest.DownGetTest(Tile)
        }

        /// <summary>Test stub for get_Empty()</summary>
        [PexMethod]
        public bool EmptyGetTest([PexAssumeUnderTest]Tile target)
        {
            bool result = target.Empty;
            return result;
            // TODO: add assertions to method TileTest.EmptyGetTest(Tile)
        }

        /// <summary>Test stub for get_Enterable()</summary>
        [PexMethod]
        public bool EnterableGetTest([PexAssumeUnderTest]Tile target)
        {
            bool result = target.Enterable;
            return result;
            // TODO: add assertions to method TileTest.EnterableGetTest(Tile)
        }

        /// <summary>Test stub for get_HasBuilding()</summary>
        [PexMethod]
        public bool HasBuildingGetTest([PexAssumeUnderTest]Tile target)
        {
            bool result = target.HasBuilding;
            return result;
            // TODO: add assertions to method TileTest.HasBuildingGetTest(Tile)
        }

        /// <summary>Test stub for get_Left()</summary>
        [PexMethod]
        public Tile LeftGetTest([PexAssumeUnderTest]Tile target)
        {
            Tile result = target.Left;
            return result;
            // TODO: add assertions to method TileTest.LeftGetTest(Tile)
        }

        /// <summary>Test stub for get_MovementCost()</summary>
        [PexMethod]
        public float MovementCostGetTest([PexAssumeUnderTest]Tile target)
        {
            float result = target.MovementCost;
            return result;
            // TODO: add assertions to method TileTest.MovementCostGetTest(Tile)
        }

        /// <summary>Test stub for get_Neighbors()</summary>
        [PexMethod]
        public List<Tile> NeighborsGetTest([PexAssumeUnderTest]Tile target)
        {
            List<Tile> result = target.Neighbors;
            return result;
            // TODO: add assertions to method TileTest.NeighborsGetTest(Tile)
        }

        /// <summary>Test stub for get_Right()</summary>
        [PexMethod]
        public Tile RightGetTest([PexAssumeUnderTest]Tile target)
        {
            Tile result = target.Right;
            return result;
            // TODO: add assertions to method TileTest.RightGetTest(Tile)
        }

        /// <summary>Test stub for get_Up()</summary>
        [PexMethod]
        public Tile UpGetTest([PexAssumeUnderTest]Tile target)
        {
            Tile result = target.Up;
            return result;
            // TODO: add assertions to method TileTest.UpGetTest(Tile)
        }
    }
}
