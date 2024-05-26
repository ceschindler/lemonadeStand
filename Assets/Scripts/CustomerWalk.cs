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
    public float verticalMovement;

    // Customer pause variables for getting lemonade
    private bool isPaused;
    private float timer = 0.0f;
    public float customerWaitTime;

    // Customer stopping locations
    private float[] locations;
    private float stoppingLocation;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        originalSpeed = moveSpeed;
        locations = FindPossibleStoppingPointsForCustomers();
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

    // Array of possible stopping points for the customer
    public float[] FindPossibleStoppingPointsForCustomers() 
    {
        // Create array to store all possible stopping locations
        float[] locations = new float[4];

        // Iterate over all objects tagged with "Customer" in the scene
        // These are small boxes hidden inside the lemonade stand
        int index = 0;
        foreach (GameObject location in GameObject.FindGameObjectsWithTag("Customer"))
        {
            // Add x position of GameObject to array of possible locations
            locations[index] = location.transform.position.x;
            index++;
        }
        return locations;
    }

    // Have customer choose a random stopping location from the list of possible locations
    public float ChooseStoppingLocation() 
    {
        // Random random = new Random();
        int location = Random.Range(0, locations.Length);
        return locations[location];
    }
}
