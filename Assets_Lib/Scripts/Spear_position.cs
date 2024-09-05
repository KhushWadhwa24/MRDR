using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_position : MonoBehaviour
{
    public Transform camera;
    public Vector3 offset;
    public Quaternion rotoffset;


    void Update()
    {
       transform.position = camera.position + offset; 
       transform.rotation = camera.rotation*rotoffset;
    }
}
