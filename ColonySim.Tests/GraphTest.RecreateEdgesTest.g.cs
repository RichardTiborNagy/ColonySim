using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
    public partial class GraphTest
    {

[TestMethod]
[PexGeneratedBy(typeof(GraphTest))]
[Ignore]
[PexDescription("the test state was: path bounds exceeded")]
public void RecreateEdgesTest01()
{
    global::World world;
    global::Graph graph;
    world = new global::World(global::Difficulty.Easy, 0);
    world.Paused = false;
    world.Resources = 0;
    world.Health = 0;
    graph = new global::Graph(world);
    graph.Nodes = (Dictionary<global::Tile, global::Node>)null;
    this.RecreateEdgesTest(graph, (global::Tile)null);
}

[TestMethod]
[PexGeneratedBy(typeof(GraphTest))]
[Ignore]
[PexDescription("the test state was: path bounds exceeded")]
public void RecreateEdgesTest02()
{
    global::World world;
    global::Graph graph;
    world = new global::World(global::Difficulty.Easy, 15);
    world.Paused = false;
    world.Resources = 0;
    world.Health = 0;
    graph = new global::Graph(world);
    graph.Nodes = (Dictionary<global::Tile, global::Node>)null;
    this.RecreateEdgesTest(graph, (global::Tile)null);
}
    }
}
