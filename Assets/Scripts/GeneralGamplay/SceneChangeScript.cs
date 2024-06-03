using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void StartMenuScene() 
    {
        
        SceneManager.LoadScene("StartMenu");
    }

    public void IntroStoryScene()
    {
        SceneManager.LoadScene("IntroStoryScene");
    }

    public void LemonadeStandNameScene()
    {
        SceneManager.LoadScene("LemonadeStandNameScene");
    }
    public void IngredientsSelectionScene()
    {
        
        SceneManager.LoadScene("IngredientSelectionScene");
    }
    public void GameplaySceneFinalRound()
    {
        SceneManager.LoadScene("GameplaySceneFinalRound");
    }
    public void GameplaySceneFirstRound()
    {
        SceneManager.LoadScene("GameplaySceneFirstRound");
    }
    public void PostRoundScene(string roundName)
    {
        if (roundName == "FirstRound")
        {
            SceneManager.LoadScene("PostRoundRecapFirstRound");
        }
        else 
        {
            SceneManager.LoadScene("PostRoundRecapFinalRound");
        }
        
    }
}
