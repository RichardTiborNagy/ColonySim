using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Job</summary>
    [TestClass]
    [PexClass(typeof(global::Job))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class JobTest
    {

        /// <summary>Test stub for .ctor(String, Action`1&lt;Job&gt;, Single, String, Func`2&lt;Tile,Boolean&gt;, Int32)</summary>
        [PexMethod]
        public global::Job ConstructorTest(
            string type,
            Action<global::Job> onComplete,
            float timeToComplete,
            string robotType,
            Func<global::Tile, bool> canCreate,
            int cost
        )
        {
            global::Job target = new global::Job(type, onComplete, timeToComplete, robotType, canCreate, cost);
            return target;
            // TODO: add assertions to method JobTest.ConstructorTest(String, Action`1<Job>, Single, String, Func`2<Tile,Boolean>, Int32)
        }

        /// <summary>Test stub for .ctor(Job)</summary>
        [PexMethod]
        public global::Job ConstructorTest01(global::Job other)
        {
            global::Job target = new global::Job(other);
            return target;
            // TODO: add assertions to method JobTest.ConstructorTest01(Job)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]global::Job target)
        {
            target.OnChange();
            // TODO: add assertions to method JobTest.OnChangeTest(Job)
        }

        /// <summary>Test stub for Work(Single)</summary>
        [PexMethod]
        public void WorkTest([PexAssumeUnderTest]global::Job target, float deltaTime)
        {
            target.Work(deltaTime);
            // TODO: add assertions to method JobTest.WorkTest(Job, Single)
        }

        /// <summary>Test stub for get_IsComplete()</summary>
        [PexMethod]
        public bool IsCompleteGetTest([PexAssumeUnderTest]global::Job target)
        {
            bool result = target.IsComplete;
            return result;
            // TODO: add assertions to method JobTest.IsCompleteGetTest(Job)
        }

        /// <summary>Test stub for get_Progress()</summary>
        [PexMethod]
        public float ProgressGetTest([PexAssumeUnderTest]global::Job target)
        {
            float result = target.Progress;
            return result;
            // TODO: add assertions to method JobTest.ProgressGetTest(Job)
        }

        /// <summary>Test stub for get_X()</summary>
        [PexMethod]
        public int XGetTest([PexAssumeUnderTest]global::Job target)
        {
            int result = target.X;
            return result;
            // TODO: add assertions to method JobTest.XGetTest(Job)
        }

        /// <summary>Test stub for get_Y()</summary>
        [PexMethod]
        public int YGetTest([PexAssumeUnderTest]global::Job target)
        {
            int result = target.Y;
            return result;
            // TODO: add assertions to method JobTest.YGetTest(Job)
        }
    }
}
