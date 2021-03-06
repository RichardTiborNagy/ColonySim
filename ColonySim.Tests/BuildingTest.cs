using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Building</summary>
    [PexClass(typeof(Building))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BuildingTest
    {
        /// <summary>Test stub for .ctor(String, Int32, Single, Boolean, Nullable`1&lt;Single&gt;, Action`1&lt;Building&gt;)</summary>
        [PexMethod]
        public Building ConstructorTest(
            string type,
            int size,
            float movementModifier,
            bool conjoined,
            float? updateInterval,
            Action<Building> onUpdate
        )
        {
            Building target = new Building
                                  (type, size, movementModifier, conjoined, updateInterval, onUpdate);
            return target;
            // TODO: add assertions to method BuildingTest.ConstructorTest(String, Int32, Single, Boolean, Nullable`1<Single>, Action`1<Building>)
        }

        /// <summary>Test stub for .ctor(Building)</summary>
        [PexMethod]
        public Building ConstructorTest01(Building other)
        {
            Building target = new Building(other);
            return target;
            // TODO: add assertions to method BuildingTest.ConstructorTest01(Building)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]Building target)
        {
            target.OnChange();
            // TODO: add assertions to method BuildingTest.OnChangeTest(Building)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]Building target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method BuildingTest.UpdateTest(Building, Single)
        }

        /// <summary>Test stub for get_X()</summary>
        [PexMethod]
        public int XGetTest([PexAssumeUnderTest]Building target)
        {
            int result = target.X;
            return result;
            // TODO: add assertions to method BuildingTest.XGetTest(Building)
        }

        /// <summary>Test stub for get_Y()</summary>
        [PexMethod]
        public int YGetTest([PexAssumeUnderTest]Building target)
        {
            int result = target.Y;
            return result;
            // TODO: add assertions to method BuildingTest.YGetTest(Building)
        }
    }
}
