using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : IDisplayable, IPrototypable
{
    public int Size { get; }

    public string Type { get; }

    public Tile Tile { get; set; }

    public float MovementModifier { get; }

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
    public Building(string type, int size, int movementModifier, bool conjoined, Action<Building, float> onUpdate)
    {
        Type = type;
        Size = size;
        MovementModifier = movementModifier;
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
        Size = other.Size;
        MovementModifier = other.MovementModifier;
        Conjoined = other.Conjoined;
    }
}
