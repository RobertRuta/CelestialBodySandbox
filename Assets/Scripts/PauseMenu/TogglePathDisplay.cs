using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePathDisplay : MonoBehaviour
{
    OrbitPathDrawer drawer;
    public void ShowPathsToggle()
    {
        drawer.displayOrbits = !drawer.displayOrbits;
    }
}
