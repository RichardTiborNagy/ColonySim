using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingView : View<Building>
{
    private new void Awake()
    {
        base.Awake();
        SpriteRenderer.sortingLayerName = "Building";
    }

    protected override void Refresh()
    {
        UpdatePosition();

        if (Target.Type == "Wall")
        {
            string spriteName = "Wall_";

            if (Target.Tile.Up != null && Target.Tile.Up.Building?.Type == "Wall")
                spriteName += 'U';
            if (Target.Tile.Right != null && Target.Tile.Right.Building?.Type == "Wall")
                spriteName += 'R';
            if (Target.Tile.Down != null && Target.Tile.Down.Building?.Type == "Wall")
                spriteName += 'D';
            if (Target.Tile.Left != null && Target.Tile.Left.Building?.Type == "Wall")
                spriteName += 'L';

            SpriteRenderer.sprite = SpriteManager.GetSprite(spriteName);

        }
        else if (Target.Type == "Road")
        {
            SpriteRenderer.sprite = SpriteManager.GetRandomRoadSprite();
        }
        else
        {
            SpriteRenderer.sprite = SpriteManager.GetSprite(Target.Type);
        }

    }
}
