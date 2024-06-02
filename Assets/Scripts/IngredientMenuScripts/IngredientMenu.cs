using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class IngredientMenu : MonoBehaviour
{
    // Creating options to assign in unity
    public TextMeshProUGUI LemonTotalNumber;
    public TextMeshProUGUI SugarTotalNumber;
    public TextMeshProUGUI WaterTotalNumber;
    public TextMeshProUGUI TotalIngredientValue;
   
    //Counter Variables
    int counterLemon;
    int counterSugar;
    int counterWater;

    //Total Variables for gameplay page
    int totalLemons;
    int totalSugar;
    int totalWater;

    // Scene change script variable
    private SceneChangeScript sceneChange;
    
    //Increases Lemon Amount
    // increments counter to limit of 10
    public void incrementLemonCounter()
    {
        if (counterLemon < 10)
        {
            counterLemon++;
            updateCounterText();
        }
    }

    // Reduces Lemon Amount
    // reduces counter to no lower than 0
    // calls updateCounterText to update the counter
    // with the current value
    public void reduceLemonCounter()
    {
        if (counterLemon > 0)
        {
            counterLemon--;
            updateCounterText();
        }
    }

    //Increases Sugar Amount
    // increments counter to limit of 10
    public void incrementSugarCounter()
    {
        if (counterSugar < 10)
        {
            counterSugar++;
            updateCounterText();
        }
    }

    // Reduces Sugar Amount
    // reduces counter to no lower than 0
    // calls updateCounterText to update the counter
    // with the current value
    public void reduceSugarCounter()
    {
        if (counterSugar > 0)
        {
            counterSugar--;
            updateCounterText();
        }
    }

    //Increases Water Amount
    // increments counter to limit of 10
    public void incrementWaterCounter()
    {
        if (counterWater < 10)
        {
            counterWater++;
            updateCounterText();
        }
    }

    // Reduces Water Amount
    // reduces counter to no lower than 0
    // calls updateCounterText to update the counter
    // with the current value
    public void reduceWaterCounter()
    {
        if (counterWater > 0)
        {
            counterWater--;
            updateCounterText();
        }
    }

    // Updates text of Counter
    // Value for submit Button
    public void updateCounterText()
    {
        LemonTotalNumber.text = counterLemon + "";
        SugarTotalNumber.text = counterSugar + "";
        WaterTotalNumber.text = counterWater + "";
        barUpdate();
    }

    // Ingredient Bar Update Logic
    public void barUpdate() 
    {
    // Updates Lemon Bar
        Image imageLemonBar = this.transform.Find("lemonIngredientBar").gameObject.GetComponent<Image>();
        imageLemonBar.sprite = newSprites[counterLemon];
    // Updates Sugar Bar
        Image imageSugarBar = this.transform.Find("sugarIngredientBar").gameObject.GetComponent<Image>();
        imageSugarBar.sprite = newSprites[counterSugar];
    // Updates Water Bar
        Image imageWaterBar = this.transform.Find("waterIngredientBar").gameObject.GetComponent<Image>();
        imageWaterBar.sprite = newSprites[counterWater];
    }

    // Submit Button Logic
    public void submitButton1()
    {
        // Debug.Log("Submit Pressed");
        totalLemons = counterLemon;
        totalSugar = counterSugar;
        totalWater = counterWater;
        openConfirmationWindow();
    }
    public void confirmStart() 
    {
        Debug.Log("Confirm");
    }
    // Sprite Definition
    public Sprite[] newSprites;

    //Confirmation Window

    public void yesButton()
    {
        yesClicked();
    }
    public void noButton()
    {
        noClicked();
    }
    // Creating Field for Window
    [SerializeField] private ConfirmationWindow2 confirmationWindow1;
    private void openConfirmationWindow()
    {
        confirmationWindow1.gameObject.SetActive(true);
        confirmationWindow1.yesButton.onClick.AddListener(yesClicked);
        confirmationWindow1.noButton.onClick.AddListener(noClicked);
    }

    private void yesClicked()
    {
        LemonadeRecipe recipe = (LemonadeRecipe) GameObject.Find("PlayerLemonadeRecipe").GetComponent<LemonadeRecipe>();
        recipe.SetLemonContent(totalLemons);
        recipe.SetSugarContent(totalSugar);
        recipe.SetWaterContent(totalWater);
        DontDestroyOnLoad(recipe);
        GameObject finalRound = GameObject.Find("FinalLevel");
        Debug.Log(finalRound);
        if (finalRound)
        {
            sceneChange.GameplaySceneFinalRound();
        }
        else
        {
            sceneChange.GameplaySceneFirstRound();
        }
        confirmationWindow1.gameObject.SetActive(false);
    }

    private void noClicked()
    {
        confirmationWindow1.gameObject.SetActive(false);
        Debug.Log("No Clicked");
    }



    // Start is called before the first frame update
    void Start()
        {
            newSprites = Resources.LoadAll<Sprite>("menuProgressBarLarge");
            counterLemon = 0;
            counterSugar = 0;
            counterWater = 0;
            sceneChange = (SceneChangeScript) GameObject.Find("confirmationCanvas1").GetComponent<SceneChangeScript>();
        }
        // Update is called once per frame
        void Update()
        {

        }
}


