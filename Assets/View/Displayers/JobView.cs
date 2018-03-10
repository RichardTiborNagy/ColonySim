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
        SpriteRenderer.sortingLayerName = "Building";
        ProgressSpriteRenderer = ProgressBar.GetComponent<SpriteRenderer>();
    }

    protected override void Refresh()
    {
        UpdatePosition();

        SpriteRenderer.sprite = SpriteManager.GetSprite("Blueprint");

        if (Target.Type.StartsWith("Build"))
        {
        }

        int progress = Mathf.Clamp(Mathf.RoundToInt(Target.Progress * numberOfProgressSprites), 0, numberOfProgressSprites-1);

        //Debug.Log(Target.Progress);
        //Debug.Log(progress);

        ProgressSpriteRenderer.sprite = SpriteManager.GetSprite("Progress_Green_" + progress);
    }
}
