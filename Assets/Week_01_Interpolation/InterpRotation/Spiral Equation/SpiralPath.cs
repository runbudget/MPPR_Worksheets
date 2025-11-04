using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralPath : MonoBehaviour
{
    //speed at which the obj moves
    public float speed = 1f;

    //duration for which the obj followes the path
    public float duration = 10f;

    private float t = 0f;
    private float timeElapsed = 0f;

    public float spiralGrowth = 1f;

    public float verticalSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        // if the obj has moved for less than the specified
        // duration, continue updating
        if (timeElapsed < duration)
        {
            t += speed * Time.deltaTime;

            //spiral equation
            float r = spiralGrowth * t;    // expanding radius
            float x = r * Mathf.Cos(t);    // circular motion
            float y = r * Mathf.Sin(t);    // circular motion
            float z = verticalSpeed * t;   // optional upward movement

            // Set the new position of the object
            transform.position = new Vector3(x, y, z);

            // Update elapsed time
            timeElapsed += Time.deltaTime;


        }
    }
}
