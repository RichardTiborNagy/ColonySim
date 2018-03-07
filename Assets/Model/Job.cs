using System;
using System.ComponentModel;

public class Job
{
    public string Type { get; private set; }

    public Tile Tile { get; set; }

    private Action<Job> OnComplete { get; set; }

    public Job(string type, Action<Job> onComplete)
    {
        Type = type;
        OnComplete = onComplete;
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