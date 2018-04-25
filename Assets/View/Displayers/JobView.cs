using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobView : View<Job>
{
    public GameObject ProgressBar;

    private SpriteRenderer ProgressSpriteRenderer;

    private const int numberOfProgressSprites = 30;

    private new void Awake()
    {
        base.Awake();
        SpriteRenderer.sortingLayerName = "Job";
        ProgressSpriteRenderer = ProgressBar.GetComponent<SpriteRenderer>();
    }

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
        int progress = Mathf.Clamp(Mathf.RoundToInt(Target.Progress * numberOfProgressSprites), 0, numberOfProgressSprites-1);
        ProgressSpriteRenderer.sprite = SpriteManager.GetSprite("Progress_Green_" + progress);
    }
}
