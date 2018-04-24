using System.Collections.Generic;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColonySim.Tests
{
    /// <summary>This class contains parameterized unit tests for JobManager</summary>
    [TestClass]
    [PexClass(typeof(global::JobManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class JobManagerTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public global::JobManager ConstructorTest()
        {
            global::JobManager target = new global::JobManager();
            return target;
            // TODO: add assertions to method JobManagerTest.ConstructorTest()
        }

        /// <summary>Test stub for CancelJob(Tile)</summary>
        [PexMethod]
        public void CancelJobTest([PexAssumeUnderTest]global::JobManager target, global::Tile tile)
        {
            target.CancelJob(tile);
            // TODO: add assertions to method JobManagerTest.CancelJobTest(JobManager, Tile)
        }

        /// <summary>Test stub for CreateJob(Job, Tile, Single)</summary>
        [PexMethod]
        public void CreateJobTest(
            [PexAssumeUnderTest]global::JobManager target,
            global::Job protoJob,
            global::Tile tile,
            float amountDone
        )
        {
            target.CreateJob(protoJob, tile, amountDone);
            // TODO: add assertions to method JobManagerTest.CreateJobTest(JobManager, Job, Tile, Single)
        }

        /// <summary>Test stub for GiveUpJob(Robot)</summary>
        [PexMethod]
        public void GiveUpJobTest([PexAssumeUnderTest]global::JobManager target, global::Robot robot)
        {
            target.GiveUpJob(robot);
            // TODO: add assertions to method JobManagerTest.GiveUpJobTest(JobManager, Robot)
        }

        /// <summary>Test stub for TakeJob(Robot)</summary>
        [PexMethod]
        public global::Job TakeJobTest([PexAssumeUnderTest]global::JobManager target, global::Robot robot)
        {
            global::Job result = target.TakeJob(robot);
            return result;
            // TODO: add assertions to method JobManagerTest.TakeJobTest(JobManager, Robot)
        }

        /// <summary>Test stub for Update(Single)</summary>
        [PexMethod]
        public void UpdateTest([PexAssumeUnderTest]global::JobManager target, float deltaTime)
        {
            target.Update(deltaTime);
            // TODO: add assertions to method JobManagerTest.UpdateTest(JobManager, Single)
        }

        /// <summary>Test stub for get_Jobs()</summary>
        [PexMethod]
        public IEnumerable<global::Job> JobsGetTest([PexAssumeUnderTest]global::JobManager target)
        {
            IEnumerable<global::Job> result = target.Jobs;
            return result;
            // TODO: add assertions to method JobManagerTest.JobsGetTest(JobManager)
        }
    }
}
