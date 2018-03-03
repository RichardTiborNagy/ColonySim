using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float timer = 1f;
    
	// Use this for initialization
	void Start ()
	{
	    World.Current.Build(BuildingPrototypes.CloneBuilding("Wall"), World.Current[5, 5]);
	    World.Current.Build(BuildingPrototypes.CloneBuilding("Wall"), World.Current[5, 6]);
	    World.Current.Build(BuildingPrototypes.CloneBuilding("Wall"), World.Current[4, 5]);
	    World.Current.Build(BuildingPrototypes.CloneBuilding("Wall"), World.Current[6, 5]);
	    World.Current.Build(BuildingPrototypes.CloneBuilding("Wall"), World.Current[6, 6]);
	    World.Current.Build(BuildingPrototypes.CloneBuilding("Wall"), World.Current[6, 7]);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    timer -= Time.deltaTime;
	    if (timer < 0)
	    {
	        timer = 1f;
        }
	}
}
