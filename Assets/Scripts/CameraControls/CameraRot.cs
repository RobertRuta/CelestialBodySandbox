using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    Transform cam;
    public float camRotV = 0, camRotH = 0;
    public float rot_speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Transform>();
        camRotV = cam.localRotation.eulerAngles.x;
        camRotH = cam.localRotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseH = Input.GetAxis("Mouse X");
            float mouseV = Input.GetAxis("Mouse Y");

            camRotH += mouseH * rot_speed;
            camRotV -= mouseV * rot_speed;
        }
        cam.localRotation = Quaternion.Euler(camRotV, camRotH, 0.0f);
    }
}
