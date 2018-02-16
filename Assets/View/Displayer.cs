using UnityEngine;

public abstract class Displayer : MonoBehaviour
{
    protected SpriteRenderer SpriteRenderer;

    protected IDisplayable Target;

    public abstract void Refresh();

}
