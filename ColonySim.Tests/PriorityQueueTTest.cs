using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for PriorityQueue`1</summary>
    [TestClass]
    [PexClass(typeof(PriorityQueue<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PriorityQueueTTest
    {

        /// <summary>Test stub for .ctor(Int32)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public PriorityQueue<T> ConstructorTest<T>(int startingSize)
        {
            PriorityQueue<T> target = new PriorityQueue<T>(startingSize);
            return target;
            // TODO: add assertions to method PriorityQueueTTest.ConstructorTest(Int32)
        }

        /// <summary>Test stub for Contains(!0)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool ContainsTest<T>([PexAssumeUnderTest]PriorityQueue<T> target, T data)
        {
            bool result = target.Contains(data);
            return result;
            // TODO: add assertions to method PriorityQueueTTest.ContainsTest(PriorityQueue`1<!!0>, !!0)
        }

        /// <summary>Test stub for Dequeue()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T DequeueTest<T>([PexAssumeUnderTest]PriorityQueue<T> target)
        {
            T result = target.Dequeue();
            return result;
            // TODO: add assertions to method PriorityQueueTTest.DequeueTest(PriorityQueue`1<!!0>)
        }

        /// <summary>Test stub for Enqueue(!0, Single)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void EnqueueTest<T>(
            [PexAssumeUnderTest]PriorityQueue<T> target,
            T data,
            float priority
        )
        {
            target.Enqueue(data, priority);
            // TODO: add assertions to method PriorityQueueTTest.EnqueueTest(PriorityQueue`1<!!0>, !!0, Single)
        }

        /// <summary>Test stub for EnqueueOrUpdate(!0, Single)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void EnqueueOrUpdateTest<T>(
            [PexAssumeUnderTest]PriorityQueue<T> target,
            T data,
            float priority
        )
        {
            target.EnqueueOrUpdate(data, priority);
            // TODO: add assertions to method PriorityQueueTTest.EnqueueOrUpdateTest(PriorityQueue`1<!!0>, !!0, Single)
        }

        /// <summary>Test stub for UpdatePriority(!0, Single)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void UpdatePriorityTest<T>(
            [PexAssumeUnderTest]PriorityQueue<T> target,
            T data,
            float priority
        )
        {
            target.UpdatePriority(data, priority);
            // TODO: add assertions to method PriorityQueueTTest.UpdatePriorityTest(PriorityQueue`1<!!0>, !!0, Single)
        }

        /// <summary>Test stub for get_Count()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int CountGetTest<T>([PexAssumeUnderTest]PriorityQueue<T> target)
        {
            int result = target.Count;
            return result;
            // TODO: add assertions to method PriorityQueueTTest.CountGetTest(PriorityQueue`1<!!0>)
        }
    }
}
