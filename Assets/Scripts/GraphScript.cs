using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphScript : MonoBehaviour
{
    public GameObject graphWindow;
    public GameObject slopeInput;
    public GameObject interceptInput;
    public HashSet<(Vector2, Vector2)> lineSegments;
    public HashSet<(Vector2, Vector2)> obstacles;
    void Awake()
    {
        lineSegments = new HashSet<(Vector2, Vector2)>();
        obstacles = new HashSet<(Vector2, Vector2)>();
        Debug.Log("created hashsets");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Graph()
    {
        string mString = slopeInput.GetComponent<Text>().text;
        string bString = interceptInput.GetComponent<Text>().text;
        float m = float.Parse(mString);
        float b = float.Parse(bString);
        Vector2 p1 = new Vector2(0, b);
        Vector2 p2 = new Vector2(50, 50 * m + b);
        foreach ((Vector2 p3, Vector2 p4) obstacle in obstacles)
        {
            Vector2? intersection = GetIntersection(p1, p2, obstacle.p3, obstacle.p4);
            if (intersection is Vector2 intersectionValue)
            {
                p2 = intersectionValue;
            }
        }
        graphWindow.GetComponent<WindowScript>().CreateLine(p1, p2, 0.5f);
        lineSegments.Add((p1, p2));
        Debug.Log(string.Join(",", lineSegments));
    }

    public void Reset()
    {
        Transform graphContainer = graphWindow.transform.Find("GraphContainer");
        foreach (Transform child in graphContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        WindowScript windowScript = graphWindow.GetComponent<WindowScript>();
        windowScript.CreateLine(new Vector2(10, 0), new Vector2(10, 50), 0.15f);
        windowScript.CreateLine(new Vector2(20, 0), new Vector2(20, 50), 0.15f); //0.1f doesn't work??
        windowScript.CreateLine(new Vector2(30, 0), new Vector2(30, 50), 0.15f);
        windowScript.CreateLine(new Vector2(40, 0), new Vector2(40, 50), 0.15f);

        windowScript.CreateLine(new Vector2(0, 10), new Vector2(50, 10), 0.15f);
        windowScript.CreateLine(new Vector2(0, 20), new Vector2(50, 20), 0.15f);
        windowScript.CreateLine(new Vector2(0, 30), new Vector2(50, 30), 0.15f);
        windowScript.CreateLine(new Vector2(0, 40), new Vector2(50, 40), 0.15f);

        lineSegments = new HashSet<(Vector2, Vector2)>();

        //need to reset level

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
