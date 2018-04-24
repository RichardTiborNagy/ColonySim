using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Enemy</summary>
    [TestClass]
    [PexClass(typeof(global::Enemy))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EnemyTest
    {

        /// <summary>Test stub for .ctor(String, Int32, Int32)</summary>
        [PexMethod]
        public global::Enemy ConstructorTest(
            string type,
            int speed,
            int maxHealth
        )
        {
            global::Enemy target = new global::Enemy(type, speed, maxHealth);
            return target;
            // TODO: add assertions to method EnemyTest.ConstructorTest(String, Int32, Int32)
        }

        /// <summary>Test stub for .ctor(Enemy)</summary>
        [PexMethod]
        public global::Enemy ConstructorTest01(global::Enemy other)
        {
            global::Enemy target = new global::Enemy(other);
            return target;
            // TODO: add assertions to method EnemyTest.ConstructorTest01(Enemy)
        }

        /// <summary>Test stub for Clone(Enemy)</summary>
        [PexMethod]
        public global::Enemy CloneTest([PexAssumeUnderTest]global::Enemy target, global::Enemy other)
        {
            global::Enemy result = target.Clone(other);
            return result;
            // TODO: add assertions to method EnemyTest.CloneTest(Enemy, Enemy)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]global::Enemy target)
        {
            target.OnChange();
            // TODO: add assertions to method EnemyTest.OnChangeTest(Enemy)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]global::Enemy target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method EnemyTest.UpdateTest(Enemy, Single)
        }

        /// <summary>Test stub for get_X()</summary>
        [PexMethod]
        public int XGetTest([PexAssumeUnderTest]global::Enemy target)
        {
            int result = target.X;
            return result;
            // TODO: add assertions to method EnemyTest.XGetTest(Enemy)
        }

        /// <summary>Test stub for get_Y()</summary>
        [PexMethod]
        public int YGetTest([PexAssumeUnderTest]global::Enemy target)
        {
            int result = target.Y;
            return result;
            // TODO: add assertions to method EnemyTest.YGetTest(Enemy)
        }
    }
}
