using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Tile</summary>
    [PexClass(typeof(global::Tile))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class TileTest
    {
        /// <summary>Test stub for CanBuildHere()</summary>
        [PexMethod]
        public bool CanBuildHereTest([PexAssumeUnderTest]global::Tile target)
        {
            bool result = target.CanBuildHere();
            return result;
            // TODO: add assertions to method TileTest.CanBuildHereTest(Tile)
        }

        /// <summary>Test stub for .ctor(Int32, Int32)</summary>
        [PexMethod]
        public global::Tile ConstructorTest(int x, int y)
        {
            global::Tile target = new global::Tile(x, y);
            return target;
            // TODO: add assertions to method TileTest.ConstructorTest(Int32, Int32)
        }

        /// <summary>Test stub for get_Down()</summary>
        [PexMethod]
        public global::Tile DownGetTest([PexAssumeUnderTest]global::Tile target)
        {
            global::Tile result = target.Down;
            return result;
            // TODO: add assertions to method TileTest.DownGetTest(Tile)
        }

        /// <summary>Test stub for get_Empty()</summary>
        [PexMethod]
        public bool EmptyGetTest([PexAssumeUnderTest]global::Tile target)
        {
            bool result = target.Empty;
            return result;
            // TODO: add assertions to method TileTest.EmptyGetTest(Tile)
        }

        /// <summary>Test stub for get_Enterable()</summary>
        [PexMethod]
        public bool EnterableGetTest([PexAssumeUnderTest]global::Tile target)
        {
            bool result = target.Enterable;
            return result;
            // TODO: add assertions to method TileTest.EnterableGetTest(Tile)
        }

        /// <summary>Test stub for get_HasBuilding()</summary>
        [PexMethod]
        public bool HasBuildingGetTest([PexAssumeUnderTest]global::Tile target)
        {
            bool result = target.HasBuilding;
            return result;
            // TODO: add assertions to method TileTest.HasBuildingGetTest(Tile)
        }

        /// <summary>Test stub for HasBuildingWithType(String)</summary>
        [PexMethod]
        public bool HasBuildingWithTypeTest([PexAssumeUnderTest]global::Tile target, string type)
        {
            bool result = target.HasBuildingWithType(type);
            return result;
            // TODO: add assertions to method TileTest.HasBuildingWithTypeTest(Tile, String)
        }

        /// <summary>Test stub for IsNeighbor(Tile)</summary>
        [PexMethod]
        public bool IsNeighborTest([PexAssumeUnderTest]global::Tile target, global::Tile other)
        {
            bool result = target.IsNeighbor(other);
            return result;
            // TODO: add assertions to method TileTest.IsNeighborTest(Tile, Tile)
        }

        /// <summary>Test stub for get_Left()</summary>
        [PexMethod]
        public global::Tile LeftGetTest([PexAssumeUnderTest]global::Tile target)
        {
            global::Tile result = target.Left;
            return result;
            // TODO: add assertions to method TileTest.LeftGetTest(Tile)
        }

        /// <summary>Test stub for get_MovementCost()</summary>
        [PexMethod]
        public float MovementCostGetTest([PexAssumeUnderTest]global::Tile target)
        {
            float result = target.MovementCost;
            return result;
            // TODO: add assertions to method TileTest.MovementCostGetTest(Tile)
        }

        /// <summary>Test stub for get_Neighbors()</summary>
        [PexMethod]
        public List<global::Tile> NeighborsGetTest([PexAssumeUnderTest]global::Tile target)
        {
            List<global::Tile> result = target.Neighbors;
            return result;
            // TODO: add assertions to method TileTest.NeighborsGetTest(Tile)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]global::Tile target)
        {
            target.OnChange();
            // TODO: add assertions to method TileTest.OnChangeTest(Tile)
        }

        /// <summary>Test stub for get_Right()</summary>
        [PexMethod]
        public global::Tile RightGetTest([PexAssumeUnderTest]global::Tile target)
        {
            global::Tile result = target.Right;
            return result;
            // TODO: add assertions to method TileTest.RightGetTest(Tile)
        }

        /// <summary>Test stub for TilesInRange(Int32)</summary>
        [PexMethod]
        public IEnumerable<global::Tile> TilesInRangeTest([PexAssumeUnderTest]global::Tile target, int range)
        {
            IEnumerable<global::Tile> result = target.TilesInRange(range);
            return result;
            // TODO: add assertions to method TileTest.TilesInRangeTest(Tile, Int32)
        }

        /// <summary>Test stub for get_Up()</summary>
        [PexMethod]
        public global::Tile UpGetTest([PexAssumeUnderTest]global::Tile target)
        {
            global::Tile result = target.Up;
            return result;
            // TODO: add assertions to method TileTest.UpGetTest(Tile)
        }
    }
}
