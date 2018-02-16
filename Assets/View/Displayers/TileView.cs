using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : Displayer
{
    private Tile _tile;

    public SpriteRenderer SpriteRenderer { get; }

    public IDisplayable Target => _tile;

    public override void Refresh()
    {
        switch (_tile.Type)
        {
            case TileType.Ground:
                break;
            case TileType.Water:
                break;
            case TileType.Road:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
}
