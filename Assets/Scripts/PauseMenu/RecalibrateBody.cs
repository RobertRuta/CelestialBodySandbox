using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecalibrateBody : MonoBehaviour
{
    GravityObject[] bodies;

    public bool isVelocityReset;


    public void ResetInitVelocityOnPause()
    {
        bodies = FindObjectsOfType<GravityObject>();
        for (int i = 0; i < bodies.Length; i++)
        {
            GravityObject body = bodies[i];
            body.initVelocity = body.velocity;
        }
        isVelocityReset = true;
        print("isVelocityReset: " + isVelocityReset);
    }
}
