using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;
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
[Ignore]
[PexDescription("the test state was: path bounds exceeded")]
public void GetSchemaTest01()
{
    global::World world;
    XmlSchema xmlSchema;
    world = new global::World(global::Difficulty.Easy, 0);
    world.Paused = false;
    world.Resources = 0;
    world.Health = 0;
    xmlSchema = this.GetSchemaTest(world);
}

[TestMethod]
[PexGeneratedBy(typeof(WorldTest))]
[Ignore]
[PexDescription("the test state was: path bounds exceeded")]
public void GetSchemaTest02()
{
    global::World world;
    XmlSchema xmlSchema;
    world = new global::World(global::Difficulty.Easy, 15);
    world.Paused = false;
    world.Resources = 0;
    world.Health = 0;
    xmlSchema = this.GetSchemaTest(world);
}
    }
}
