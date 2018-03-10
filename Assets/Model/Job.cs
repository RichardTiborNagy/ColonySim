using System;
using System.ComponentModel;

public class Job : IPrototypable
{
    public string Type { get; private set; }

    public Tile Tile { get; set; }

    public float Progress { get; set; }

    private Action<Job> OnComplete { get; set; }

    public Job(string type, Action<Job> onComplete)
    {
        Type = type;
        OnComplete = onComplete;
        Progress = 0f;
    }

    public Job(Job other)
    {
        Type = other.Type;
        OnComplete = other.OnComplete;
    }

    public void Complete()
    {
        OnComplete?.Invoke(this);
    }
}