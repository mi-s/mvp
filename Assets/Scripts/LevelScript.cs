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
        switch(GameMenu.gameLevel)
        {
            case 0: Level0(); break;
            case 1: Level1(); break;
            case 2: Level2(); break;
            case 3: Level3(); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level0()
    {
        windowScript.CreateCircle(new Vector2(0, 0), Color.magenta);
        windowScript.CreateCircle(new Vector2(50, 50), Color.magenta);
        Vector2 p0 = new Vector2(25, 20);
        Vector2 p1 = new Vector2(25, 30);
        windowScript.CreateLine(p0, p1, 1f);
        graphScript.obstacles.Add((p0, p1));
    }

    public void Level1()
    {
        windowScript.CreateCircle(new Vector2(0, 0), Color.magenta);
        windowScript.CreateCircle(new Vector2(50, 50), Color.magenta);
        Vector2 p0 = new Vector2(15, 25);
        Vector2 p1 = new Vector2(35, 25);
        windowScript.CreateLine(p0, p1, 1f);
        graphScript.obstacles.Add((p0, p1));
    }

    public void Level2()
    {
        Vector2 p0 = new Vector2(0f, 50f);
        Vector2 p1 = new Vector2(50f, 0f);
        Vector2 p2 = new Vector2(0f, 0f);
        Vector2 p3 = new Vector2(50f, 50f);
        Vector2 p4 = new Vector2(0f, 40f);
        Vector2 p5 = new Vector2(50f, 40f);
        windowScript.CreateCircle(p0, Color.magenta);
        windowScript.CreateCircle(p1, Color.magenta);
        windowScript.CreateCircle(p2, Color.red);
        windowScript.CreateCircle(p3, Color.red);
        windowScript.CreateCircle(p4, Color.black);
        windowScript.CreateCircle(p5, Color.black);
        graphScript.solutions.Add((p0, p1));
        graphScript.solutions.Add((p2, p3));
        graphScript.solutions.Add((p4, p5));
        graphScript.endpoints.Add((p0, p1, Color.magenta));
        graphScript.endpoints.Add((p2, p3, Color.red));
        graphScript.endpoints.Add((p4, p5, Color.black));
        Vector2 s0 = new Vector2(10, 40);
        Vector2 s1 = new Vector2(40, 40);
        Vector2 s2 = new Vector2(25, 25);
        graphScript.solutionIntersections.Add(s0);
        graphScript.solutionIntersections.Add(s1);
        graphScript.solutionIntersections.Add(s2);
    }

    public void Level3()
    {
        windowScript.CreateCircle(new Vector2(0, 0), Color.magenta);
        windowScript.CreateCircle(new Vector2(50, 50), Color.magenta);
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
