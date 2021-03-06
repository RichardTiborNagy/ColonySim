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
    public partial class PriorityQueueTTest
    {

[TestMethod]
[PexGeneratedBy(typeof(PriorityQueueTTest))]
[PexRaisedException(typeof(NullReferenceException))]
public void CountGetTestThrowsNullReferenceException532()
{
    PriorityQueue<int> priorityQueue;
    int i;
    priorityQueue = new PriorityQueue<int>(int.MinValue);
    i = this.CountGetTest<int>(priorityQueue);
}

[TestMethod]
[PexGeneratedBy(typeof(PriorityQueueTTest))]
public void CountGetTest19()
{
    PriorityQueue<int> priorityQueue;
    int i;
    priorityQueue = new PriorityQueue<int>(1);
    i = this.CountGetTest<int>(priorityQueue);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)priorityQueue);
}
    }
}
