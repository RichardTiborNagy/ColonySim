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
    public partial class TileTest
    {

[TestMethod]
[PexGeneratedBy(typeof(TileTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void UpGetTestThrowsNullReferenceException226()
{
    Tile tile;
    Tile tile1;
    tile = new Tile(0, 0);
    tile.Building = (Building)null;
    tile1 = this.UpGetTest(tile);
}
    }
}
