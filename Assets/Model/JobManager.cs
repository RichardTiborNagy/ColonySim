using System.Collections.Generic;
using System.Linq;

namespace ColonySim
{
    public class JobManager
    {
        private const float timeOutTime = 5f;

        private readonly List<TimeOut> timeOuts;

        private readonly World world;

        public JobManager()
        {
            AvailableJobs = new List<Job>();
            TakenJobs = new List<Job>();
            timeOuts = new List<TimeOut>();
            world = World.Current;
        }

        public IEnumerable<Job> Jobs => AvailableJobs.Concat(TakenJobs);

        private List<Job> AvailableJobs { get; }

        private List<Job> TakenJobs { get; }

        public void CancelJob(Tile tile)
        {
            var job = Jobs.FirstOrDefault(j => j.Tile == tile);
            if (job == null) return;
            world.Robots.ForEach(r => timeOuts.Add(new TimeOut(r, job, timeOutTime)));
            var robot = world.Robots.FirstOrDefault(r => r.Job == job);
            world.Resources += job.Cost;
            robot?.GiveUpJob();
            TakenJobs.Remove(job);
            AvailableJobs.Remove(job);
            world.OnChange();
        }

        public void CreateJob(Job protoJob, Tile tile, float amountDone = 0)
        {
            if (protoJob == null || tile == null || world.Resources < protoJob.Cost && amountDone == 0 ||
                Jobs.Any(j => tile == j.Tile) || !protoJob.CanCreate(tile)) return;
            if (amountDone == 0) world.Resources -= protoJob.Cost;
            var jobToCreate = new Job(protoJob) {Tile = tile, AmountDone = amountDone};
            AvailableJobs.Add(jobToCreate);
            world.OnChange();
        }

        public void GiveUpJob(Robot robot)
        {
            if (robot == null) return;
            var job = robot.Job;
            if (job == null) return;
            timeOuts.Add(new TimeOut(robot, job, timeOutTime));
            TakenJobs.Remove(job);
            AvailableJobs.Add(job);
        }

        public Job TakeJob(Robot robot)
        {
            var job = AvailableJobs.FirstOrDefault(j =>
                j.RobotType == robot.Type && !timeOuts.Any(t => t.robot == robot && t.job == j));
            if (job == null) return null;
            AvailableJobs.Remove(job);
            TakenJobs.Add(job);
            return job;
        }

        public void Update(float deltaTime)
        {
            timeOuts.ForEach(t => t.duration -= deltaTime);
            timeOuts.RemoveAll(t => t.duration < 0);
            if (TakenJobs.RemoveAll(job => job.IsComplete) > 0)
                world.OnChange();
        }

        private class TimeOut
        {
            public float duration;
            public readonly Job job;
            public readonly Robot robot;

            public TimeOut(Robot robot, Job job, float duration)
            {
                this.robot = robot;
                this.job = job;
                this.duration = duration;
            }
        }
    }
}