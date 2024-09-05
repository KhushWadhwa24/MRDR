using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishmovement : MonoBehaviour
{
   public Rigidbody rb;
   void Update()
   {
     rb.velocity = new Vector3(3f, 0f, 0f);
   }
}
