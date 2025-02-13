using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LemonadeStand : MonoBehaviour
{
    // Player stand name
    private string playerStandName;
    // Private variable recipe
    private LemonadeRecipe recipe;

    // Number of customers that visited the stand
    private int customerCount;
    // Start is called before the first frame update
    void Start()
    {
        // Add recipe component to LemonadeStand GameObject
        recipe = gameObject.AddComponent<LemonadeRecipe>();

        // Variables for lemonade stand name and text
        TMP_Text lemonadeStandText;
        string lemonadeStandName;
        if (gameObject.name == "PlayerLemonadeStand")
        {
            // Assign player recipe from menu
            recipe.AssignPlayerLemonadeRecipe();

            // Update Lemonade stand name from text field
            lemonadeStandText = (TMP_Text) GameObject.Find("PlayerLemonadeStandText").GetComponent<TMP_Text>();
            lemonadeStandName = GameObject.Find("LemonadeStandName").GetComponent<GrabLemonadeStandName>().GetPlayerLemonadeStandName();
            lemonadeStandText.text = lemonadeStandName;
        }
        else
        {
            if (gameObject.name == "OpponentLemonadeStand1")
            {
                // Update Lemonade stand name from text field
                lemonadeStandText = (TMP_Text) GameObject.Find("OpponentLemonadeStandText1").GetComponent<TMP_Text>();
                lemonadeStandName = GameObject.Find("LemonadeStandName").GetComponent<GrabLemonadeStandName>().GetOpponentLemonadeStandName(1);
            }
            else
            {
                // Update Lemonade stand name from text field
                lemonadeStandText = (TMP_Text) GameObject.Find("OpponentLemonadeStandText2").GetComponent<TMP_Text>();
                lemonadeStandName = GameObject.Find("LemonadeStandName").GetComponent<GrabLemonadeStandName>().GetOpponentLemonadeStandName(2);
            }

            // Assign lemonade stand name to "sign" above stand
            lemonadeStandText.text = lemonadeStandName;
            
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
