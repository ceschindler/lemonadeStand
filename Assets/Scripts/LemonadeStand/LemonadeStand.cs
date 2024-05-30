using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeStand : MonoBehaviour
{
    // Private variable recipe
    // If we need access to this at some point, create get/set methods
    private LemonadeRecipe recipe;
    // Start is called before the first frame update
    void Start()
    {
        // Add recipe component to LemonadeStand GameObject
        recipe = gameObject.AddComponent<LemonadeRecipe>();

        // Create Lemonade Stand Recipe randomly
        recipe.SetLemonContent(Random.Range(0, 11));
        recipe.SetSugarContent(Random.Range(0, 11));
        recipe.SetWaterContent(Random.Range(0, 11));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
