using System;

namespace ColonySim
{
    public interface IDisplayable
    {
        event Action Changed;
        int X { get; }
        int Y { get; }

        void OnChange();
    }
}