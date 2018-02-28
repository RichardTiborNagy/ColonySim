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

        switch (Target.Type)
        {
            case TileType.Ground:
                List<Sprite> sprites = Resources.LoadAll<Sprite>("Tile/scifiTile_41").ToList();  //new List<Sprite>();
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_41"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_42"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_27"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_28"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_29"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_30"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_01"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_02"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_15"));
                //sprites.Add(Resources.Load<Sprite>("Tile/scifiTile_16"));

                SpriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
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
