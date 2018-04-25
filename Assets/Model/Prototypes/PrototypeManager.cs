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
            _prototypes.Add(proto.Type, proto);
        }

        public T Get(string type)
        {
            return _prototypes[type];
        }
    }
}