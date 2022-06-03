using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform cam;
    float moveY, moveX, ascend, descend;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camVelocity;

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        ascend = Input.GetAxis("Jump");

        Vector3 forwardVelocity = cam.forward * moveY * speed;
        Vector3 strafeVelocity = cam.right * moveX * speed;
        Vector3 ascendVelocity = Vector3.up * ascend * speed;
        
        camVelocity = forwardVelocity + strafeVelocity + ascendVelocity;
        cam.position += camVelocity * Time.deltaTime;
    }
}
