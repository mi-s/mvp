using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    // y = mx + b
    private int y;  // Total Bananas 
    private int m;  // Slope of income equation (y = mx + b)
    private int b;  // Intercept of income equation

    private Text IncomeEquation;  // Used for efficient changing of income equation
    private Text Bananas;  // Used for effiient changing of banana display

    private int level;  // Game Level, 0 = Tutorial

    private ShopItem[] items; // Array showing how much the player has of each shop item

    private bool isInGame;
    public bool hasWon;

    public class ShopItem
    {
        private int increase; // How much item increases slope by
        private int cost;     // How much the item costs

        public ShopItem() {}

        public ShopItem(int i, int c)
        {
            increase = i;
            cost = c;
        }

        public int Increase { get; set; }
        public int Cost { get; set; }
    }

    // Start is called before the first frame update
    void Start()
    {
        y = 0;
        m = 1;
        b = 0;
        level = 0;
        IncomeEquation = GameObject.Find("IncomeEquation").GetComponent<Text>();
        Bananas = GameObject.Find("BananaCount").GetComponent<Text>();
        items = new ShopItem[3] {new ShopItem(1, 1), 
                                 new ShopItem(10, 10), 
                                 new ShopItem(100, 100)};
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIncome();
    }

    // UpdateIncome: Updates the UI income equation
    private void UpdateIncome()
    {
        if (m < 1 || b > 0) { return; }

        string t1, t2;

        if (m == 1 && b == 0)
        {
            t1 = "Income: y = x";
        }
        else if (m == 1)
        {
            t1 = "Income: y = x - " + (b * -1).ToString();
        }
        else if (b == 0)
        {
            t1 = "Income: y = " + m.ToString() + "x";
        }
        else
        {
            t1 = "Income: y = " + m.ToString() + "x - " + (b * -1).ToString();
        }

        t2 = "Bananas: " + y.ToString();

        IncomeEquation.text = t1;
        Bananas.text = t2;
    }

    // Purchase the shop item at the given index (0, 1, 2) of the shop array
    private void Purchase(int index)
    {
        
    }

    // Updates the minigames and shop to reflect the increased level
    private void IncreaseLevel()
    {

    }

    



}
