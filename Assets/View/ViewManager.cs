using System.Collections.Generic;
using UnityEngine;

namespace ColonySim
{
    public static class ViewManager
    {
        private static readonly Dictionary<string, GameObject> Views;

        static ViewManager()
        {
            Views = new Dictionary<string, GameObject>();
            var viewArray = Resources.LoadAll<GameObject>("");
            foreach (var view in viewArray) Views.Add(view.name, view);
        }

        public static GameObject GetView(string viewName)
        {
            return Views[viewName];
        }
    }
}