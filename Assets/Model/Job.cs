using System;

namespace ColonySim
{
    public class Job : IPrototypable, IDisplayable
    {
        public readonly Func<Tile, bool> CanCreate;

        public Job(string type, Action<Job> onComplete, float timeToComplete, string robotType,
            Func<Tile, bool> canCreate,
            int cost)
        {
            Type = type;
            OnComplete = onComplete;
            TimeToComplete = timeToComplete;
            RobotType = robotType;
            CanCreate = canCreate;
            AmountDone = 0f;
            Timeout = 0f;
            Cost = cost;
        }

        public Job(Job other)
        {
            if (other == null) return;
            CanCreate = other.CanCreate;
            RobotType = other.RobotType;
            TimeToComplete = other.TimeToComplete;
            Type = other.Type;
            OnComplete = other.OnComplete;
            Cost = other.Cost;
        }

        public event Action Changed;

        public float AmountDone { get; set; }

        public int Cost { get; set; }

        public bool IsComplete => AmountDone >= TimeToComplete;

        public float Progress => AmountDone / TimeToComplete;

        public Robot Robot { get; set; }

        public string RobotType { get; }

        public Tile Tile { get; set; }

        public float Timeout { get; set; }

        public float TimeToComplete { get; }
        public string Type { get; }

        public int X => Tile?.X ?? -1;
        public int Y => Tile?.Y ?? -1;

        private Action<Job> OnComplete { get; }

        public void OnChange()
        {
            Changed?.Invoke();
        }

        public void Work(float deltaTime)
        {
            AmountDone += deltaTime;
            if (IsComplete) OnComplete?.Invoke(this);

            OnChange();
        }
    }
}