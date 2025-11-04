using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInterpolation : MonoBehaviour
{
    public Vector3 startRotationEuler = new Vector3 (0, 0, 0);
    public Vector3 endRotationEuler = new Vector3(0, 180, 0);
    public float duration = 2f;

    private float elapsedTime = 0f;
    private Vector3 currentRotationEuler;
    void Start()
    {
        //set the initial rotation
        transform.rotation = Quaternion.Euler(startRotationEuler);
        currentRotationEuler = startRotationEuler; 
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            t = Mathf.Clamp01(t);

            //perform linear interpo
            currentRotationEuler.x = (1 - t) * startRotationEuler.x +
                t * startRotationEuler.x;
            currentRotationEuler.x = (1 - t) * startRotationEuler.x +
                t * startRotationEuler.y;
            currentRotationEuler.x = (1 - t) * startRotationEuler.x +
                t * startRotationEuler.z;

            //apply the interpolated rotation
            transform.rotation = Quaternion.Euler(currentRotationEuler);
        }
        else
        {
            //ensure the exact final rotation is applied
            transform.rotation = Quaternion.Euler(endRotationEuler);
        }
        
    }
}
