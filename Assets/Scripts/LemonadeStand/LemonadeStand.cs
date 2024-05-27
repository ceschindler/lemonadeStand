using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeStand : MonoBehaviour
{
    private LemonadeRecipe recipe;
    // Start is called before the first frame update
    void Start()
    {
        recipe = GetComponent<LemonadeRecipe>();
        // Create Lemonade Stand Recipe randomly
        // recipie.lemonContent = Random.Range(0, 11);
        // recipie.sugarContent = Random.Range(0, 11);
        // recipie.waterContent = Random.Range(0, 11);
        recipe.lemonContent = 10;
        recipe.sugarContent = 10;
        recipe.waterContent = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
