using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class RobotView : View<Robot>
{
    private new void Awake()
    {
        base.Awake();
        SpriteRenderer.sortingLayerName = "Entity";
    }

    protected override void Refresh()
    {
        UpdatePosition();
        SpriteRenderer.sprite = SpriteManager.GetSprite(Target.Type);
    }

    protected override void UpdatePosition()
    {
        gameObject.transform.position = Vector3.Lerp(new Vector3(Target.Tile.X, Target.Tile.Y, 0),
            new Vector3(Target.NextTile.X, Target.NextTile.Y, 0), Target.MovementProgress);
    }
}
