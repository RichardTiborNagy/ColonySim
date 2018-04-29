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
    public partial class BuildingTest
    {

[TestMethod]
[PexGeneratedBy(typeof(BuildingTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void YGetTestThrowsNullReferenceException128()
{
    Building building;
    int i;
    building = new Building((Building)null);
    building.Tile = (Tile)null;
    i = this.YGetTest(building);
}

[TestMethod]
[PexGeneratedBy(typeof(BuildingTest))]
public void YGetTest281()
{
    Tile tile;
    Building building;
    int i;
    tile = new Tile(0, 0);
    tile.Building = (Building)null;
    building = new Building((Building)null);
    building.Tile = tile;
    i = this.YGetTest(building);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)building);
    Assert.AreEqual<bool>(false, building.Conjoined);
    Assert.AreEqual<float>((float)0, building.MovementModifier);
    Assert.AreEqual<int>(0, building.Size);
    Assert.IsNotNull(building.Tile);
    Assert.IsNull(building.Tile.Building);
    Assert.AreEqual<int>(0, building.Tile.X);
    Assert.AreEqual<int>(0, building.Tile.Y);
    Assert.AreEqual<string>((string)null, building.Type);
    Assert.IsNull((object)(building.UpdateInterval));
}
    }
}
