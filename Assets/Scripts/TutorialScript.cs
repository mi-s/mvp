using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
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
        MachineTutorial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MachineTutorial()
    {
        Vector2 p0 = new Vector2(0, 0);
        Vector2 p1 = new Vector2(50, 50);
        Vector2 p2 = new Vector2(0, 20);
        Vector2 p3 = new Vector2(50, 20);
        windowScript.CreateCircle(p0, Color.magenta);
        windowScript.CreateCircle(p1, Color.magenta);
        windowScript.CreateCircle(p2, Color.red);
        windowScript.CreateCircle(p3, Color.red);
        graphScript.solutions.Add((p0, p1));
        graphScript.solutions.Add((p2, p3));
        graphScript.endpoints.Add((p0, p1, Color.magenta));
        graphScript.endpoints.Add((p2, p3, Color.red));
    }
}
