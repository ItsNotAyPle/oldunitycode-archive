using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.gamedeveloper.com/business/how-to-work-with-bezier-curve-in-games-with-unity

[RequireComponent(typeof(LineRenderer))]
public class Bezier : MonoBehaviour
{
    public Transform[] points;
    private LineRenderer _line_renderer;


    private int curve_count = 0;
    private int layer_order = 0;
    private const int SEGMENT_COUNT = 50;

    void Start()
    {
        _line_renderer = GetComponent<LineRenderer>();
        _line_renderer.sortingLayerID = layer_order;
        curve_count = (int) points.Length / 3;
    }

    void Update()
    {
        DrawCurve();
    }

    void DrawCurve()
    {
        for (int j = 0; j < curve_count; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 3;
                Vector3 pixel = CalculateCubicBezierPoint(t, points[nodeIndex].position, points[nodeIndex + 1].position, points[nodeIndex + 2].position, points[nodeIndex + 3].position);
                _line_renderer.positionCount = (j * SEGMENT_COUNT) + i;
                _line_renderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel);
            }

        }
    }

    // B(t) = (1-t) [(1-t)2P0 + 2(1-t)tP1 + t2P2] + t [(1-t)2P1 + 2(1-t)tP2 + t2P3]   , 0 < t < 1
    public static Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }
}
