using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : IDisplayable
{
    private Tile _tile;

    private int _height;
    private int _width;

    public string Type { get; }

    public readonly int MovementCost;
    
    public event Action Changed;
    public void OnChange()
    {
        Changed?.Invoke();
    }

    //todo constructor for prototype creation
    //todo copy constructor for prototype cloning
}
