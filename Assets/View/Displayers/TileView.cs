using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class TileView : View<Tile>
{
    //private new void Awake()
    //{
    //    base.Start();
    //}

    public override void Refresh()
    {
        gameObject.transform.position = new Vector3(Target.X, Target.Y, 0);

        List<Sprite> sprites = Resources.LoadAll<Sprite>("Tile/scifiTile_41").ToList();
        SpriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];

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
