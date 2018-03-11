using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{ 
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(pos);
	        int x = Mathf.RoundToInt(pos.x);
	        int y = Mathf.RoundToInt(pos.y);
	        World.Current.CreateJob(Prototypes.Jobs.Get("BuildWall"), World.Current[x, y]);
	    }
    }
}
