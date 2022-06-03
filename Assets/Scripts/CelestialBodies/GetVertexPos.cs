using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class GetVertexPos : MonoBehaviour
{
    public Transform vert;
    public Vector3 GlobalPos;

    void Awake()
    {
    }

    void Update()
    {
        vert = GetComponent<Transform>();        
        GlobalPos = vert.position;
        print("global pos: " + GlobalPos);
    }
}
