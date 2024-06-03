using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    private bool isFinalLevel;

    // Start is called before the first frame update
    void Start()
    {
        isFinalLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get finalLevel boolean
    public bool GetIsFinalLevel()
    {
        return isFinalLevel;
    }

    // Set final Level boolean
    public void SetIsFinalLevel(bool value)
    {
        isFinalLevel = value;
    }
}
