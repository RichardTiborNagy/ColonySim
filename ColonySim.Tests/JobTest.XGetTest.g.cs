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
    public partial class JobTest
    {

[TestMethod]
[PexGeneratedBy(typeof(JobTest))]
public void XGetTest410()
{
    Job job;
    int i;
    job = new Job((string)null, (Action<Job>)null, (float)0, 
                  (string)null, (Func<Tile, bool>)null, 0);
    job.Robot = (Robot)null;
    job.Tile = (Tile)null;
    i = this.XGetTest(job);
    Assert.AreEqual<int>(-1, i);
    Assert.IsNotNull((object)job);
    Assert.IsNull((object)(job.CanCreate));
    Assert.AreEqual<float>((float)0, job.AmountDone);
    Assert.AreEqual<int>(0, job.Cost);
    Assert.IsNull(job.Robot);
    Assert.AreEqual<string>((string)null, job.RobotType);
    Assert.IsNull(job.Tile);
    Assert.AreEqual<float>((float)0, job.Timeout);
    Assert.AreEqual<float>((float)0, job.TimeToComplete);
    Assert.AreEqual<string>((string)null, job.Type);
}

[TestMethod]
[PexGeneratedBy(typeof(JobTest))]
public void XGetTest205()
{
    Tile tile;
    Job job;
    int i;
    tile = new Tile(0, 0);
    tile.Building = (Building)null;
    job = new Job((string)null, (Action<Job>)null, (float)0, 
                  (string)null, (Func<Tile, bool>)null, 0);
    job.Robot = (Robot)null;
    job.Tile = tile;
    i = this.XGetTest(job);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)job);
    Assert.IsNull((object)(job.CanCreate));
    Assert.AreEqual<float>((float)0, job.AmountDone);
    Assert.AreEqual<int>(0, job.Cost);
    Assert.IsNull(job.Robot);
    Assert.AreEqual<string>((string)null, job.RobotType);
    Assert.IsNotNull(job.Tile);
    Assert.IsNull(job.Tile.Building);
    Assert.AreEqual<int>(0, job.Tile.X);
    Assert.AreEqual<int>(0, job.Tile.Y);
    Assert.AreEqual<float>((float)0, job.Timeout);
    Assert.AreEqual<float>((float)0, job.TimeToComplete);
    Assert.AreEqual<string>((string)null, job.Type);
}
    }
}
