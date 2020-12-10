using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript2 : MonoBehaviour
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
        MazeTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MazeTutorial()
    {
        windowScript.CreateCircle(new Vector2(0, 0), Color.magenta);
        windowScript.CreateCircle(new Vector2(50, 50), Color.magenta);
    }
}
