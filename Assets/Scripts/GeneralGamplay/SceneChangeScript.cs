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
    public void IngredientsSelectionScene()
    {
        
        SceneManager.LoadScene("IngredientSelectionScene");
    }
    public void GameplayScene()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    public void PostRoundScene()
    {
        SceneManager.LoadScene("PostRoundRecap");
    }
}
