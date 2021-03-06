﻿using UnityEngine;

namespace ColonySim
{
    public class EnemyView : View<Enemy>
    {
        private const int numberOfHealthSprites = 30;
        public GameObject HealthBar;

        private SpriteRenderer HealthSpriteRenderer;

        protected override void Refresh()
        {
            UpdatePosition();
            SpriteRenderer.sprite = SpriteManager.GetSprite(Target.Type);

            var health =
                Mathf.Clamp(Mathf.RoundToInt(Target.Health / (float) Target.MaxHealth * numberOfHealthSprites), 0,
                    numberOfHealthSprites - 1);
            HealthSpriteRenderer.sprite = SpriteManager.GetSprite("Progress_Green_" + health);
        }

        protected override void UpdatePosition()
        {
            gameObject.transform.position = Vector3.Lerp(new Vector3(Target.Tile.X, Target.Tile.Y, 0),
                new Vector3(Target.NextTile.X, Target.NextTile.Y, 0), Target.MovementProgress);
        }

        private new void Awake()
        {
            base.Awake();
            SpriteRenderer.sortingLayerName = "Entity";
            HealthSpriteRenderer = HealthBar.GetComponent<SpriteRenderer>();
        }
    }
}