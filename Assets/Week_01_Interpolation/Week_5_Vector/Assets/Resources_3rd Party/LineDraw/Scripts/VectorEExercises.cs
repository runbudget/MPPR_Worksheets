using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorEExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float maxX = 5f;
    public float maxY = 5f;

    public LineFactory LineFactory;
    
    // 
    // Start is called before the first frame update
    void Start()
    {
        Question2a();
        Question2b(20);
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("magnitude =" +  vec2.magnitude);
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));
            endPt = new Vector2(
            Random.Range(-maxX, maxX),
            Random.Range(-maxY, maxY));   // ← insert for me

            drawnLine = LineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
     }
        // Update is called once per frame
        void Update()
        {

        }
    }
