namespace ColonySim
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Building : IDisplayable, IPrototypable
    {
        public int Size { get; }

        public string Type { get; }

        public Tile Tile { get; set; }

        public float MovementModifier { get; }

        public bool Conjoined { get; }

        public float? UpdateInterval { get; set; }

        public int X => Tile.X;
        public int Y => Tile.Y;

        private readonly Action<Building> OnUpdate;

        private float timer;

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

        public event Action Changed;

        public void OnChange()
        {
            Changed?.Invoke();
        }

    /// <summary>
    /// Copy constructor for cloning prototypes
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
        /// <summary>
        /// Used to create prototypes
        /// </summary>
        public Building(string type, int size, float movementModifier, bool conjoined = false,
            float? updateInterval = null, Action<Building> onUpdate = null)
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
        /// Copy constructor for cloning prototypes
        /// </summary>
        public Building(Building other)
        {
            Type = other.Type;
            Size = other.Size;
            MovementModifier = other.MovementModifier;
            Conjoined = other.Conjoined;
            UpdateInterval = other.UpdateInterval;
            timer = other.UpdateInterval ?? 0;
            OnUpdate = other.OnUpdate;
        }
    }
}