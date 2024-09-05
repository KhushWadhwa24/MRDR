using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera Cam;
    public static float score = 0f;
    public Vector3 off;
    void shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position + off,Cam.transform.forward , out hit))
        {

            if (hit.transform.CompareTag("fish"))
            {
                Destroy(hit.collider.gameObject);

                switch (hit.transform.name)
                {
                    case "Koi_Animated (1)(Clone)":
                        score += 1;
                        break;
                    case "Koi_Animated(Clone)":
                        score += 1;
                        break;
                    case "Koi_Animated (2)(Clone)":
                        score += 1;
                        break;
                }
            }
           
        }
    }
}
