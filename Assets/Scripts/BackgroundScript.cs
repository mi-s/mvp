using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{
    public GameObject graphWindow;
    // Start is called before the first frame update
    void Awake()
    {
        WindowScript windowScript = graphWindow.GetComponent<WindowScript>();
        windowScript.CreateLine(new Vector2(10, 0), new Vector2(10, 50), 0.15f);
        windowScript.CreateLine(new Vector2(20, 0), new Vector2(20, 50), 0.15f); //0.1f doesn't work??
        windowScript.CreateLine(new Vector2(30, 0), new Vector2(30, 50), 0.15f);
        windowScript.CreateLine(new Vector2(40, 0), new Vector2(40, 50), 0.15f);

        windowScript.CreateLine(new Vector2(0, 10), new Vector2(50, 10), 0.15f);
        windowScript.CreateLine(new Vector2(0, 20), new Vector2(50, 20), 0.15f);
        windowScript.CreateLine(new Vector2(0, 30), new Vector2(50, 30), 0.15f);
        windowScript.CreateLine(new Vector2(0, 40), new Vector2(50, 40), 0.15f);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
