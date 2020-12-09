using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour
{
    public GameObject gameHandler;
    private GraphScript graphScript;
    public GameObject hint;
    // Start is called before the first frame update
    void Start()
    {
        /*Vector2 p0 = new Vector2(0, 0);
        Vector2 p1 = new Vector2(75, 75);
        Vector2 p2= new Vector2(25, 75);
        Vector2 p3 = new Vector2(50, 50);
        Vector2? p = GetIntersection(p0, p1, p2, p3);
        if (p is Vector2 valueOfP)
        {
            Debug.Log(valueOfP.x.ToString() + " " + valueOfP.y.ToString());
        }
        else
        {
            Debug.Log("null");
        }*/
        graphScript = gameHandler.GetComponent<GraphScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        HashSet<(Vector2, Vector2)> lineSegmentSet = graphScript.lineSegments;
        List<(Vector2, Vector2)> lineSegments = lineSegmentSet.ToList();
        HashSet<Vector2> intersections = new HashSet<Vector2>();
        bool check = false;
        bool hasOrigin = false;
        foreach((Vector2 p1, Vector2 p2) lineSegment in lineSegments)
        {
            if (lineSegment.p1.x == 0f && lineSegment.p1.y == 0f)
            {
                hasOrigin = true;
                check = recurse(lineSegment, lineSegments, intersections);
                break;
            }
        }
        Debug.Log(check.ToString());
        
        if (!check)
        {
            if (lineSegments.Count == 0)
            {
                hint.GetComponent<Text>().text = "You must graph an equation";
                hint.SetActive(true);
            }
            else if (lineSegments.Count == 1)
            {
                hint.GetComponent<Text>().text = "Hint: you can use more than one equation to create a path";
                hint.SetActive(true);
            }
            else if (!hasOrigin)
            {
                hint.GetComponent<Text>().text = "Hint: your path should start from the origin (0,0)";
                hint.SetActive(true);
            }
            else
            {
                hint.GetComponent<Text>().text = "Hint: the slope changes the steepness of the line and the intercept changes the height";
                hint.SetActive(true);
            }
        }
        else
        {
            hint.GetComponent<Text>().text = "Good Job!";
            hint.SetActive(true);
        }
        //return check;
    }

    private bool recurse((Vector2 p1, Vector2 p2) current, List<(Vector2, Vector2)> lineSegments, HashSet<Vector2> intersections)
    {
        if (Reaches5050(current.p1, current.p2))
        {
            return true;
        }
        HashSet<Vector2> intersectionsCopy = new HashSet<Vector2>(intersections);
        foreach ((Vector2 p1, Vector2 p2) lineSegment in lineSegments)
        {
            Vector2? intersection = GetIntersection(current.p1, current.p2, lineSegment.p1, lineSegment.p2);
            if (intersection is Vector2 intersectionValue)
            {
                if (intersectionsCopy.Contains(intersectionValue))
                {
                    continue;
                }
                intersectionsCopy.Add(intersectionValue);
                if (recurse((intersectionValue, lineSegment.p2), lineSegments, intersectionsCopy))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool Reaches5050(Vector2 p1, Vector2 p2)
    {
        Vector2 p5050 = new Vector2(50, 50);
        float d1 = Vector2.Distance(p1, p5050);
        float d2 = Vector2.Distance(p2, p5050);
        float d3 = Vector2.Distance(p1, p2);
        if (d1+d2 == d3)
        {
            return true;
        }
        return false;
    }

    public Vector2? GetIntersection(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        float s1_x = p1.x - p0.x;
        float s1_y = p1.y - p0.y;
        float s2_x = p3.x - p2.x;
        float s2_y = p3.y - p2.y;
        float s = (-s1_y * (p0.x - p2.x) + s1_x * (p0.y - p2.y)) / (-s2_x * s1_y + s1_x * s2_y);
        float t = (s2_x * (p0.y - p2.y) - s2_y * (p0.x - p2.x)) / (-s2_x * s1_y + s1_x * s2_y);

        if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
        {
            return new Vector2(p0.x + (t * s1_x), p0.y + (t * s1_y));
        }
        return null;

    }

}
