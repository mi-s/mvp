using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public GameObject graphWindow;
    public GameObject gameHandler;
    private WindowScript windowScript;
    private GraphScript graphScript;
    // Start is called before the first frame update
    void Start()
    {
        windowScript = graphWindow.GetComponent<WindowScript>();
        graphScript = gameHandler.GetComponent<GraphScript>();
        //need logic here for which level to start
        Level3();
        Debug.Log(string.Join(",", graphScript.lineSegments));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        windowScript.CreateCircle(new Vector2(0, 0));
        windowScript.CreateCircle(new Vector2(50, 50));
    }

    public void Level2()
    {
        windowScript.CreateCircle(new Vector2(0, 0));
        windowScript.CreateCircle(new Vector2(50, 50));
        Vector2 p0 = new Vector2(25, 20);
        Vector2 p1 = new Vector2(25, 30);
        windowScript.CreateLine(p0, p1, 1f);
        graphScript.obstacles.Add((p0, p1));
    }

    public void Level3()
    {
        windowScript.CreateCircle(new Vector2(0, 0));
        windowScript.CreateCircle(new Vector2(50, 50));
        Vector2 p0 = new Vector2(25, 10);
        Vector2 p1 = new Vector2(25, 30);
        Vector2 p2 = new Vector2(0, 40);
        Vector2 p3 = new Vector2(40, 40);
        windowScript.CreateLine(p0, p1, 1f);
        windowScript.CreateLine(p2, p3, 1f);
        graphScript.obstacles.Add((p0, p1));
        graphScript.obstacles.Add((p2, p3));
    }
}
