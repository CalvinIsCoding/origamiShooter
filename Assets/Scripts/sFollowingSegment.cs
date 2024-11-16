using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sFollowingSegment : MonoBehaviour
{
    GameObject nextSegment;
    public Rigidbody2D nextSegmentRb;
    Rigidbody2D rb;
    Vector2 desiredPosition;
    Vector2 directionDesiredPosition;
    Vector2 force;
    public SpringJoint2D snakeConnector;
    public float springConstant;
    public float damping;
    void Start()
    {
        springConstant = Mathf.Pow(snakeConnector.frequency, rb.mass * 2);
        damping = snakeConnector.dampingRatio * 2 * Mathf.Sqrt(springConstant * rb.mass);
       
    }

    // Update is called once per frame
    void Update()
    {
        desiredPosition = nextSegmentRb.position;
        directionDesiredPosition = rb.position - desiredPosition;
        force = directionDesiredPosition * springConstant - rb.velocity * damping;
        rb.AddForce(force);
        //rb.rotation = Quaternion.LookRotation(rb.velocity);

    }
}
