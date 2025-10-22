using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public float duration = 2.0f;

    private float elapsedTime = 0.0f;
    private Vector3 positionA;
    private Vector3 positionB;
    // Start is called before the first frame update
    void Start()
    {
        positionA = pointA.position;
        positionB = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            t = Mathf.Clamp01(t);

            // explicit linear interpolation
            Vector3 interpolatedPosition = (1 - t) * positionA + t * positionB;

            //update the movingobject position
            transform.position = interpolatedPosition;

        }
        else
        {
            //ensure the object reaches the exact position of pointB
            transform.position = positionB;
        }
    }

    private void OnDrawGizmos()
    {
        //draw pointa and point b
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pointA.position, 0.2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(pointB.position, 0.2f);

        //draw line between point a and point b 
        Gizmos.color = Color.gray;
        Gizmos.DrawLine(pointA.position, pointB.position);

        //draw interpolation steps
        Gizmos.color = Color.green;
        int steps = 20;
        for (int i = 0; i <= steps; i++)
        {
            float t = i / (float)steps;
            Vector3 interpolatedPosition = (1 - t) * positionA + t * positionB;
            Gizmos.DrawSphere(interpolatedPosition, 0.1f);
        }
    }
}
