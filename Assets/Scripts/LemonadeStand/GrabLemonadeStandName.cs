using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GrabLemonadeStandName : MonoBehaviour
{
    // Lemonade Stand name
    private string playerLemonadeStandName;
    private string opponentLemonadeStandName1 = "Girl Scouts";
    private string opponentLemonadeStandname2 = "Boy Scouts";

    // Reference to scene change script
    private SceneChangeScript sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize scene change script in object
        sceneChange = (SceneChangeScript) GameObject.Find("Canvas").GetComponent<SceneChangeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get Player lemonadeStand name
    public string GetPlayerLemonadeStandName()
    {
        return playerLemonadeStandName;
    }

    // Get Opponenet lemonade stand name
    public string GetOpponentLemonadeStandName(int value)
    {
        if (value == 1)
        {
            return opponentLemonadeStandName1;
        }
        else
        {
            return opponentLemonadeStandname2;
        }
    }

    // Grab input field text from scene and send it forward
    public void confirmStandNameButton() 
    {
        // Grab input field text and assign to script object
        TMP_InputField inputField = (TMP_InputField) GameObject.Find("InputField").GetComponent<TMP_InputField>();
        playerLemonadeStandName = inputField.text;
        Debug.Log(playerLemonadeStandName);
        // Find empty object to pass forward
        GameObject lemonadeStandName = GameObject.Find("LemonadeStandName");
        DontDestroyOnLoad(lemonadeStandName);

        // Move to next scene
        sceneChange.IngredientsSelectionScene();
    }

    // Update Lemonade stand names with winner before going to next round
    public void UpdateLemonadeStandNamesWithWinner(int standOneCount, int standTwoCount)
    {
        if (standTwoCount > standOneCount)
        {
            opponentLemonadeStandName1 = opponentLemonadeStandname2;
        }
    }
}
