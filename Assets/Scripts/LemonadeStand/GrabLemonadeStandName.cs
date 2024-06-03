using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GrabLemonadeStandName : MonoBehaviour
{
    // Lemonade Stand names
    private string playerLemonadeStandName;
    private string opponentLemonadeStandName1;
    private string opponentLemonadeStandName2;
    private string winnerLemonadeStand;

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

    public string GetOpponentLemonadeStandName1()
    {
        return opponentLemonadeStandName1;
    }
    public void SetOpponentLemonadeStandName1(string lemonadeStandText)
    {
        opponentLemonadeStandName1 = lemonadeStandText; 
    }

    public string GetOpponentLemonadeStandName2()
    {
        return opponentLemonadeStandName2;
    }
    public void SetOpponentLemonadeStandName2(string lemonadeStandText)
    {
        opponentLemonadeStandName2 = lemonadeStandText; 
    }

    public string GetWinnerLemonadeStandName()
    {
        return winnerLemonadeStand;
    }

    public void SetWinnerLemonadeStandName(string lemonadeStandText)
    {
        winnerLemonadeStand = lemonadeStandText;
    }

    // Grab input field text from scene and send it forward
    public void ConfirmStandNameButton() 
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

    // Append Opponent LemonadeStand names
    public void OpponentLemonadeStandNames()
    {
        GrabLemonadeStandName lemonadeStandName = (GrabLemonadeStandName) GameObject.Find("LemonadeStandName").GetComponent<GrabLemonadeStandName>();
        string opponentStandText1 = (string) GameObject.Find("OpponentLemonadeStandText1").GetComponent<TMP_Text>().text;
        Debug.Log(opponentStandText1);
        lemonadeStandName.SetOpponentLemonadeStandName1(opponentStandText1);
        string opponentStandText2 = (string) GameObject.Find("OpponentLemonadeStandText2").GetComponent<TMP_Text>().text;
        Debug.Log(opponentStandText2);
        lemonadeStandName.SetOpponentLemonadeStandName2(opponentStandText2);
    }

    // Append winner lemonade stand name
    public void WinnerLemonadeStandName()
    {
        GrabLemonadeStandName lemonadeStandName = (GrabLemonadeStandName) GameObject.Find("LemonadeStandName").GetComponent<GrabLemonadeStandName>();
        string winnerStandText = (string) GameObject.Find("WinnerLemonadeStandText").GetComponent<TMP_Text>().text;
        Debug.Log(winnerStandText);
        lemonadeStandName.SetOpponentLemonadeStandName1(winnerStandText);
    }
}
