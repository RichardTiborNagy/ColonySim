using System.Collections.Generic;

namespace ColonySim
{
    public class PrototypeManager<T> where T : IPrototypable
    {
        private readonly Dictionary<string, T> _prototypes;

        public PrototypeManager()
        {
            _prototypes = new Dictionary<string, T>();
        }

        public void Add(T proto)
        {
            if (proto == null || proto.Type == null) return;
            _prototypes?.Add(proto.Type, proto);
        }

        public T Get(string type)
        {
            if (type == null || _prototypes == null || !_prototypes.ContainsKey(type)) return default(T);
            return _prototypes[type];
        }
    }
}