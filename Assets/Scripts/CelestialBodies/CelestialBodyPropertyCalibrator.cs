using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CelestialBodyPropertyCalibrator : MonoBehaviour
{
    public float radius = 1f;
    public float mass = 100f;
    public float density = 23.9f;

    private float old_radius, old_mass, old_density;

    // Update is called once per frame
    void Update()
    {
        if (density != old_density || mass != old_mass || radius != old_radius)
        {
            UpdateProperties();
        }
    }

    void UpdateProperties()
    {
        float volume = 4f/3f * Mathf.PI * radius * radius * radius;
        mass = density * volume;
    }
}
