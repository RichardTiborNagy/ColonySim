using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Building</summary>
    [TestClass]
    [PexClass(typeof(global::Building))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class BuildingTest
    {

        /// <summary>Test stub for .ctor(String, Int32, Single, Boolean, Nullable`1&lt;Single&gt;, Action`1&lt;Building&gt;)</summary>
        [PexMethod]
        public global::Building ConstructorTest(
            string type,
            int size,
            float movementModifier,
            bool conjoined,
            float? updateInterval,
            Action<global::Building> onUpdate
        )
        {
            global::Building target
               = new global::Building(type, size, movementModifier, conjoined, updateInterval, onUpdate);
            return target;
            // TODO: add assertions to method BuildingTest.ConstructorTest(String, Int32, Single, Boolean, Nullable`1<Single>, Action`1<Building>)
        }

        /// <summary>Test stub for .ctor(Building)</summary>
        [PexMethod]
        public global::Building ConstructorTest01(global::Building other)
        {
            global::Building target = new global::Building(other);
            return target;
            // TODO: add assertions to method BuildingTest.ConstructorTest01(Building)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]global::Building target)
        {
            target.OnChange();
            // TODO: add assertions to method BuildingTest.OnChangeTest(Building)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]global::Building target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method BuildingTest.UpdateTest(Building, Single)
        }

        /// <summary>Test stub for get_X()</summary>
        [PexMethod]
        public int XGetTest([PexAssumeUnderTest]global::Building target)
        {
            int result = target.X;
            return result;
            // TODO: add assertions to method BuildingTest.XGetTest(Building)
        }

        /// <summary>Test stub for get_Y()</summary>
        [PexMethod]
        public int YGetTest([PexAssumeUnderTest]global::Building target)
        {
            int result = target.Y;
            return result;
            // TODO: add assertions to method BuildingTest.YGetTest(Building)
        }
    }
}
