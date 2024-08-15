using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObstacleMovement : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 5f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + new Vector3(movement, 0, 0);

        // If you want vertical movement, use:
        // transform.position = startPosition + new Vector3(0, movement, 0);
    }
}


