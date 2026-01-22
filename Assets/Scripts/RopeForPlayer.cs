using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeForPlayer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject anchor;
    public GameObject player;
    Vector2[] linePoints = new Vector2[15]; 
    void Start()
    {
        lineRenderer.positionCount = 15;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        lineRenderer.SetPosition(0, anchor.transform.position);
        lineRenderer.SetPosition(1, player.transform.position);
        */
        linePoints[0] = anchor.transform.position;
        linePoints[^1] = player.transform.position;

        for (int i = 1; i < linePoints.Length - 1; i++)
        {
            linePoints[i] = Vector2.Perpendicular(linePoints[^1] - linePoints[0]).normalized * Mathf.Sin(Time.time + i) * 0.002f;

        }
        for (int i = 0; i < linePoints.Length - 1; i++)
        {
            Vector2 dir = linePoints[i + 1] - linePoints[i];
            linePoints[i + 1] = linePoints[i] + dir.normalized * 1f;
        }


        for (int i = 0; i < linePoints.Length; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i]);
        }
    }

}
