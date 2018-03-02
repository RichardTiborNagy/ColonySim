using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class TileView : View<Tile>
{
    private new void Awake()
    {
        base.Awake();
        for (int i = 0; i < 8; i++)
        {
            Sprites.Add(SpriteLoader.GetSprite("Tile_" + i));
        }
    }

    protected override void Refresh()
    {
        gameObject.transform.position = new Vector3(Target.X, Target.Y, 0);
        
        SpriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Count)];

        //switch (Target.Type)
        //{
        //    case TileType.Ground:
        //        break;
        //    case TileType.Water:
        //        break;
        //    case TileType.Road:
        //        break;
        //    default:
        //        throw new ArgumentOutOfRangeException();
        //}
    }
    
}
