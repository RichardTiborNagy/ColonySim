//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PrototypeManager<T> where T : IPrototypable
//{
//    private static Dictionary<string, T> _prototypes;

//    public T Clone(string type)
//    {
//        return new T(_prototypes[type]);
//    }

//    static PrototypeManager()
//    {
//        _prototypes = new Dictionary<string, T>();
//        CreatePrototypes();
//    }

//    private static void CreatePrototypes()
//    {
//    }
//}
