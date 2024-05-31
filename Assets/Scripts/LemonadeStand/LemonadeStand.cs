using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeStand : MonoBehaviour
{
    // Private variable recipe
    // If we need access to this at some point, create get/set methods
    private LemonadeRecipe recipe;
    private int customerCount;
    // Start is called before the first frame update
    void Start()
    {
        // Add recipe component to LemonadeStand GameObject
        recipe = gameObject.AddComponent<LemonadeRecipe>();
        
        if (gameObject.name == "PlayerLemonadeStand")
        {
            recipe.AssignPlayerLemonadeRecipe();
        }
        else
        {
            // Create Lemonade Stand Recipe randomly
            recipe.SetLemonContent(Random.Range(0, 11));
            recipe.SetSugarContent(Random.Range(0, 11));
            recipe.SetWaterContent(Random.Range(0, 11));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get Customer visit Count
    public int GetCustomerCount()
    {
        return customerCount;
    }

    // Set Customer visit count
    public void SetCustomerCount(int count)
    {
        customerCount = count;
    }
}
