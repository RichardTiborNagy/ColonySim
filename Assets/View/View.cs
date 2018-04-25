namespace ColonySim
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class View<T> : MonoBehaviour where T : IDisplayable
    {
        protected SpriteRenderer SpriteRenderer { get; set; }

        protected T Target { get; set; }

        //protected List<Sprite> Sprites { get; private set; }

        protected void Awake()
        {
            SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            //Sprites = new List<Sprite>();
        }

        protected abstract void Refresh();

        public virtual void SetTarget(T target)
        {
            if (Target != null)
                Target.Changed -= Refresh;
            Target = target;
            Target.Changed += Refresh;
            Refresh();
        }

        protected virtual void UpdatePosition()
        {
            gameObject.transform.position = new Vector3(Target.X, Target.Y, 0);
        }
    }
}