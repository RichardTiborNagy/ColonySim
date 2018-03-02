using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : IDisplayable
{
    public int Height { get; }
    public int Width { get; }

    public string Type { get; }

    public Tile Tile { get; set; }

    public int MovementCost { get; }

    public int X => Tile.X;
    public int Y => Tile.Y;

    public event Action Changed;
    public void OnChange()
    {
        Changed?.Invoke();
    }

    /// <summary>
    /// Used to create prototypes
    /// </summary>
    public Building(string type, int height, int width, int movementCost)
    {
        Type = type;
        Height = height;
        Width = width;
        MovementCost = movementCost;
    }

    /// <summary>
    /// Copy constructor for cloning prototypes
    /// </summary>
    public Building(Building other)
    {
        Type = other.Type;
        Height = other.Height;
        Width = other.Width;
        MovementCost = other.MovementCost;
    }
}
