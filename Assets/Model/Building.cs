using System;

namespace ColonySim
{
    public class Building : IDisplayable, IPrototypable
    {
        private readonly Action<Building> OnUpdate;

        private float timer;

        /// <summary>
        ///     Used to create prototypes
        /// </summary>
        public Building(string type, int size, float movementModifier, bool conjoined = false,
            float? updateInterval = null,
            Action<Building> onUpdate = null)
        {
            Type = type;
            Size = size;
            MovementModifier = movementModifier;
            Conjoined = conjoined;
            UpdateInterval = updateInterval;
            timer = updateInterval ?? 0;
            OnUpdate = onUpdate;
        }

        /// <summary>
        ///     Copy constructor for cloning prototypes
        /// </summary>
        public Building(Building other)
        {
            if (other == null) return;
            Type = other.Type;
            Size = other.Size;
            MovementModifier = other.MovementModifier;
            Conjoined = other.Conjoined;
            UpdateInterval = other.UpdateInterval;
            timer = other.UpdateInterval ?? 0;
            OnUpdate = other.OnUpdate;
        }

        public event Action Changed;

        public bool Conjoined { get; }

        public float MovementModifier { get; }
        public int Size { get; }

        public Tile Tile { get; set; }

        public string Type { get; }

        public float? UpdateInterval { get; set; }

        public int X => Tile?.X ?? -1;
        public int Y => Tile?.Y ?? -1;

        public void OnChange()
        {
            Changed?.Invoke();
        }

        public void Update(float deltaTime)
        {
            if (UpdateInterval == null) return;
            timer -= deltaTime;
            if (timer <= 0)
            {
                timer = UpdateInterval ?? 0f;
                OnUpdate?.Invoke(this);
            }
        }
    }
}