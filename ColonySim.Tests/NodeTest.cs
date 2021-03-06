using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Node</summary>
    [TestClass]
    [PexClass(typeof(Node))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class NodeTest
    {

        /// <summary>Test stub for .ctor(Tile)</summary>
        [PexMethod]
        public Node ConstructorTest(Tile tile)
        {
            Node target = new Node(tile);
            return target;
            // TODO: add assertions to method NodeTest.ConstructorTest(Tile)
        }
    }
}
