using System;
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

    private int level;  // 0 = Tutorial, 1-3 = Standard Levels
    private int gameLevel; // Difficulty level of minigame chosen by player

    private ShopItem[] items; // Array with shop items that can be bought
    private int[] ownedItems; // Array with number of own shop items

    private bool inGame;  // True when player is playing minigame
    public bool win;  // True when player won the previous minigame

    private Text IncomeEquation;  // Used for efficient changing of income equation
    private Text Bananas;  // Used for efficient changing of banana display
    private GameObject BananaFarm;
    private GameObject BananaFactory;
    private Dropdown LevelDropdown;
    private Text Cost0;  // Used for changing cost of banana tree
    private Text Cost1; // Used for changing cost of banana farm
    private Text Cost2; // Used for changing cost of banana factory
    private Text Count0; // Used for changing count of banana tree
    private Text Count1; // Used for changing count of banana farm
    private Text Count2; // Used for changing count of banana factory
    private Image Tree1;
    private Image Tree2;
    private Image Tree3;
    private Image Tree4;
    private Image Tree5;
    private Image Farm1;
    private Image Farm2;
    private Image Farm3;
    private Image Farm4;
    private Image Farm5;
    private Image Factory1;
    private Image Factory2;
    private Image Factory3;
    private Image Factory4;
    private Image Factory5;

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
        y = 1000;
        m = 1;
        b = 0;
        level = 0;
        gameLevel = 1;

        IncomeEquation = GameObject.Find("IncomeEquation").GetComponent<Text>();
        Bananas = GameObject.Find("BananaCount").GetComponent<Text>();
        BananaFarm = GameObject.Find("BananaFarm");
        BananaFactory = GameObject.Find("BananaFactory");
        LevelDropdown = GameObject.Find("LevelDropdown").GetComponent<Dropdown>();
        Cost0 = GameObject.Find("BananaTreeCost").GetComponent<Text>();
        Cost1 = GameObject.Find("BananaFarmCost").GetComponent<Text>();
        Cost2 = GameObject.Find("BananaFactoryCost").GetComponent<Text>();
        Count0 = GameObject.Find("BananaTreeCount").GetComponent<Text>();
        Count1 = GameObject.Find("BananaFarmCount").GetComponent<Text>();
        Count2 = GameObject.Find("BananaFactoryCount").GetComponent<Text>();
        Tree1 = GameObject.Find("Tree 1").GetComponent<Image>();
        Tree2 = GameObject.Find("Tree 2").GetComponent<Image>();
        Tree3 = GameObject.Find("Tree 3").GetComponent<Image>();
        Tree4 = GameObject.Find("Tree 4").GetComponent<Image>();
        Tree5 = GameObject.Find("Tree 5").GetComponent<Image>();
        Farm1 = GameObject.Find("Farm 1").GetComponent<Image>();
        Farm2 = GameObject.Find("Farm 2").GetComponent<Image>();
        Farm3 = GameObject.Find("Farm 3").GetComponent<Image>();
        Farm4 = GameObject.Find("Farm 4").GetComponent<Image>();
        Farm5 = GameObject.Find("Farm 5").GetComponent<Image>();
        Factory1 = GameObject.Find("Factory 1").GetComponent<Image>();
        Factory2 = GameObject.Find("Factory 2").GetComponent<Image>();
        Factory3 = GameObject.Find("Factory 3").GetComponent<Image>();
        Factory4 = GameObject.Find("Factory 4").GetComponent<Image>();
        Factory5 = GameObject.Find("Factory 5").GetComponent<Image>();

        items = new ShopItem[3] {new ShopItem(), new ShopItem(), new ShopItem()};
        items[0].Cost = 1;
        items[0].Increase = 1;
        items[1].Cost = 10;
        items[1].Increase = 10;
        items[2].Cost = 100;
        items[2].Increase = 100;

        ownedItems = new int[3] {0, 0, 0};

        BananaFarm.SetActive(false);
        BananaFactory.SetActive(false);
        Tree1.enabled = false;
        Tree2.enabled = false;
        Tree3.enabled = false;
        Tree4.enabled = false;
        Tree5.enabled = false;
        Farm1.enabled = false;
        Farm2.enabled = false;
        Farm3.enabled = false;
        Farm4.enabled = false;
        Farm5.enabled = false;
        Factory1.enabled = false;
        Factory2.enabled = false;
        Factory3.enabled = false;
        Factory4.enabled = false;
        Factory5.enabled = false;
    }

    // Update is called once per frame
    void Update() {  UpdateUI(); }

    // UpdateUI: Updates the UI (does not need to occur every frame)
    private void UpdateUI()
    {
        if (m < 1 || b > 0) { return; }

        string t1, t2, t3, t4, t5, t6, t7, t8;

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
        IncomeEquation.text = t1;

        t2 = "Bananas: " + y.ToString();
        Bananas.text = t2;

        if (items[0].Cost == 1)
        {
            t3 = "Cost: 1 Banana";
        }
        else
        {
            t3 = "Cost: " + items[0].Cost + " Bananas";
        }
        Cost0.text = t3;

        if (level >= 2)
        {
            t4 = "Cost: " + items[1].Cost + " Bananas";
            Cost1.text = t4;
        }
        if (level >= 3)
        {
            t5 = "Cost: " + items[2].Cost + " Bananas";
            Cost2.text = t5;
        }
        
        t6 = ownedItems[0].ToString();
        Count0.text = t6;

        if (level >= 2)
        {
            t7 = ownedItems[1].ToString();
            Count1.text = t7;
        }
        if (level >= 3)
        {
            t8 = ownedItems[2].ToString();
            Count2.text = t8;
        }

        gameLevel = LevelDropdown.value;
    }

    // Purchase the shop item at the given index (0, 1, 2) of the shop array
    public void Purchase(int index)
    {
        ShopItem item = items[index];

        // Cannot afford item
        if (item.Cost > y)
        {
            return;
        }

        // Adjust class variables based on item
        y -= item.Cost;
        m += item.Increase;
        b -= item.Cost;
        ownedItems[index]++;

        // Increase item's cost
        items[index].Cost += (int) Math.Pow(10, index);

        // Increase level if item was purchased for first time
        if (ownedItems[index] == 1)
        {
            IncreaseLevel();
        }

        // Update images in center panel
        if (index == 0)
        {
            switch (ownedItems[index])
            {
                case 1:
                    Tree1.enabled = true;
                    break;
                case 2:
                    Tree2.enabled = true;
                    break;
                case 3:
                    Tree3.enabled = true;
                    break;
                case 4:
                    Tree4.enabled = true;
                    break;
                case 5:
                    Tree5.enabled = true;
                    break;
            }
        }

        if (index == 1)
        {
            switch (ownedItems[index])
            {
                case 1:
                    Farm1.enabled = true;
                    break;
                case 2:
                    Farm2.enabled = true;
                    break;
                case 3:
                    Farm3.enabled = true;
                    break;
                case 4:
                    Farm4.enabled = true;
                    break;
                case 5:
                    Farm5.enabled = true;
                    break;
            }
        }

        if (index == 2)
        {
            switch (ownedItems[index])
            {
                case 1:
                    Factory1.enabled = true;
                    break;
                case 2:
                    Factory2.enabled = true;
                    break;
                case 3:
                    Factory3.enabled = true;
                    break;
                case 4:
                    Factory4.enabled = true;
                    break;
                case 5:
                    Factory5.enabled = true;
                    break;
            }
        }
    }

    // Updates the minigames and shop to reflect the increased level
    private void IncreaseLevel()
    {
        if (level == 0)
        {
            BananaFarm.SetActive(true);
        }
        if (level == 1)
        {
            LevelDropdown.ClearOptions();
            List<string> newData = new List<string> { "Level 1", "Level 2"};
            LevelDropdown.AddOptions(newData);
            BananaFactory.SetActive(true);
        }
        if (level == 2)
        {
            LevelDropdown.ClearOptions();
            List<string> newData = new List<string> { "Level 1", "Level 2", "Level 3"};
            LevelDropdown.AddOptions(newData);
        }

        level++;
    }
}
