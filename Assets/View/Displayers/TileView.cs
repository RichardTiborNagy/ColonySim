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

        SpriteRenderer.sortingLayerName = "Tile";
    }

    protected override void Refresh()
    {
        UpdatePosition();

        SpriteRenderer.sprite = SpriteManager.GetRandomTileSprite();
    }
    
}
