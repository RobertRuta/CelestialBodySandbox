using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    Transform cam;
    Vector3 rightward, upward;
    float pan_horizontal, pan_vertical;
    public float pan_speed;
    void Start()
    {
        cam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 panVelocity = cam.right * pan_horizontal + cam.up * pan_vertical;
        if (Input.GetMouseButton(2))
        {
            pan_horizontal = Input.GetAxis("Mouse X");
            pan_vertical = Input.GetAxis("Mouse Y");
            cam.Translate(-pan_horizontal * Time.deltaTime * pan_speed, -pan_vertical * Time.deltaTime * pan_speed, 0);
        }
    }
}
