using System;
using ColonySim;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for Projectile</summary>
    [TestClass]
    [PexClass(typeof(Projectile))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ProjectileTest
    {

        /// <summary>Test stub for .ctor(String, Int32, Action`1&lt;Projectile&gt;)</summary>
        [PexMethod]
        public Projectile ConstructorTest(
            string type,
            int speed,
            Action<Projectile> onHit
        )
        {
            Projectile target = new Projectile(type, speed, onHit);
            return target;
            // TODO: add assertions to method ProjectileTest.ConstructorTest(String, Int32, Action`1<Projectile>)
        }

        /// <summary>Test stub for .ctor(Projectile)</summary>
        [PexMethod]
        public Projectile ConstructorTest01(Projectile other)
        {
            Projectile target = new Projectile(other);
            return target;
            // TODO: add assertions to method ProjectileTest.ConstructorTest01(Projectile)
        }

        /// <summary>Test stub for OnChange()</summary>
        [PexMethod]
        public void OnChangeTest([PexAssumeUnderTest]Projectile target)
        {
            target.OnChange();
            // TODO: add assertions to method ProjectileTest.OnChangeTest(Projectile)
        }

        /// <summary>Test stub for SetPosition(Int32, Int32)</summary>
        [PexMethod]
        public void SetPositionTest(
            [PexAssumeUnderTest]Projectile target,
            int x,
            int y
        )
        {
            target.SetPosition(x, y);
            // TODO: add assertions to method ProjectileTest.SetPositionTest(Projectile, Int32, Int32)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]Projectile target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method ProjectileTest.UpdateTest(Projectile, Single)
        }

        /// <summary>Test stub for get_X()</summary>
        [PexMethod]
        public int XGetTest([PexAssumeUnderTest]Projectile target)
        {
            int result = target.X;
            return result;
            // TODO: add assertions to method ProjectileTest.XGetTest(Projectile)
        }

        /// <summary>Test stub for get_Y()</summary>
        [PexMethod]
        public int YGetTest([PexAssumeUnderTest]Projectile target)
        {
            int result = target.Y;
            return result;
            // TODO: add assertions to method ProjectileTest.YGetTest(Projectile)
        }
    }
}
