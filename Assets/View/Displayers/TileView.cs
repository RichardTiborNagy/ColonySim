using System;
using UnityEngine;

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
                Sprite sprite = Resources.Load<Sprite>("ground");
                SpriteRenderer.sprite = sprite;
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
