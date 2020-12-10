using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // y = mx + b
    private int y;  // Total Bananas 
    private int m;  // Slope of income equation (y = mx + b)
    private int b;  // Intercept of income equation

    private int level;  // 0 = Tutorial, 1-3 = Standard Levels
    public static int gameLevel; // Difficulty level of minigame chosen by player

    private ShopItem[] items; // Array with shop items that can be bought
    private int[] ownedItems; // Array with number of own shop items

    private bool tutorialGame1Done;
    private bool tutorialGame2Done;
    private bool realGame;
    public static bool win;  // True when player won the previous minigame

    int tutorialStage;  // From 1-9 = Tutorial, 10 = Done with tutorial

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
    private Text Origin;
    private Text TLCorner;
    private Text TRCorner;
    private Text BRCorner;
    private Text Variables;
    private GameObject Stage1;
    private GameObject Stage2;
    private GameObject Stage3;
    private GameObject Stage4;
    private GameObject Stage5;
    private GameObject Stage6;
    private GameObject Stage7;
    private GameObject Stage8;
    private GameObject Stage9;
    private GameObject Stage10;

    public WindowScript Ws;

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
        y = 500;
        m = 1;
        b = 0;
        level = 0;
        gameLevel = 0;
        win = false;
        tutorialStage = 0;
        tutorialGame1Done = false;
        tutorialGame2Done = false;

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
        Origin = GameObject.Find("Origin").GetComponent<Text>();
        BRCorner = GameObject.Find("BRCorner").GetComponent<Text>();
        TRCorner = GameObject.Find("TRCorner").GetComponent<Text>();
        TLCorner = GameObject.Find("TLCorner").GetComponent<Text>();
        Variables = GameObject.Find("Variables").GetComponent<Text>();
        Stage1 = GameObject.Find("Stage1");
        Stage2 = GameObject.Find("Stage2");
        Stage3 = GameObject.Find("Stage3");
        Stage4 = GameObject.Find("Stage4");
        Stage5 = GameObject.Find("Stage5");
        Stage6 = GameObject.Find("Stage6");
        Stage7 = GameObject.Find("Stage7");
        Stage8 = GameObject.Find("Stage8");
        Stage9 = GameObject.Find("Stage9");
        Stage10 = GameObject.Find("Stage10");

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

        Ws.CreateLine(new Vector2(0, 0), new Vector2(200, 200), 1.5f);

        // Square Grid
        Ws.CreateLine(new Vector2(0, 0), new Vector2(0, 200), .65f);
        Ws.CreateLine(new Vector2(0, 0), new Vector2(200, 0), .65f);
        Ws.CreateLine(new Vector2(200, 0), new Vector2(200, 200), .65f);
        Ws.CreateLine(new Vector2(0, 200), new Vector2(200, 200), .65f);

        // Vertical Lines
        Ws.CreateLine(new Vector2(50, 0), new Vector2(50, 200), .65f);
        Ws.CreateLine(new Vector2(100, 0), new Vector2(100, 200), .65f);
        Ws.CreateLine(new Vector2(150, 0), new Vector2(150, 200), .65f);

        // Horizontal Lines
        Ws.CreateLine(new Vector2(0, 50), new Vector2(200, 50), .65f);
        Ws.CreateLine(new Vector2(0, 100), new Vector2(200, 100), .65f);
        Ws.CreateLine(new Vector2(0, 150), new Vector2(200, 150), .65f);

        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
        Stage7.SetActive(false);
        Stage8.SetActive(false);
        Stage9.SetActive(false);
        Stage10.SetActive(false);
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update() 
    {  
        if (tutorialStage == 1)
        {
            Stage1.SetActive(false);
            Stage2.SetActive(true);
        }
        if (tutorialStage == 2)
        {
            Stage2.SetActive(false);
            Stage3.SetActive(true);
        }
        if (tutorialStage == 3)
        {
            Stage3.SetActive(false);
            Stage4.SetActive(true);
        }
        if (tutorialStage == 4)
        {
            Stage4.SetActive(false);
            Stage5.SetActive(true);
        }
        if (tutorialStage == 5)
        {
            Stage5.SetActive(false);
            Stage6.SetActive(true);
        }
        if (tutorialStage == 6)
        {
            tutorialGame1Done = true;
            Stage6.SetActive(false);
            Stage7.SetActive(true);
        }
        if (tutorialStage == 7)
        {
            tutorialGame2Done = true;
            Stage7.SetActive(false);
            Stage8.SetActive(true);
        }
        if (tutorialStage == 8)
        {
            Stage8.SetActive(false);
            Stage9.SetActive(true);
        }
        if (tutorialStage == 9)
        {
            Stage9.SetActive(false);
            Stage10.SetActive(true);
        }
        if (tutorialStage == 10)
        {
            Stage10.SetActive(false);
        }

        if (win && tutorialGame1Done)
        {
            tutorialGame1Done = false;
            win = false;
            tutorialStage++;
        }

        if (win && tutorialGame2Done)
        {
            y += m;
            tutorialGame2Done = false;
            win = false;
            tutorialStage++;
        }

        if (win && realGame)
        {
            y += m;
            win = false;
        }
        else if (win)
        {
            win = false;
        }

        string t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13;

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

        t9 = "(0, " + b + ")";
        Origin.text = t9;

        t10 = "(1, " + b + ")";
        BRCorner.text = t10;

        int newY = m + b;

        t11 = "(0, " + newY + ")";
        TLCorner.text = t11;

        t12 = "(1, " + newY + ")";
        TRCorner.text = t12;

        t13 = "m = " + m + "   b = " + b;
        Variables.text = t13;
        
        if (tutorialStage < 10)
        {
            gameLevel = 0;
        }
        else
        {
            gameLevel = LevelDropdown.value + 1;
        }
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

    // Plays the minigame of this current level
    public void PlayGame()
    {
        realGame = true;

        Debug.Log(gameLevel);

        if (gameLevel == 0)
        {
            SceneManager.LoadScene("MazeMinigame", LoadSceneMode.Additive);
        }
        else if (gameLevel == 1)
        {
            SceneManager.LoadScene("MazeMinigame", LoadSceneMode.Additive);
        }
        else if (gameLevel == 2)
        {
            SceneManager.LoadScene("MachineMinigame", LoadSceneMode.Additive);
        }
        else if (gameLevel == 3)
        {
            SceneManager.LoadScene("MazeMinigame", LoadSceneMode.Additive);
        }
    }

    // Plays the tutorial for the given minigame
    public void PlayTutorial()
    {
        realGame = false;

        Debug.Log(gameLevel);

        if (gameLevel == 0)
        {
            SceneManager.LoadScene("MazeTutorial", LoadSceneMode.Additive);
        }
        else if (gameLevel == 1)
        {
            SceneManager.LoadScene("MazeTutorial", LoadSceneMode.Additive);
        }
        else if (gameLevel == 2)
        {
            SceneManager.LoadScene("MachineTutorial", LoadSceneMode.Additive);
        }
        else if (gameLevel == 3)
        {
            SceneManager.LoadScene("MazeTutorial", LoadSceneMode.Additive);
        }
    }

    public void IncreaseTutorialStage()
    { 
        tutorialStage++;
    }
}
