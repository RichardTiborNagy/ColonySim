namespace ColonySim
{
    public sealed class TileView : View<Tile>
    {
        protected override void Refresh()
        {
            UpdatePosition();

            SpriteRenderer.sprite = SpriteManager.GetRandomTileSprite();
        }

        private new void Awake()
        {
            base.Awake();

            SpriteRenderer.sortingLayerName = "Tile";
        }
    }
}