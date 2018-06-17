﻿using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    public float panBorderThickness = 10f;

	void Update ()
    {

        if (GamesManager.GameOver)
        {
            enabled = false;
            return;
        }

		if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("z"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 200 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}