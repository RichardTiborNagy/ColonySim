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
public void ConstructorTest01284()
{
    Job job;
    job = this.ConstructorTest01((Job)null);
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
public void ConstructorTest01303()
{
    Job job;
    Job job1;
    job = new Job((string)null, (Action<Job>)null, (float)0, 
                  (string)null, (Func<Tile, bool>)null, 0);
    job.Robot = (Robot)null;
    job.Tile = (Tile)null;
    job1 = this.ConstructorTest01(job);
    Assert.IsNotNull((object)job1);
    Assert.IsNull((object)(job1.CanCreate));
    Assert.AreEqual<float>((float)0, job1.AmountDone);
    Assert.AreEqual<int>(0, job1.Cost);
    Assert.IsNull(job1.Robot);
    Assert.AreEqual<string>((string)null, job1.RobotType);
    Assert.IsNull(job1.Tile);
    Assert.AreEqual<float>((float)0, job1.Timeout);
    Assert.AreEqual<float>((float)0, job1.TimeToComplete);
    Assert.AreEqual<string>((string)null, job1.Type);
}
    }
}
