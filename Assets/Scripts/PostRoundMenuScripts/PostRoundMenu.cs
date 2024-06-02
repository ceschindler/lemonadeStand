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
    private TextMeshProUGUI opponentLemonadeStandCustomerCount;

    // Post Round stats
    private PostRoundStats postRoundStats;
    // Reference to scene change script
    private SceneChangeScript sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        playerLemonadeStandCustomerCount = (TextMeshProUGUI) GameObject.Find("playerLemonadeStandCustomerCount").GetComponent<TextMeshProUGUI>();
        opponentLemonadeStandCustomerCount = (TextMeshProUGUI) GameObject.Find("opponentLemonadeStandCustomerCount").GetComponent<TextMeshProUGUI>();
        // Grab info from previous round
        // Located on an Empty object using DontDestroyOnLoad from previous scene
        postRoundStats = (PostRoundStats) GameObject.Find("PostRoundStats").GetComponent<PostRoundStats>();
        Debug.Log(postRoundStats);
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

    // Updates text of Customer counts
    public void updateCustomerCountText((string, int) stat)
    {
        Debug.Log(stat.Item1);
        Debug.Log(stat.Item2);
        if (stat.Item1 == "PlayerLemonadeStand")
        {
            playerLemonadeStandCustomerCount.text = stat.Item2.ToString();
        }
        else
        {
            opponentLemonadeStandCustomerCount.text = stat.Item2.ToString();
        }
        
    }
}
