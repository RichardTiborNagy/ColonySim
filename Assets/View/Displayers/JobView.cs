using UnityEngine;

namespace ColonySim
{
    public class JobView : View<Job>
    {
        private const int numberOfProgressSprites = 30;
        public GameObject ProgressBar;

        private SpriteRenderer ProgressSpriteRenderer;

        protected override void Refresh()
        {
            Sprite sprite;
            UpdatePosition();
            switch (Target.Type)
            {
                case "Demolish":
                    sprite = SpriteManager.GetSprite("Demolish");
                    break;
                case "Gather":
                    sprite = SpriteManager.GetSprite("Gather");
                    break;
                default:
                    sprite = SpriteManager.GetSprite("Blueprint");
                    break;
            }

            SpriteRenderer.sprite = sprite;


            if (!(Target.Progress > 0)) return;
            var progress = Mathf.Clamp(Mathf.RoundToInt(Target.Progress * numberOfProgressSprites), 0,
                numberOfProgressSprites - 1);
            ProgressSpriteRenderer.sprite = SpriteManager.GetSprite("Progress_Green_" + progress);
        }

        private new void Awake()
        {
            base.Awake();
            SpriteRenderer.sortingLayerName = "Job";
            ProgressSpriteRenderer = ProgressBar.GetComponent<SpriteRenderer>();
        }
    }
}