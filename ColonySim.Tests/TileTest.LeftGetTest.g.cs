using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework;
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
public void LeftGetTest365()
{
    global::Tile tile;
    global::Tile tile1;
    tile = new global::Tile(0, 0);
    tile.Building = (global::Building)null;
    tile1 = this.LeftGetTest(tile);
    PexAssert.IsNull((object)tile1);
    PexAssert.IsNotNull((object)tile);
    PexAssert.IsNull(tile.Building);
    PexAssert.AreEqual<int>(0, tile.X);
    PexAssert.AreEqual<int>(0, tile.Y);
}
    }
}
