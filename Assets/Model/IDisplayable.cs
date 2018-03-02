using System;

public interface IDisplayable
{
    int X { get; }
    int Y { get; }

    event Action Changed;

    void OnChange();
}
