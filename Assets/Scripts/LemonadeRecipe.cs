using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeRecipe : MonoBehaviour
{

    // Recipie Variables
    private int lemonContent;
    private int sugarContent;
    private int waterContent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Retrieve lemonContent value
    public int GetLemonContent() 
    {
        return lemonContent;
    }

    // Set lemonContent value
    // @param lemonValue - the value input by the customer or lemonade stand
    public void SetLemonContent(int lemonValue) 
    {
        lemonContent = lemonValue;
    }

    // Get sugarContent value
    public int GetSugarContent() 
    {
        return sugarContent;
    }

    // Set sugarContent value
    // @param sugarValue - the value input by the customer or lemonade stand
    public void SetSugarContent(int sugarValue) 
    {
        sugarContent = sugarValue;
    }

    // Get waterContent value
    public int GetWaterContent() 
    {
        return waterContent;
    }

    // Set waterContent value
    // @param waterValue - the value input by the customer or lemonade stand
    public void SetWaterContent(int waterValue) 
    {
        waterContent = waterValue;
    }

    // Assign player lemonade recipe from menu
    public void AssignPlayerLemonadeRecipe() 
    {
        LemonadeRecipe recipe = GameObject.Find("PlayerLemonadeRecipe").GetComponent<LemonadeRecipe>();
        this.SetLemonContent(recipe.GetLemonContent());
        this.SetSugarContent(recipe.GetSugarContent());
        this.SetWaterContent(recipe.GetWaterContent());
    }
}
