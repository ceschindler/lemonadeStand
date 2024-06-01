using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWalk : MonoBehaviour
{
    // Customer movement variables
    public float moveSpeed;
    private float originalSpeed;
    private float xPosition;
    public float horizontalMovement;
    public float verticalMovement; // If we want to try to make the customer 'appear' to walk 'up' to the stand

    // Customer pause variables for getting lemonade
    private bool isPaused;
    private float timer = 0.0f;
    public float customerWaitTime;

    // Customer stopping locations
    private float[] locations;
    private float stoppingLocation;

    // Tuple array of all recipes from the lemonade stands
    private (LemonadeRecipe, string)[] lemonadeStandRecipes;

    // Customer specific Lemonade Recipie
    private LemonadeRecipe customerLemonadeRecipe;


    // Start is called before the first frame update
    void Start()
    {
        // Set starting Customer walking values
        isPaused = false;
        originalSpeed = moveSpeed;
        
        // Grab customer LemonadeRecipe from created component in Customer.cs
        customerLemonadeRecipe = (LemonadeRecipe) gameObject.GetComponent<LemonadeRecipe>();

        // Grab all Lemonade Stand Recipes
        lemonadeStandRecipes = FindLemonadeStandRecipes();

        // Grab all possible locations a Customer can stop at
        locations = FindPossibleStoppingPointsForCustomers();

        // Stopping location for this customer
        stoppingLocation = ChooseStoppingLocation();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Grab the x position of the customer at the start of the frame
        xPosition = transform.position.x;

        // Determine if customer is in a valid location to stop for some lemonade
        if ((xPosition > stoppingLocation) && !isPaused) 
        {
            // Stop customer movement and start wait timer
            isPaused = true;
            moveSpeed = 0;
            timer = Time.time;
        } 
        else 
        {
            // If game time is now longer than wait time, and the customer is in a valid stop spot
            // reset their movement speed back to their original speed.
            if ((Time.time > (timer + customerWaitTime)) && isPaused) 
            {
                moveSpeed = originalSpeed;
            }
            
            // Move Customer
            transform.Translate(new Vector3(horizontalMovement, verticalMovement, 0) * moveSpeed);
        }
    }

    // Array of all Lemonade recipes of the Lemonade Stands the 
    // customer could go to.
    public (LemonadeRecipe, string)[] FindLemonadeStandRecipes()
    {
        // Create a Tuple array to store lemonade recipes and their corresponding stand name
        (LemonadeRecipe, string)[] lemonadeRecipes = new (LemonadeRecipe, string)[2];

        // Iterate over all objects tagged with "LemonadeStand" in the scene
        // and add their recipe and name to the array
        int index = 0;
        foreach (GameObject lemonadeStand in GameObject.FindGameObjectsWithTag("LemonadeStand"))
        {
            LemonadeRecipe recipe = lemonadeStand.GetComponent<LemonadeRecipe>();
            lemonadeRecipes[index] = (recipe, lemonadeStand.name);
            index++;
        }
        return lemonadeRecipes;
    }
    // Array of possible stopping points for the customer
    public float[] FindPossibleStoppingPointsForCustomers() 
    {
        // Look for best lemonade stand recipie match
        string standName = FindBestLemonadeRecipeMatch();

        // Create array to store all possible stopping locations
        float[] locations = new float[2];

        // Iterate over all objects tagged with "StoppingPoint" in the scene
        // These are small boxes hidden inside the lemonade stand
        int index = 0;
        foreach (GameObject location in GameObject.FindGameObjectsWithTag("StoppingPoint"))
        {
            // Add x position of LemonadeStands that a customer can stop at.
            if (location.transform.parent.name == standName)
            {
                locations[index] = location.transform.position.x;
                index++;
            }
            else if (standName == "Finish") // If no match, run off screen without stopping
            {
                // This scenario shouldn't happen if Customers match properly to their "best matches"
                // but if we somehow get here, at least it's handled.
                locations[index] = 10;
                locations[index + 1] = 10;
                break;
            }
        }
        return locations;
    }

    // Iterate through Lemonade stands and their recipes and compare them to the Customer
    // recipe preferences to determine best match for lemonade.
    public string FindBestLemonadeRecipeMatch()
    {
        // Lemonade stand name for where the customer will stop
        string bestMatchLemonadeStand = "Finish";

        // Holds the difference in value from customer recipe to lemonade stand's recipe
        // Will update with each "better" match as we loop through stands
        int bestMatchRecipeValue = 30;

        // Iterate and compare lemonade stand recipes to the recipe preference of the customer
        foreach ((LemonadeRecipe, string) lemonadeStandRecipe in lemonadeStandRecipes)
        {
            Debug.Log("Customer recipe - Lemons: " + customerLemonadeRecipe.GetLemonContent()
                    + ", Sugar: " + customerLemonadeRecipe.GetSugarContent() + ", Water: "
                    + customerLemonadeRecipe.GetWaterContent());
            Debug.Log("Lemonade Stand recipe - Lemons: " + lemonadeStandRecipe.Item1.GetLemonContent()
                    + ", Sugar: " + lemonadeStandRecipe.Item1.GetSugarContent() + ", Water: "
                    + lemonadeStandRecipe.Item1.GetWaterContent());
            // Compare values of Customer to Lemonade Stand
            if (customerLemonadeRecipe.GetLemonContent() == lemonadeStandRecipe.Item1.GetLemonContent()
                    && customerLemonadeRecipe.GetSugarContent() == lemonadeStandRecipe.Item1.GetSugarContent()
                    && customerLemonadeRecipe.GetWaterContent() == lemonadeStandRecipe.Item1.GetWaterContent())
            {
                // Record the name of the matching lemonade stand and break out of loop.
                // No need to do more comparisons if there is an exact match
                // TODO: Possible issue if player and opponent have same recipe stats. Write in fix for
                // this situation to default to player stand at all times if this happens.
                bestMatchLemonadeStand = lemonadeStandRecipe.Item2;
                break;
            } 
            else
            {
                // Local variable to hold the current iteration of lemonade stand recipe value
                int currentRecipeValue = 0;

                // Take the absolute value of the difference of each value
                currentRecipeValue += Mathf.Abs(lemonadeStandRecipe.Item1.GetLemonContent() - customerLemonadeRecipe.GetLemonContent());
                currentRecipeValue += Mathf.Abs(lemonadeStandRecipe.Item1.GetSugarContent() - customerLemonadeRecipe.GetSugarContent());
                currentRecipeValue += Mathf.Abs(lemonadeStandRecipe.Item1.GetWaterContent() - customerLemonadeRecipe.GetWaterContent());

                // Compare recipe values and assign name of best match lemonade stand
                if (currentRecipeValue < bestMatchRecipeValue)
                {
                    bestMatchRecipeValue = currentRecipeValue;
                    bestMatchLemonadeStand = lemonadeStandRecipe.Item2;
                }
            }
        }
        
        return bestMatchLemonadeStand;
    }

    // Have customer choose one of two stopping locations from the lemonade stand they
    // matched with
    public float ChooseStoppingLocation() 
    {
        int location = Random.Range(0, locations.Length);
        return locations[location];
    }
}
