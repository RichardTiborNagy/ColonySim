using UnityEngine;

namespace ColonySim
{
    public class RobotView : View<Robot>
    {
        private const int numberOfChargeSprites = 30;
        public GameObject ChargeBar;

        private SpriteRenderer ChargeSpriteRenderer;

        protected override void Refresh()
        {
            UpdatePosition();
            SpriteRenderer.sprite = SpriteManager.GetSprite(Target.Type);

            var progress = Mathf.Clamp(Mathf.RoundToInt(Target.Charge / 100f * numberOfChargeSprites), 0,
                numberOfChargeSprites - 1);
            ChargeSpriteRenderer.sprite = SpriteManager.GetSprite("Charge_" + progress);
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
            ChargeSpriteRenderer = ChargeBar.GetComponent<SpriteRenderer>();
        }
    }
}