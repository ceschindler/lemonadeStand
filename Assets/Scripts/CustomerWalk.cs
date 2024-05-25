using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWalk : MonoBehaviour
{
    public float moveSpeed;
    private float originalSpeed;
    public float horizontalMovement;
    public float verticalMovement;

    private bool isPaused;
    public float xPosition;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        originalSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        xPosition = transform.position.x;
        Debug.Log(xPosition);
        if (Input.GetKey("space")) 
        {
            Debug.Log("Space presssed");
            moveSpeed = 0;
            isPaused = true;
        } else if (Input.GetKey("up"))
        {
            moveSpeed = originalSpeed;
            isPaused = false;
        }
        
        if (xPosition == 0 && !isPaused) 
        {
            isPaused = true;
            for (int i = 0; i < 300; i++) 
            {
                moveSpeed = 0;
                transform.Translate(new Vector3(0, 0, 0));
                // Pausing Customer
                if (i % 100 == 0) 
                {
                    Debug.Log(i);
                }
            }
            isPaused = false;
            transform.Translate(Time.deltaTime, 0, 0);
        } 
        else 
        {
            transform.Translate(new Vector3(horizontalMovement, verticalMovement, 0) * moveSpeed);
        }
    }
}
