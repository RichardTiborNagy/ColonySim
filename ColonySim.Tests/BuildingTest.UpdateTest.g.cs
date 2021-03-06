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
public void UpdateTest878()
{
    Building building;
    building = new Building((Building)null);
    building.Tile = (Tile)null;
    this.UpdateTest(building, (float)0);
    Assert.IsNotNull((object)building);
    Assert.AreEqual<bool>(false, building.Conjoined);
    Assert.AreEqual<float>((float)0, building.MovementModifier);
    Assert.AreEqual<int>(0, building.Size);
    Assert.IsNull(building.Tile);
    Assert.AreEqual<string>((string)null, building.Type);
    Assert.IsNull((object)(building.UpdateInterval));
}
    }
}
