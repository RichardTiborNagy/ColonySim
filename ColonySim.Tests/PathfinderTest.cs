using System.Collections.Generic;
using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Pathfinder</summary>
    [TestClass]
    [PexClass(typeof(Pathfinder))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PathfinderTest
    {

        /// <summary>Test stub for FindPath(Tile, Tile)</summary>
        [PexMethod]
        public Queue<Tile> FindPathTest(Tile starTile, Tile destinationTile)
        {
            Queue<Tile> result = Pathfinder.FindPath(starTile, destinationTile);
            return result;
            // TODO: add assertions to method PathfinderTest.FindPathTest(Tile, Tile)
        }
    }
}
