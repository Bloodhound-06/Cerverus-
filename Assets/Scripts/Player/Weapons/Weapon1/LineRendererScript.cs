//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform aimPoint; //the position of where to fire
    public Transform firePosition; //the position of the gun

    public float distance;

    private void Start()
    {
        lineRenderer.enabled = true;
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePosition.position);
        lineRenderer.SetPosition(1, aimPoint.position);
    }
}