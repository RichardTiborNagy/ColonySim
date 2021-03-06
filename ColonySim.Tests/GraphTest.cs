using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Graph</summary>
    [TestClass]
    [PexClass(typeof(Graph))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GraphTest
    {

        /// <summary>Test stub for .ctor(World)</summary>
        [PexMethod]
        public Graph ConstructorTest(World world)
        {
            Graph target = new Graph(world);
            return target;
            // TODO: add assertions to method GraphTest.ConstructorTest(World)
        }

        /// <summary>Test stub for RecreateEdges(Tile)</summary>
        [PexMethod]
        public void RecreateEdgesTest([PexAssumeUnderTest]Graph target, Tile tile)
        {
            target.RecreateEdges(tile);
            // TODO: add assertions to method GraphTest.RecreateEdgesTest(Graph, Tile)
        }
    }
}
