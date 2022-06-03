using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class GravityObject : Gravity
{
    // Gravity object will be moved using unity physics
    public Rigidbody rb;
    // Gravity object mesh
    Mesh mesh;
    // Properties defining a gravity object
    public float mass = 1f;
    public float radius = 1f;
    public float density = 1f;
    // Object movement variables - readonly
    public Vector3 acceleration, velocity, oldVelocity, position;
    // Initial movement conditions
    public Vector3 initVelocity;
    public bool realisticRadiusAndMass;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {        
        mesh = GetComponent<MeshFilter>().sharedMesh;
        velocity = initVelocity;
        rb.mass = mass * 1000;
    }

    void Update()
    {
        if (realisticRadiusAndMass == true)   
        {
            this.transform.localScale = Vector3.one*radius*2 ;
            mass = density * 4.0f/3.0f * Mathf.PI * Mathf.Pow(radius, 3);
        }
    }
}
