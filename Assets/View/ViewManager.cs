using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ViewManager
{
    private static readonly Dictionary<string, GameObject> Views;

    public static GameObject GetView(string viewName) => Views[viewName];

    static ViewManager()
    {
        Views = new Dictionary<string, GameObject>();
        var viewArray = Resources.LoadAll<GameObject>("");
        foreach (var view in viewArray)
        {
            Views.Add(view.name, view);
        }
    }
}
