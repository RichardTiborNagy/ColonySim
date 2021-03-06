using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for PrototypeManager`1</summary>
    [TestClass]
    [PexClass(typeof(PrototypeManager<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PrototypeManagerTTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexGenericArguments(typeof(IPrototypable))]
        [PexMethod]
        public PrototypeManager<T> ConstructorTest<T>()
            where T : IPrototypable
        {
            PrototypeManager<T> target = new PrototypeManager<T>();
            return target;
            // TODO: add assertions to method PrototypeManagerTTest.ConstructorTest()
        }

        /// <summary>Test stub for Add(!0)</summary>
        [PexGenericArguments(typeof(IPrototypable))]
        [PexMethod]
        public void AddTest<T>([PexAssumeUnderTest]PrototypeManager<T> target, T proto)
            where T : IPrototypable
        {
            target.Add(proto);
            // TODO: add assertions to method PrototypeManagerTTest.AddTest(PrototypeManager`1<!!0>, !!0)
        }

        /// <summary>Test stub for Get(String)</summary>
        [PexGenericArguments(typeof(IPrototypable))]
        [PexMethod]
        public T GetTest<T>([PexAssumeUnderTest]PrototypeManager<T> target, string type)
            where T : IPrototypable
        {
            T result = target.Get(type);
            return result;
            // TODO: add assertions to method PrototypeManagerTTest.GetTest(PrototypeManager`1<!!0>, String)
        }
    }
}
