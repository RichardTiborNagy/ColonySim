using System;
using System.ComponentModel;

public class Job : IPrototypable
{
    public string Type { get; private set; }

    public Tile Tile { get; set; }

    public float TimeToComplete { get; private set; }

    public float Progress { get; set; }

    public void Work(float deltaTime)
    {
        Progress += deltaTime;
    }

    public bool IsComplete => Progress >= TimeToComplete;

    private Action<Job> OnComplete { get; set; }

    public Job(string type, Action<Job> onComplete, float timeToComplete)
    {
        Type = type;
        OnComplete = onComplete;
        TimeToComplete = timeToComplete;
        Progress = 0f;
    }

    public Job(Job other)
    {
        TimeToComplete = other.TimeToComplete;
        Type = other.Type;
        OnComplete = other.OnComplete;
    }

    public void Complete()
    {
        OnComplete?.Invoke(this);
    }
}