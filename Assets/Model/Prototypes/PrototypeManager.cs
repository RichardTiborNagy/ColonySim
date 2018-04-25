namespace ColonySim
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PrototypeManager<T> where T : IPrototypable
    {
        private Dictionary<string, T> _prototypes;

        public T Get(string type)
        {
            return _prototypes[type];
        }

        public void Add(T proto)
        {
            _prototypes.Add(proto.Type, proto);
        }

        public PrototypeManager()
        {
            _prototypes = new Dictionary<string, T>();
        }
    }
}