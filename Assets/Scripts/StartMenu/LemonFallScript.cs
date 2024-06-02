using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonFallScript : MonoBehaviour
{

    //Variables for Lemon Movement
    public float fallSpeed;
    public float ySquareValue;
    public float yLemonValue;
    public float xLemonValue;


    // Start is called before the first frame update
    void Start()
    {
        xLemonValue = gameObject.transform.position.x;
        yLemonValue = gameObject.transform.position.y;
        ySquareValue = GameObject.Find("resetSquare").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * fallSpeed);

        if (ySquareValue > gameObject.transform.position.y) 
        {
            gameObject.transform.position = new Vector3 (xLemonValue, yLemonValue,0);
        }
        
        
    }
}
