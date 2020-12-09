using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // y = mx + b
    private int y;  // Total Bananas 
    private int m;  // Slope of income equation (y = mx + b)
    private int b;  // Intercept of income equation

    private Text IncomeEquation;

    // Start is called before the first frame update
    void Start()
    {
        y = 0;
        m = 1;
        b = 0;
        IncomeEquation = GameObject.Find("IncomeEquation").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIncome(m, b);
    }

    // UpdateIncome: Updates the UI income equation
    private void UpdateIncome(int slope, int inter)
    {
        if (slope < 1 || inter > 0) { return; }

        string t;

        if (slope == 1 && inter == 0)
        {
            t = "Bananas: y = x";
        }
        else if (slope == 1)
        {
            t = "Bananas: y = x - " + (inter * -1).ToString();
        }
        else if (inter == 0)
        {
            t = "Bananas: y = " + slope.ToString() + "x";
        }
        else
        {
            t = "Bananas: y = " + slope.ToString() + "x - " + (inter * -1).ToString();
        }

        IncomeEquation.text = t;
    }
    


}
