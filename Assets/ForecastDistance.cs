using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ForecastDistance : MonoBehaviour
{
    public GameObject sim;
    public TMP_InputField inp;
    OrbitPathDrawer drawer;
    void Awake()
    {
        drawer = sim.GetComponent<OrbitPathDrawer>();    
    }

    public void OnForecastChange()
    {
        print(float.Parse(inp.text));
        drawer.simTime = float.Parse(inp.text);
    }
}
