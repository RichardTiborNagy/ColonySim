using System;

public interface IDisplayable
{
    event Action Changed;

    void OnChange();
}
