using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBody : MonoBehaviour
{
    public GameObject prefab;
    GameObject obj;

    public void CreatePrefab()
    {
        float random = Random.Range(-1.0f,1.0f);
        obj = (GameObject)Instantiate(prefab, new Vector3(random,random,random), Quaternion.Euler(0,0,0));
        string name = "planet" + Random.Range(10, 100);
        obj.name = name;
    }
    
}
