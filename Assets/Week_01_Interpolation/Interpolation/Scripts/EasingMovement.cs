using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingMovement : MonoBehaviour
{
    public enum EasingType { Linear, EaseIn, EaseOut, EaseInOut }
    public EasingType easingType = EasingType.Linear; //Default to linear

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

            // apply the selected easing function
            switch (easingType)
            {
                case EasingType.Linear:
                    break; //linear easing means t stays unchanged
                case EasingType.EaseIn:
                    //t = //put the actual formula find online(t);
                    break;
                case EasingType.EaseOut:
                    //t = EaseOutCubic(t);
                    break;
                case EasingType.EaseInOut:
                    //t = EaseInOutCubic(t);
                    break;
            }


            // non-linear interpolation 
            Vector3 interpolatedPosition = (1 - t) * positionA + t * positionB;
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

            // apply the ease-in function
            t = t * t;

            Vector3 interpolatedPosition = (1 - t) * positionA + t * positionB;

            Gizmos.DrawSphere(interpolatedPosition, 0.1f);
        }
    }
}
