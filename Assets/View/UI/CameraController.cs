using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PanningSpeed = 20f;
    public int PanningBorder = 10;
    public Vector2 PanningLowerLimits = new Vector2(14f, 7f);
    public Vector2 PanningUpperLimits = new Vector2(35f, 43f);
    public Camera Camera;
    public float ZoomingSpeed = 200f;

    private void Start()
    {
        Camera = GetComponent<Camera>();
        transform.position = new Vector3(24, 24, -10);
    }

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

        position.x = Mathf.Clamp(position.x, PanningLowerLimits.x, PanningUpperLimits.x);
        position.y = Mathf.Clamp(position.y, PanningLowerLimits.y, PanningUpperLimits.y);

        Camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ZoomingSpeed * Time.deltaTime;
        Camera.orthographicSize = Mathf.Clamp(Camera.orthographicSize, 5f, 15f);

        transform.position = position;
    }
}
