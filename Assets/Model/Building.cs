using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : IDisplayable, IPrototypable
{
    public int Height { get; }
    public int Width { get; }

    public string Type { get; }

    public Tile Tile { get; set; }

    public int MovementCost { get; }

    public bool Conjoined { get; }

    public int X => Tile.X;
    public int Y => Tile.Y;

    private readonly Action<Building, float> OnUpdate;

    public void Update(float deltaTime)
    {
        OnUpdate?.Invoke(this, deltaTime);
    }

    public event Action Changed;
    public void OnChange()
    {
        Changed?.Invoke();
    }

    /// <summary>
    /// Used to create prototypes
    /// </summary>
    public Building(string type, int height, int width, int movementCost, bool conjoined, Action<Building, float> onUpdate)
    {
        Type = type;
        Height = height;
        Width = width;
        MovementCost = movementCost;
        Conjoined = conjoined;
        OnUpdate = onUpdate;
    }

    /// <summary>
    /// Copy constructor for cloning prototypes
    /// </summary>
    public Building(Building other)
    {
        OnUpdate = other.OnUpdate;
        Type = other.Type;
        Height = other.Height;
        Width = other.Width;
        MovementCost = other.MovementCost;
        Conjoined = other.Conjoined;
    }
}
