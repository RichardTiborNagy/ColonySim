using System;
using System.ComponentModel;

public class Job : IPrototypable
{
    public string Type { get; private set; }

    public string RobotType { get; private set; }

    public Tile Tile { get; set; }

    public float TimeToComplete { get; private set; }

    public float Progress { get; set; }

    public void Work(float deltaTime)
    {
        Progress += deltaTime;
        if (IsComplete)
        {
            OnComplete?.Invoke(this);
        }
    }

    public bool IsComplete => Progress >= TimeToComplete;

    private Action<Job> OnComplete { get; set; }

    public readonly Func<Tile, bool> CanCreate;

    public Job(string type, Action<Job> onComplete, float timeToComplete, string robotType, Func<Tile, bool> canCreate)
    {
        Type = type;
        OnComplete = onComplete;
        TimeToComplete = timeToComplete;
        RobotType = robotType;
        CanCreate = canCreate;
        Progress = 0f;
    }

    public Job(Job other)
    {
        CanCreate = other.CanCreate;
        RobotType = other.RobotType;
        TimeToComplete = other.TimeToComplete;
        Type = other.Type;
        OnComplete = other.OnComplete;
    }
}