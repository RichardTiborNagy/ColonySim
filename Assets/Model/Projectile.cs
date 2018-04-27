using System;
using UnityEngine;

namespace ColonySim
{
    public class Projectile : IDisplayable, IPrototypable
    {
        public Projectile(string type, int speed, Action<Projectile> onHit)
        {
            Type = type;
            OnHit = onHit;
            Speed = speed;
        }

        public Projectile(Projectile other)
        {
            if (other == null) return;
            Type = other.Type;
            OnHit = other.OnHit;
            Speed = other.Speed;
        }

        public event Action Changed;

        public Vector2 Position { get; set; }

        public int Speed { get; }

        public Enemy Target { get; set; }
        public string Type { get; }

        public int X => (int) Position.x;
        public int Y => (int) Position.y;

        public void SetPosition(int x, int y)
        {
            Position = new Vector2(x, y);
        }

        private Action<Projectile> OnHit { get; }

        public void OnChange()
        {
            Changed?.Invoke();
        }

        public void Update(float deltaTime)
        {
            if (Target == null)
            {
                World.Current?.DestroyProjectile(this);
                return;
            }

            var dist = Mathf.Sqrt(Mathf.Pow(Target.Tile.X - Position.x, 2) + Mathf.Pow(Target.Tile.Y - Position.y, 2));
            if (dist <= 0.5f)
            {
                OnHit?.Invoke(this);
                World.Current.DestroyProjectile(this);
                return;
            }

            var traveledThisFrame = Speed * deltaTime;

            Position = Vector2.MoveTowards(Position, new Vector2(Target.X, Target.Y), traveledThisFrame);

            OnChange();
        }
    }
}