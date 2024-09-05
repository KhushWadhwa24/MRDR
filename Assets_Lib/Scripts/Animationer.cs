using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationer : MonoBehaviour
{
   void Update()
   {
    if(Disable.isshooting == false)
    {
        GetComponent<Animator>().enabled = false;
    }
    else
    {
        GetComponent<Animator>().enabled = true;
    }
   }
}
