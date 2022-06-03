using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class OrbitPathDrawer : MonoBehaviour
{
    int bodyCount = 0;    
    float timeStep = Universe.TimeStep;
    public float simTime = 10f;
    public int steps;

    public bool displayOrbits = false;
    bool isFirstUpdate = false;
    public bool updateOrbits = true;

    GravityObject[] bodies;
    Vector3[][] points;
    List<LineRenderer> lrs;
    VirtualObj[] VirtualObjects;

    void Start()
    {
        displayOrbits = true;
        updateOrbits = false;
        isFirstUpdate = true;
    }
    // Update is called once per frame
    void Update()
    {
        bodies = FindObjectsOfType<GravityObject>();
        bodyCount = bodies.Length;

        // Instantitate each line renderer in lrs list
        lrs = new List<LineRenderer>();
        foreach (var body in bodies)
        {
            lrs.Add(body.gameObject.GetComponent<LineRenderer>());
        }

        steps = (int)(simTime / timeStep);

        if (updateOrbits)
        {
            GeneratePaths(bodies);
        }
        else updateOrbits = false;
            
        if (displayOrbits)
        {
            DisplayPaths(bodies);
        }
        else
        {
            displayOrbits = false;
            HidePaths();
        }

        isFirstUpdate = false;
    }


    Vector3[] ComputeNextPoints(VirtualObj[] objects, float timeStep)
    {
        // Declaring new array that will hold next position of each body
        Vector3[] nextPoints = new Vector3[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 acceleration = Vector3.zero;
            for (int j = 0; j < objects.Length; j++)
            {
                if (i == j) continue;
                // Sum up acceleration towards every object
                acceleration += computeAcceleration(objects[i], objects[j]);
            }            
            // Update velocity
            objects[i].velocity += acceleration * timeStep;

            // Calculate next position for virtual body i
            nextPoints[i] = objects[i].position + objects[i].velocity * timeStep;
            // Update virtual body position
            objects[i].position = nextPoints[i];
        }

        return nextPoints;
    }

    Vector3 computeAcceleration(VirtualObj body, VirtualObj otherBody)
    {
        // Squared distance between gravity objects
        float sqrDist = (body.position - otherBody.position).sqrMagnitude;
        // Unit vector of acceleration
        Vector3 accDir = (otherBody.position - body.position).normalized;
        // Update acceleration vector of body
        return (Universe.GravitationalConstant * otherBody.mass / sqrDist) * accDir;
    }

    void DisplayPaths(GravityObject[] bodies)
    {        
        //print("DisplayPaths() executed");
        if (isFirstUpdate)
        {
            GeneratePaths(bodies);
        }
        for (int i = 0; i < bodyCount; i++)
        {
            //print("Entered display loop");
            lrs[i].enabled = true;
            lrs[i].positionCount = points[i].Length;
            lrs[i].SetPositions(points[i]);
            lrs[i].startColor = Color.red;
            lrs[i].endColor = Color.blue;
            lrs[i].widthMultiplier = 0.1f;
        }
    }
    void HidePaths()
    {  
        //print("HidePaths() executed");      
        for (int i = 0; i < bodyCount; i++)
        {
            //print("hide lrs element");
            lrs[i].enabled = false;
        }
    }
    
    void GeneratePaths(GravityObject[] bodies)
    {
        VirtualObjects = new VirtualObj[bodyCount];
        points = new Vector3[bodyCount][];
        print("body count: " + bodyCount);

        // Initialising each point array element
        for (int i = 0; i < bodyCount; i++)
        {
            points[i] = new Vector3[steps];
        }
        bool[] hasCollided = new bool[bodyCount];

        // Initialising virtual objects
        for (int i = 0; i < bodyCount; i++)
        {
            VirtualObjects[i] = new VirtualObj(bodies[i]);
            points[i][0] = (VirtualObjects[i].position);
        }        

        // Generating points for steps number of steps
        for (int step = 0; step < steps-1; step++)
        {
            Vector3[] nextPoints = ComputeNextPoints(VirtualObjects, timeStep);
            for (int k = 0; k < bodyCount; k++)
            {
                points[k][step+1] = nextPoints[k];
            }
        }        
    }

    public void ToggleDisplayOrbit()
    {
        displayOrbits = !displayOrbits;
    }
    public void ToggleUpdateOrbit()
    {
        updateOrbits = !updateOrbits;
    }

    public void SetSimTime(float time)
    {
        simTime = time;
    }

    class VirtualObj
    {
        public Vector3 position;
        public Vector3 velocity;
        public float mass;
        public float radius;

        public VirtualObj (GravityObject body)
        {
            position = body.transform.position;
            velocity = body.initVelocity;
            mass = body.mass;
            radius = body.radius;
        }
    }

    public class CelestialCollision
    {
        public int[] colliderIndices = new int[2];
        public int step;
    }
}
