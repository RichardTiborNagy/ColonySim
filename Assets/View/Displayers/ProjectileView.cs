using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : View<Projectile>
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
        gameObject.transform.position = Target.Position;
    }
}
