using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDrawerDefaults : MonoBehaviour
{
    OrbitPathDrawer drawer;
    // Start is called before the first frame update
    void Start()
    {
        drawer.displayOrbits = true;
        drawer.updateOrbits = false;
    }
}
