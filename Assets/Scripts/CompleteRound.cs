using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteRound : MonoBehaviour
{
    // Array of all customers in the scene
    private GameObject[] customers;

    // x location of finish block;
    private float finishBlockXLocation;

    // Reference to scene change script
    private SceneChangeScript sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize scene change script in object
        sceneChange = (SceneChangeScript) gameObject.GetComponent<SceneChangeScript>();
        // Grab all the customers in the scene
        customers = GetAllCustomersInScene();
        // x Location of finish block
        finishBlockXLocation = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // boolean to trigger post game recap state
        bool isFinished = false;
        // Number of customers that need to finish the round
        int numberOfCustomers = customers.Length;

        // Check how many customers have passed the finish block
        // If this gets too slow or doesn't execute fast enough,
        // we can just remove all of them from the array until the array is empty
        int finishedCustomers = 0;
        foreach(GameObject customer in customers)
        {
            if (customer.transform.position.x > finishBlockXLocation)
            {
                finishedCustomers++;
            }
        }

        // Compare finished customers to the total number of customers
        if (finishedCustomers == numberOfCustomers)
        {
            isFinished = true;
        }

        // All customers have reached the finish block
        if (isFinished)
        {
            sceneChange.PostRoundScene();
        }
    }

    public GameObject[] GetAllCustomersInScene() 
    {
        return GameObject.FindGameObjectsWithTag("Customer");
    }
}
