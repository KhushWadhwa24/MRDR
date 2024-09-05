using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mouseDownPos;
    private Vector3 mouseReleasePos;

    private float delayTime = 2.0f; // Delay in seconds
    private float elapsedTime = 0.0f;

    public Rigidbody rb;

    public bool isShot = false;
    public bool ballExists = false;

    public float forceMultiplier = 1.7f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballExists = true;
        rb.isKinematic = true;
    }

    void Update() {
        
        if (isShot && !Pausemenu.paused)
        {
            StartCoroutine(waitForDestroy());
        }

        if (Input.touchCount > 0 && !Pausemenu.paused)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //beingDragged = true;
                mouseDownPos = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                //beingDragged = false;
                mouseReleasePos = touch.position;
                if (mouseDownPos.y - mouseReleasePos.y >= 0)
                {
                    Shoot(mouseDownPos - mouseReleasePos);
                }
            }
        }
    }

    void Shoot(Vector3 Force)
    {
        if (isShot) return;

        rb.isKinematic = false;
        //rb.AddForce(new Vector3(0, Force.y, Force.y) * forceMultiplier);

        rb.AddRelativeForce(new Vector3(0, Force.y, Force.y) * forceMultiplier);
        isShot = true;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            ballExists = false;
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= delayTime)
            {
                Destroy(gameObject, 0);
            }
        }
    }

    IEnumerator waitForDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        ballExists = false;
        yield return new WaitForSeconds(0.02f);
        Destroy(gameObject, 0);
    }
}

