using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public World World;

    public GameObject TilePrefab;

    private float timer = 1f;

    public GameObject Camera;

	// Use this for initialization
	void Start () {
		World = new World(100);
	    foreach (var tile in World.Tiles)
	    {
	        var tileView = Instantiate(TilePrefab).GetComponent<TileView>();
            tileView.ChangeTarget(tile);
        }

	    Camera.transform.position = new Vector3(50, 50, -10);

	    var c = World[0, 0].Neighbors;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer -= Time.deltaTime;
	    if (timer < 0)
	    {
	        timer = 1f;
	        foreach (var tile in World.Tiles)
	        {
	            //tile.OnChange();
	        }
        }
	}
}
