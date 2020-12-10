using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogScript : MonoBehaviour
{
    string[] dialog;
    int dialogIndex;
    public Text tutorialText;

    // Start is called before the first frame update
    void Start()
    {
        Scene m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;
        if (sceneName.Equals("MazeTutorial"))
        {
            dialog = new string[] {"Welcome to the Maze Game Tutorial!",
                                  "Business has been booming, banana production has never been higher, and you want to expand your industry in the next town over!",
                                  "To get to the next town, build a path from the origin (0,0) to the end point (50,50) by graphing linear equations.",
                                  "On harder difficulties, you may need to graph multiple equations to navigate around obstacles",
                                  "Press \"check\" once you're done!",
                                  "Here's a hint: the y-intercept should be 0" };
        }
        else if (sceneName.Equals("MachineTutorial"))
        {
            dialog = new string[] {"Welcome to the Machine Game Tutorial!",
                                  "One of your banana producing machines has broken, and you need to fix it!",
                                  "To fix the machine, connect the wires of the correct colors together by graphing linear equations.",
                                  "Once you've graphed the equations, you need to untangle the wires by plotting the intersection points (where the lines meet)!",
                                  "Press \"check\" once you're done!",
                                  "Here's a hint: one of the equations is simply y = x" };
        }
        dialogIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ContinueDialog()
    {
        if (dialogIndex < 5)
        {
            dialogIndex++;
            tutorialText.text = dialog[dialogIndex];
        }
    }
}
