using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PanningSpeed = 20f;
    public int PanningBorder = 10;
    public Vector2 PanningLimits = new Vector2(100f, 100f);

    private void Update ()
	{
	    var position = transform.position;

	    if (Input.mousePosition.x >= Screen.width - PanningBorder)
	        position.x += PanningSpeed * Time.deltaTime;
	    if (Input.mousePosition.x <= PanningBorder)
	        position.x -= PanningSpeed * Time.deltaTime;
        if (Input.mousePosition.y >= Screen.height - PanningBorder)
	        position.y += PanningSpeed * Time.deltaTime;
	    if (Input.mousePosition.y <= PanningBorder)
	        position.y -= PanningSpeed * Time.deltaTime;

	    position.x = Mathf.Clamp(position.x, 0f, PanningLimits.x);
	    position.y = Mathf.Clamp(position.y, 0f, PanningLimits.y);

        transform.position = position;
	}
}
