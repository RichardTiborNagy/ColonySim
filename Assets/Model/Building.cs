using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : IDisplayable
{
    private Tile _tile;

    public readonly int MovementCost;

    

    public event Action Changed;
    public void OnChange()
    {
        throw new NotImplementedException();
    }
}
