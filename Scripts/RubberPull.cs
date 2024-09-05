using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererExample : MonoBehaviour
{
    public LineRenderer lineRenderer;


    [SerializeField] private float offset = 0.85f;
    private Vector3 mouseDownPos;

    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Set the positions of the line renderer
        //SetLinePositions();
    }

    void SetLinePositions()
    {
        // Check if the LineRenderer component is assigned
        if (lineRenderer != null)
        {
            // Set the number of positions in the LineRenderer
            lineRenderer.positionCount = 3;
        }
        else
        {
            Debug.LogError("LineRenderer or points are not assigned!");
        }
    }

    void Update()
    {

        if (Input.touchCount > 0 && !Pausemenu.paused)
        {
            Touch touch = Input.GetTouch(0);
            mouseDownPos = touch.position;

            if(mouseDownPos.y * 0.001f - offset <= 0)
            lineRenderer.SetPosition(1, new Vector3(0, mouseDownPos.y*0.001f - offset, 0.45f));
                
        }
        else
        {
            
            lineRenderer.SetPosition(1, new Vector3(0, 0, 0.45f));
            
        }
    }

}
