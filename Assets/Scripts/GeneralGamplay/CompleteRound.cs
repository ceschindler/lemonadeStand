using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteRound : MonoBehaviour
{
    // Array of all customers in the scene
    private Dictionary<string, bool> customers;

    // x location of finish block;
    private float finishBlockXLocation;

    // Reference to scene change script
    private SceneChangeScript sceneChange;

    // Number of Customers that have finished walking off scene
    private int finishedCustomers;

    // Lemonade stands and their corresponding customer counts
    private (string, int)[] lemonadeStandCustomerCounts;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize scene change script in object
        sceneChange = (SceneChangeScript) gameObject.GetComponent<SceneChangeScript>();

        // Grab all the customers in the scene
        customers = new Dictionary<string, bool>();
        GetAllCustomersInScene();

        // x Location of finish block
        finishBlockXLocation = gameObject.transform.position.x;

        // Initialize finished customers to 0
        finishedCustomers = 0;

        // Grab lemonade Stands and pull their customer counts
        lemonadeStandCustomerCounts = GetLemonadeStandCounts();
    }

    // Update is called once per frame
    void Update()
    {
        // Copy the keys from Dictionary so I can modify the dictionary within the loop
        List<string> keys = new List<string>(customers.Keys);
        foreach (string customer in keys)
        {
            // Check if current customer has already passed the finished block
            if (customers[customer] == false)
            {
                // Customer has not passed finish block yet, check position
                if (GameObject.Find(customer).transform.position.x > finishBlockXLocation)
                {
                    // Customer has passed finish block, mark them off and increment
                    customers[customer] = true;
                    finishedCustomers++;
                }
            }
        }

        // Compare finished customers to the total number of customers
        if (finishedCustomers == customers.Count)
        {
            // Grab corresponding counters for lemonade stands and
            // save them to display in post game recap
            // LemonadeRecipe recipe = (LemonadeRecipe) GameObject.Find("PlayerLemonadeRecipe").GetComponent<LemonadeRecipe>();
            PostRoundStats postRoundStats = (PostRoundStats) GameObject.Find("PostRoundStats").GetComponent<PostRoundStats>();
            postRoundStats.SetLemonadeStandCounts(lemonadeStandCustomerCounts);
            DontDestroyOnLoad(postRoundStats);
            // All customers have passed the finish block, show post game recap
            sceneChange.PostRoundScene();
        }
    }

    // Quickly add all customers from the scene into the dictionary [Customer name, Are they finished?]
    public void GetAllCustomersInScene()
    {
        foreach (GameObject customer in GameObject.FindGameObjectsWithTag("Customer"))
        {
            customers.Add(customer.name, false);
        }
    }

    // Grab lemonade stands and their customer counts
    public (string, int)[] GetLemonadeStandCounts()
    {
        // Create a Tuple array to store lemonade stand names and their corresponding customer counts
        (string, int)[] lemonadeStandCounts = new (string, int)[2];

        // Iterate over all objects tagged with "LemonadeStand" in the scene
        // and add their stand name and customer count to the array
        int index = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("LemonadeStand"))
        {
            LemonadeStand lemonadeStand = go.GetComponent<LemonadeStand>();
            Debug.Log(go.name + " had " + lemonadeStand.GetCustomerCount() + " customers");
            lemonadeStandCounts[index] = (go.name, lemonadeStand.GetCustomerCount());
            index++;
        }
        return lemonadeStandCounts;
    }
}
