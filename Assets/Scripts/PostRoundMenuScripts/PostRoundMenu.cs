using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PostRoundMenu : MonoBehaviour
{
    // Customer count variables/text for menu
    private TextMeshProUGUI playerStatLabel;
    private TextMeshProUGUI playerLemonadeStandCustomerCount;
    private TextMeshProUGUI opponentStatLabel1;
    private TextMeshProUGUI opponentLemonadeStandCustomerCount1;
    private TextMeshProUGUI opponentStatLabel2;
    private TextMeshProUGUI opponentLemonadeStandCustomerCount2;

    // Post Round stats
    private PostRoundStats postRoundStats;
    // Reference to scene change script
    private SceneChangeScript sceneChange;
    // Reference to lemonadeStand names
    private GrabLemonadeStandName lemonadeStandNames;
    // Reference to win/loss text field
    private TextMeshProUGUI winLossText;

    // Start is called before the first frame update
    void Start()
    {
        // Grab info from previous round
        // Located on an Empty object using DontDestroyOnLoad from previous scene
        postRoundStats = (PostRoundStats) GameObject.Find("PostRoundStats").GetComponent<PostRoundStats>();

        // Grab lemonade Stand names from previous round
        lemonadeStandNames = (GrabLemonadeStandName) GameObject.Find("LemonadeStandName").GetComponent<GrabLemonadeStandName>();

        // Grab text objects to replace counts with
        playerStatLabel = (TextMeshProUGUI) GameObject.Find("playerLemonadeStandLabel").GetComponent<TextMeshProUGUI>();
        playerLemonadeStandCustomerCount = (TextMeshProUGUI) GameObject.Find("playerLemonadeStandCustomerCount").GetComponent<TextMeshProUGUI>();
        opponentStatLabel1 = (TextMeshProUGUI) GameObject.Find("opponentLemonadeStandLabel1").GetComponent<TextMeshProUGUI>();
        opponentLemonadeStandCustomerCount1 = (TextMeshProUGUI) GameObject.Find("opponentLemonadeStandCustomerCount1").GetComponent<TextMeshProUGUI>();
        if (postRoundStats.GetLemonadeStandCounts().Length > 2)
        {
            opponentStatLabel2 = (TextMeshProUGUI) GameObject.Find("opponentLemonadeStandLabel2").GetComponent<TextMeshProUGUI>();
            opponentLemonadeStandCustomerCount2 = (TextMeshProUGUI) GameObject.Find("opponentLemonadeStandCustomerCount2").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            // create an empty object for comparison in final round
            opponentLemonadeStandCustomerCount2 = new TextMeshProUGUI();
            opponentLemonadeStandCustomerCount2.text = "0";
        }
        
        // Update text on screen to match stats from last round
        foreach ((string, int) stat in postRoundStats.GetLemonadeStandCounts())
        {
            Debug.Log(stat.Item1 + " had " + stat.Item2 + " customers in the last round");
            UpdateCustomerCountTextAndLabel(stat);
        }

        // Grab reference to Win/Loss text item
        winLossText = (TextMeshProUGUI) GameObject.Find("youWinOrLose").GetComponent<TextMeshProUGUI>();
        // Initialize scene change script in object
        sceneChange = (SceneChangeScript) gameObject.GetComponent<SceneChangeScript>();

        // Change win/lost text at header of screen
        ShowWinLossText();

        // Determin if next level button should be visible or not
        ShowNextLevelButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restart the game button
    public void restartGameButton()
    {
        Debug.Log("Restart game button clicked");
        sceneChange.IngredientsSelectionScene();
    }

    // Next Level game button
    public void nextLevelGameButton()
    {
        Debug.Log("Next Level button clicked");
        // Update LemonadeStandName with winning name
        lemonadeStandNames.UpdateLemonadeStandNamesWithWinner(int.Parse(opponentLemonadeStandCustomerCount1.text), 
                                                                int.Parse(opponentLemonadeStandCustomerCount2.text));
        FinalLevel finalLevel = (FinalLevel) GameObject.Find("FinalLevel").GetComponent<FinalLevel>();
        finalLevel.SetIsFinalLevel(true);
        if (finalLevel.GetIsFinalLevel())
        {
            DontDestroyOnLoad(finalLevel);
        }
        sceneChange.IngredientsSelectionScene();
    }

    // Start game menu button
    public void startGameMenuButton() 
    {
        Debug.Log("Start menu button clicked");
        Destroy(GameObject.Find("FinalLevel"));
        sceneChange.StartMenuScene();
    }

    // Updates text of Customer counts
    public void UpdateCustomerCountTextAndLabel((string, int) stat)
    {
        Debug.Log(stat.Item1);
        Debug.Log(stat.Item2);
        if (stat.Item1 == "PlayerLemonadeStand")
        {
            playerStatLabel.text = lemonadeStandNames.GetPlayerLemonadeStandName();
            playerLemonadeStandCustomerCount.text = stat.Item2.ToString();
        }
        else if (stat.Item1 == "OpponentLemonadeStand1")
        {
            opponentStatLabel1.text = lemonadeStandNames.GetOpponentLemonadeStandName(1);
            opponentLemonadeStandCustomerCount1.text = stat.Item2.ToString();
        }
        else if (stat.Item1 == "OpponentLemonadeStand2")
        {
            opponentStatLabel2.text = lemonadeStandNames.GetOpponentLemonadeStandName(2);
            opponentLemonadeStandCustomerCount2.text = stat.Item2.ToString();
        }
    }

    // Show win/lose text based on user's performance
    public void ShowWinLossText()
    {
        int didWeWin = DidWeWin();
        if (didWeWin == 1)
        {
            winLossText.text = "You WIN! ";
            if (gameObject.scene.name == "PostRoundRecapFinalRound")
            {
                winLossText.text += "You are the LAST Lemonade STAND! Thanks for playing";
            }
        }
        else if (didWeWin == 2)
        {
            winLossText.text = "You probably TIED.";
        }
        else if (didWeWin == 3)
        {
            winLossText.text = "You LOSE.. We must defeat those meddling kids! Try Again";
        }
        else
        {
            winLossText.text = "We didn't account for this... Good job!";
        }
    }

    // Game conditions
    // Return ints to signify game state as win/loss/draw
    public int DidWeWin()
    {
        // FinalLevel finalLevel = (FinalLevel) GameObject.Find("FinalLevel").GetComponent<FinalLevel>();
        // if (finalLevel.GetIsFinalLevel())
        // {
        //     opponentLemonadeStandCustomerCount2.text = "0";
        // }
        if (int.Parse(playerLemonadeStandCustomerCount.text) > int.Parse(opponentLemonadeStandCustomerCount1.text)
                && int.Parse(playerLemonadeStandCustomerCount.text) > int.Parse(opponentLemonadeStandCustomerCount2.text))
        {
            return 1;
        }
        else if ((int.Parse(playerLemonadeStandCustomerCount.text) > int.Parse(opponentLemonadeStandCustomerCount1.text)
                && int.Parse(playerLemonadeStandCustomerCount.text) == int.Parse(opponentLemonadeStandCustomerCount2.text))
                || (int.Parse(playerLemonadeStandCustomerCount.text) == int.Parse(opponentLemonadeStandCustomerCount1.text)
                && int.Parse(playerLemonadeStandCustomerCount.text) > int.Parse(opponentLemonadeStandCustomerCount2.text))
                || (int.Parse(playerLemonadeStandCustomerCount.text) == int.Parse(opponentLemonadeStandCustomerCount1.text)
                && int.Parse(playerLemonadeStandCustomerCount.text) == int.Parse(opponentLemonadeStandCustomerCount2.text)))
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    public void ShowNextLevelButton()
    {
        GameObject nextLevelButton = GameObject.Find("nextLevelButton");
        int didWeWin = DidWeWin();
        if (didWeWin != 1)
        {
            if (gameObject.scene.name == "PostRoundRecapFirstRound")
            {
                nextLevelButton.SetActive(false);
            }
        }
    }
}
