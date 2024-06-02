using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PostRoundMenu : MonoBehaviour
{
    // Customer count variables/text for menu
    private TextMeshProUGUI playerLemonadeStandCustomerCount;
    private TextMeshProUGUI opponentLemonadeStandCustomerCount1;
    private TextMeshProUGUI opponentLemonadeStandCustomerCount2;

    // Post Round stats
    private PostRoundStats postRoundStats;
    // Reference to scene change script
    private SceneChangeScript sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        // Grab info from previous round
        // Located on an Empty object using DontDestroyOnLoad from previous scene
        postRoundStats = (PostRoundStats) GameObject.Find("PostRoundStats").GetComponent<PostRoundStats>();

        // Grab text objects to replace counts with
        playerLemonadeStandCustomerCount = (TextMeshProUGUI) GameObject.Find("playerLemonadeStandCustomerCount").GetComponent<TextMeshProUGUI>();
        opponentLemonadeStandCustomerCount1 = (TextMeshProUGUI) GameObject.Find("opponentLemonadeStandCustomerCount1").GetComponent<TextMeshProUGUI>();
        if (postRoundStats.GetLemonadeStandCounts().Length > 2)
        {
            opponentLemonadeStandCustomerCount2 = (TextMeshProUGUI) GameObject.Find("opponentLemonadeStandCustomerCount2").GetComponent<TextMeshProUGUI>();
        }
        
        // Update text on screen to match stats from last round
        foreach ((string, int) stat in postRoundStats.GetLemonadeStandCounts())
        {
            Debug.Log(stat.Item1 + " had " + stat.Item2 + " customers in the last round");
            updateCustomerCountText(stat);
        }

        // Initialize scene change script in object
        sceneChange = (SceneChangeScript) gameObject.GetComponent<SceneChangeScript>();
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
        GameObject finalLevel = GameObject.Find("FinalLevel");
        if (finalLevel)
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
    public void updateCustomerCountText((string, int) stat)
    {
        Debug.Log(stat.Item1);
        Debug.Log(stat.Item2);
        if (stat.Item1 == "PlayerLemonadeStand")
        {
            playerLemonadeStandCustomerCount.text = stat.Item2.ToString();
        }
        else if (stat.Item1 == "OpponentLemonadeStand1")
        {
            opponentLemonadeStandCustomerCount1.text = stat.Item2.ToString();
        }
        else if (stat.Item1 == "OpponentLemonadeStand2")
        {
            opponentLemonadeStandCustomerCount2.text = stat.Item2.ToString();
        }
        
    }
}
