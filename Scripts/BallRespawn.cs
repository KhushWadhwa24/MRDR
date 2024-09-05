using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public GameObject ballPrefab;  // Use the prefab instead of the specific ball instance
    public DragAndShoot dragNshoot;

    public GameObject newBall;
    //private bool isRespawning;

    void Start()
    {
        dragNshoot = ballPrefab.GetComponent<DragAndShoot>();

        if (!dragNshoot.ballExists)
        newBall = Instantiate(ballPrefab, transform.position, transform.rotation) as GameObject;

        dragNshoot = newBall.GetComponent<DragAndShoot>();


    }

    void Update()
    {

        if (dragNshoot.rb.isKinematic)
        {
            newBall.transform.parent = transform;
        }

        else
        {
            newBall.transform.parent = null;
        }
        
        if (dragNshoot != null && !dragNshoot.ballExists)
        {
            newBall = Instantiate(ballPrefab, transform.position, transform.rotation) as GameObject;
            dragNshoot = newBall.GetComponent<DragAndShoot>();
        }
        
    }

    //IEnumerator RespawnCoroutine()
    //{
    //    isRespawning = true;  // Set the flag to prevent multiple coroutines
    //    yield return new WaitForSeconds(1f);
    //    RespawnBall();
    //    isRespawning = false; // Reset the flag after respawning
    //}


    //void RespawnBall()
    //{
    //    GameObject newBall = Instantiate(ballPrefab, transform.position, transform.rotation);
    //    dragNshoot = newBall.GetComponent<DragAndShoot>();
    //}
}
