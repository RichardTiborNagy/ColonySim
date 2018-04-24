using System.Collections.Generic;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Pathfinder</summary>
    [TestClass]
    [PexClass(typeof(global::Pathfinder))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PathfinderTest
    {

        /// <summary>Test stub for FindPath(Tile, Tile)</summary>
        [PexMethod]
        public Queue<global::Tile> FindPathTest(global::Tile starTile, global::Tile destinationTile)
        {
            Queue<global::Tile> result = global::Pathfinder.FindPath(starTile, destinationTile);
            return result;
            // TODO: add assertions to method PathfinderTest.FindPathTest(Tile, Tile)
        }
    }
}
