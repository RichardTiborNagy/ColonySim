namespace ColonySim
{
    public class ProjectileView : View<Projectile>
    {
        protected override void Refresh()
        {
            UpdatePosition();
            SpriteRenderer.sprite = SpriteManager.GetSprite(Target.Type);
        }

        protected override void UpdatePosition()
        {
            gameObject.transform.position = Target.Position;
        }

        private new void Awake()
        {
            base.Awake();
            SpriteRenderer.sortingLayerName = "Entity";
        }
    }
}