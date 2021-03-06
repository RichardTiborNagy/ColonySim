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
public void EnqueueOrUpdateTestThrowsNullReferenceException284()
{
    PriorityQueue<int> priorityQueue;
    priorityQueue = new PriorityQueue<int>(int.MinValue);
    this.EnqueueOrUpdateTest<int>(priorityQueue, 0, (float)0);
}

[TestMethod]
[PexGeneratedBy(typeof(PriorityQueueTTest))]
public void EnqueueOrUpdateTest533()
{
    PriorityQueue<int> priorityQueue;
    priorityQueue = new PriorityQueue<int>(1);
    this.EnqueueOrUpdateTest<int>(priorityQueue, 0, (float)0);
    Assert.IsNotNull((object)priorityQueue);
}
    }
}
