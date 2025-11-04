using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticBezier : MonoBehaviour
{
    public GameObject p0; //start point
    public GameObject p1; //mid point
    public GameObject p2; //end point
    public LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
       
    }


    //Method to calculate and draw the quadratic bezier curve
    private void DrawBezierCurve()
    {
        //number of points on the curve for smoothness
        int curveResolution = 50;
        lineRenderer.positionCount = curveResolution;

        //loop through each point on the curve 
        for (int i = 0; i < curveResolution; i++)
        { //parameter t varies from 0 to 1
            float t = i / (float)(curveResolution - 1);
            Vector3 curvePoint = CalculateBezierPoint(t,
                        p0.transform.position,
                        p1.transform.position,
                        p2.transform.position);
            lineRenderer.SetPosition(i, curvePoint);
        }

    }

    //Method to calculate a point on the quaratic Bezier curve
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t; // u = (1-t)
        float tt = t * t; // t squared
        float uu = u * u; // (1-t) squared

        Vector3 point = uu * p0;
        point += 2 * u * t * p1;
        point += tt * p2;

        return point;

    }

    private void Update()
    {
        DrawBezierCurve();
    }

}