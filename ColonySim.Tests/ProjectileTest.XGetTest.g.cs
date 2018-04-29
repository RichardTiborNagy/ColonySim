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
public void XGetTest662()
{
    Projectile projectile;
    int i;
    projectile = new Projectile((Projectile)null);
    projectile.Position = default(Vector2);
    projectile.Target = (Enemy)null;
    i = this.XGetTest(projectile);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)projectile);
    Assert.AreEqual<float>((float)0, projectile.Position.x);
    Assert.AreEqual<float>((float)0, projectile.Position.y);
    Assert.AreEqual<float>((float)0, projectile.Position.sqrMagnitude);
    Assert.AreEqual<int>(0, projectile.Speed);
    Assert.IsNull(projectile.Target);
    Assert.AreEqual<string>((string)null, projectile.Type);
}
    }
}
