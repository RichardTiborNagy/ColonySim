using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Robot : IDisplayable
{
    public RobotType Type { get; private set; }

    public Tile Tile { get; private set; }

    private Tile NexTile { get; set; }

    public float MovementProgress { get; private set; }

    public int Speed { get; private set; }

    public Job Job { get; private set; }

    public State State { get; private set; }

    public Robot(RobotType type, int speed)
    {
        Type = type;
        Speed = speed;
        MovementProgress = 0f;
    }
    
    #region IDisplayable interface implementation
    public int X => Tile.X;
    public int Y => Tile.Y;

    public event Action Changed;
    public void OnChange()
    {
        Changed?.Invoke();
    }
    #endregion
}
