using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class speedUpScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool buttonPressed;
    public float doubleTime;
    
    void Update()
    {
        // If statement to increment speed if button is pressed.
        if (buttonPressed) 
        { 
            Time.timeScale = doubleTime;
        }
        else 
        {
            Time.timeScale = 1;   
        }

    }
    // Handles if button is being pressed Down or not
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) 
    {
        // Makes bool buttonPressed return True
        buttonPressed = true;
    }
    // Handles if button is being pressed Down or not
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        // Makes bool buttonPressed return False
        buttonPressed = false;  
    }
}
