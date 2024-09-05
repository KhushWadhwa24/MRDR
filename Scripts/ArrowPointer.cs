using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform oatAnchor; // The anchor point the arrow should point towards
    public Transform libAnchor;
    public Transform facbAnchor;
    public Vector3 planeUpDirection = Vector3.up; // The plane's "up" direction, typically Vector3.up

    private bool isOAT = false;
    private bool isLib = false;
    private bool isFacB = false;

    private void Update()
    {
        if (isOAT)
        {
            SetOATAnchor();
        }

        if (isLib)
        {
            SetLibAnchor();
        }

        if (isFacB)
        {
            SetFacBAnchor();
        }
    }

    public void OATRotation()
    {
        isOAT = true;
        isLib = false;
        isFacB = false; // Set the flag to true to start rotating in Update()
    }

    public void LibRotation()
    {
        isOAT = false;
        isLib = true;
        isFacB = false; // Set the flag to true to start rotating in Update()
    }

    public void FacBRotation()
    {
        isOAT = false;
        isLib = false;
        isFacB = true; // Set the flag to true to start rotating in Update()
    }

    public void SetOATAnchor()
    {
        if (oatAnchor != null)
        {
            // Calculate the direction from the plane to the anchor point
            Vector3 directionToAnchor = oatAnchor.position - transform.position;

            // Align the plane's forward direction with the direction to the anchor
            Quaternion targetRotation = Quaternion.LookRotation(directionToAnchor, planeUpDirection);

            // Apply a 180-degree rotation around the Y-axis to correct the inversion
            Quaternion correctionRotation = Quaternion.Euler(0, 180, 0);

            // Combine the target rotation with the correction rotation
            transform.rotation = targetRotation * correctionRotation;
        }
    }

    public void SetLibAnchor()
    {
        if (libAnchor != null)
        {
            // Calculate the direction from the plane to the anchor point
            Vector3 directionToAnchor = libAnchor.position - transform.position;

            // Align the plane's forward direction with the direction to the anchor
            Quaternion targetRotation = Quaternion.LookRotation(directionToAnchor, planeUpDirection);

            // Apply a 180-degree rotation around the Y-axis to correct the inversion
            Quaternion correctionRotation = Quaternion.Euler(0, 180, 0);

            // Combine the target rotation with the correction rotation
            transform.rotation = targetRotation * correctionRotation;
        }
    }

    public void SetFacBAnchor()
    {
        if (facbAnchor != null)
        {
            // Calculate the direction from the plane to the anchor point
            Vector3 directionToAnchor = facbAnchor.position - transform.position;

            // Align the plane's forward direction with the direction to the anchor
            Quaternion targetRotation = Quaternion.LookRotation(directionToAnchor, planeUpDirection);

            // Apply a 180-degree rotation around the Y-axis to correct the inversion
            Quaternion correctionRotation = Quaternion.Euler(0, 180, 0);

            // Combine the target rotation with the correction rotation
            transform.rotation = targetRotation * correctionRotation;
        }
    }
}