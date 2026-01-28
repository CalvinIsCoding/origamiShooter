using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeForPlayer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject anchor;
    public GameObject player;
    public PlayerController playerController;
    Vector2[] linePoints = new Vector2[15];
    Gradient gradient = new Gradient();
    GradientColorKey[] colorKeys = new GradientColorKey[1];
    public Vector3 vectorBetweenPlayerAndAnchor;
    Color ropeColor = Color.blue;
    float lineSize;
  
    void Start()
    {
        colorKeys[0] = new GradientColorKey(ropeColor,1.0f);
        lineRenderer.positionCount = 2;
        CalculateColorGradient();
    }

    // Update is called once per frame
    void Update()
    {
        
        lineRenderer.SetPosition(0, anchor.transform.position);
        lineRenderer.SetPosition(1, player.transform.position);

        ropeColor = playerController.fanSprite.color;
        colorKeys[0].color = ropeColor;
        CalculateColorGradient();



        /*
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
        */
        lineSize = Mathf.Clamp(0.1f - vectorBetweenPlayerAndAnchor.magnitude * 0.05f,0.03f,0.1f);
        lineRenderer.startWidth = lineSize;
        lineRenderer.endWidth = lineSize;

        if (playerController.overHeating)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        vectorBetweenPlayerAndAnchor = anchor.transform.position - player.transform.position;

        if (vectorBetweenPlayerAndAnchor.magnitude > 0.2f)
        {
            playerController.rb.AddForce(vectorBetweenPlayerAndAnchor * (vectorBetweenPlayerAndAnchor.magnitude) * 4f);
        }
    }
    void CalculateColorGradient()
    {
        gradient.SetKeys(colorKeys,
         new GradientAlphaKey[] { new GradientAlphaKey(1.0F, 1.0f) }
     );

        lineRenderer.colorGradient = gradient;
    }

}
