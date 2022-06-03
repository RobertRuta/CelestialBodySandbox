using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    GravityObject[] bodies;
    const float G = Universe.GravitationalConstant;
    
    void Start()
    {
        Time.fixedDeltaTime = Universe.TimeStep;
    }

    void FixedUpdate()
    {
        bodies = FindObjectsOfType<GravityObject>();
        ComputeMovements(bodies, Time.fixedDeltaTime);      
    }

    void ComputeMovements(GravityObject[] bodies, float timeStep)
    {
        foreach (GravityObject body in bodies)
        {
            Vector3 acceleration = Vector3.zero;
            foreach (GravityObject otherBody in bodies)
            {
                if (otherBody != body)
                {
                    acceleration += computeAcceleration(body, otherBody);
                }
            }
            // Update body velocity
            body.velocity += acceleration * timeStep;
            print("vel: " + body.velocity);
            // Move the body
            body.rb.position += body.velocity * timeStep;
        }
    }

    Vector3 computeAcceleration(GravityObject body, GravityObject otherBody)
    {
        // Squared distance between gravity objects
        float sqrDist = (body.rb.position - otherBody.rb.position).sqrMagnitude;
        // Unit vector of acceleration
        Vector3 accDir = (otherBody.rb.position - body.rb.position).normalized;
        // Update acceleration vector of body
        body.acceleration = (G * otherBody.mass / sqrDist) * accDir;

        // Visualising the acceleration vector
        Debug.DrawLine(body.rb.position, body.rb.position + body.acceleration, Color.red);        
        return body.acceleration;
    }
}
