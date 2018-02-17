using UnityEngine;

public abstract class View<T> : MonoBehaviour where T : IDisplayable
{
    protected SpriteRenderer SpriteRenderer { get; set; }

    protected T Target { get; set; }

    protected void Awake()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public abstract void Refresh();

    public virtual void ChangeTarget(T target)
    {
        if (Target != null)
            Target.Changed -= Refresh;
        Target = target;
        Target.Changed += Refresh;
        Refresh();
    }

}
