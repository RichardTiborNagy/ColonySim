namespace ColonySim
{
    using System;
    using System.ComponentModel;

    public class Job : IPrototypable, IDisplayable
    {
        public string Type { get; private set; }

        public string RobotType { get; private set; }

        public Tile Tile { get; set; }

        public float TimeToComplete { get; private set; }

        public float AmountDone { get; set; }

        public float Timeout { get; set; }

        public int Cost { get; set; }

        public Robot Robot { get; set; }

        public void Work(float deltaTime)
        {
            AmountDone += deltaTime;
            if (IsComplete)
            {
                OnComplete?.Invoke(this);
            }

            OnChange();
        }

        public float Progress => AmountDone / TimeToComplete;

        public bool IsComplete => AmountDone >= TimeToComplete;

        private Action<Job> OnComplete { get; set; }

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
            CanCreate = other.CanCreate;
            RobotType = other.RobotType;
            TimeToComplete = other.TimeToComplete;
            Type = other.Type;
            OnComplete = other.OnComplete;
            Cost = other.Cost;
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

    public int X => Tile?.X ?? -1;
    public int Y => Tile?.Y ?? -1;
        public event Action Changed;

        public void OnChange()
        {
            Changed?.Invoke();
        }
    }
}