using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Robot</summary>
    [TestClass]
    [PexClass(typeof(global::Robot))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RobotTest
    {

        /// <summary>Test stub for .ctor(String, Int32, Int32)</summary>
        [PexMethod]
        public global::Robot ConstructorTest(
            string type,
            int speed,
            int cost
        )
        {
            global::Robot target = new global::Robot(type, speed, cost);
            return target;
            // TODO: add assertions to method RobotTest.ConstructorTest(String, Int32, Int32)
        }

        /// <summary>Test stub for .ctor(Robot)</summary>
        [PexMethod]
        public global::Robot ConstructorTest01(global::Robot other)
        {
            global::Robot target = new global::Robot(other);
            return target;
            // TODO: add assertions to method RobotTest.ConstructorTest01(Robot)
        }

        /// <summary>Test stub for Clone(Robot)</summary>
        [PexMethod]
        public global::Robot CloneTest([PexAssumeUnderTest]global::Robot target, global::Robot other)
        {
            global::Robot result = target.Clone(other);
            return result;
            // TODO: add assertions to method RobotTest.CloneTest(Robot, Robot)
        }

        /// <summary>Test stub for GiveUpJob()</summary>
        [PexMethod]
        public void GiveUpJobTest([PexAssumeUnderTest]global::Robot target)
        {
            target.GiveUpJob();
            // TODO: add assertions to method RobotTest.GiveUpJobTest(Robot)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]global::Robot target)
        {
            target.OnChange();
            // TODO: add assertions to method RobotTest.OnChangeTest(Robot)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]global::Robot target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method RobotTest.UpdateTest(Robot, Single)
        }

        /// <summary>Test stub for get_X()</summary>
        [PexMethod]
        public int XGetTest([PexAssumeUnderTest]global::Robot target)
        {
            int result = target.X;
            return result;
            // TODO: add assertions to method RobotTest.XGetTest(Robot)
        }

        /// <summary>Test stub for get_Y()</summary>
        [PexMethod]
        public int YGetTest([PexAssumeUnderTest]global::Robot target)
        {
            int result = target.Y;
            return result;
            // TODO: add assertions to method RobotTest.YGetTest(Robot)
        }
    }
}
