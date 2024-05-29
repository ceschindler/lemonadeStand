using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void startMenuScene() 
    {
        SceneManager.LoadScene("StartMenuScene");
    }
    public void ingredientsSelectionScene()
    {
        SceneManager.LoadScene("IngredientSelectionScene");
    }
    public void gameplayScene()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
