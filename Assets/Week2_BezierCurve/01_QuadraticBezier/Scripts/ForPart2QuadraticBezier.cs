using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForPart2QuadraticBezier : MonoBehaviour
{
    public GameObject p0; //start point
    public GameObject p1; //mid point
    public GameObject p2; //end point
    public GameObject p3;
    public GameObject p4;
    public LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    //method to automatically adjust the control points for C1 continuity
    private void EnsureC1Continuity()
    {
        //calculate the vector frm p2 to p1 
        Vector3 direction1 = p2.transform.position - p1.transform.position;

        //Set p3 to be aligned along the same direction from p2
        p3.transform.position = p2.transform.position + direction1;
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
            Vector3 curvePoint = CalculateQuadraticBezierPoint(t,
                        p0.transform.position,
                        p1.transform.position,
                        p2.transform.position);
            lineRenderer.SetPosition(i, curvePoint);
        }

    }

    //Method to calculate a point on the quaratic Bezier curve
    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        return (u * u * p1) + (2 * u * t * p2) + (t * t * p3);

    }

    private void DrawCompositeQuadraticBezierCurve()
    {
        int segmentResolution = 50; //line renderer points per segment

        //2 segments, but reuse the shared point
        lineRenderer.positionCount = 2 * segmentResolution - 1;

        //draw the first segment ( p0-p2)
        for (int i = 0; i < segmentResolution;i++)
        {
            float t = i / (float) (segmentResolution - 1);
            Vector3 curvePoint = CalculateQuadraticBezierPoint(t,
                               p0.transform.position,
                               p1.transform.position,
                               p2.transform.position);
            lineRenderer.SetPosition(i, curvePoint);
        }

        //draw the second segment (p3p4) reusing p2 as start point
        for (int i = 0;i < segmentResolution;i++)
        {
            float t = i / (float)(segmentResolution - 1);
            Vector3 curvePoint = CalculateQuadraticBezierPoint(t,
                               p2.transform.position,
                               p3.transform.position,
                               p4.transform.position);
            //continue from where the first segment ended
            lineRenderer.SetPosition(i + segmentResolution - 1, curvePoint);
        }

    }

    private void Update()
    {
        DrawCompositeQuadraticBezierCurve();
        EnsureC1Continuity();
    }

}
