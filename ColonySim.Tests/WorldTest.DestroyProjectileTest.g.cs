using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public partial class WorldTest
    {

[TestMethod]
[PexGeneratedBy(typeof(WorldTest))]
[PexDescription("the test state was: path bounds exceeded")]
public void DestroyProjectileTest01()
{
    World world;
    world = new World(Difficulty.Easy, 0);
    world.Health = 0;
    world.Paused = false;
    world.Resources = 0;
    this.DestroyProjectileTest(world, (Projectile)null);
}
    }
}
