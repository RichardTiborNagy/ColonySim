using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;
using ColonySim;
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace ColonySim.Tests
{
    public partial class ProjectileTest
    {

[TestMethod]
[PexGeneratedBy(typeof(ProjectileTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void UpdateTestThrowsNullReferenceException476()
{
    Projectile projectile;
    projectile = new Projectile((Projectile)null);
    projectile.Position = default(Vector2);
    projectile.Target = (Enemy)null;
    this.UpdateTest(projectile, (float)0);
}
    }
}
