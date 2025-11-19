using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorExercisess : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;
    // Start is called before the first frame update
    private void Start()
    {
        Question2a();
    }

    void Question2a()
    {
        startPt = new Vector2(0 , 0);
        endPt = new Vector2(2 , 3);

        drawnLine = lineFactory.GetLine(startPt, endPt,
                                     0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
