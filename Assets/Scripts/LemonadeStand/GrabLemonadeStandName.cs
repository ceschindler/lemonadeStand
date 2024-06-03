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
}
