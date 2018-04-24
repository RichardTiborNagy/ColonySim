using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Edge</summary>
    [TestClass]
    [PexClass(typeof(global::Edge))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EdgeTest
    {

        /// <summary>Test stub for .ctor(Node, Single)</summary>
        [PexMethod]
        public global::Edge ConstructorTest(global::Node node, float movementCost)
        {
            global::Edge target = new global::Edge(node, movementCost);
            return target;
            // TODO: add assertions to method EdgeTest.ConstructorTest(Node, Single)
        }
    }
}
