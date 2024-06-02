using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostRoundStats : MonoBehaviour
{
    // Lemonade stands and customer counts
    private (string, int)[] lemonadeStandCounts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get lemonade stand counts
    public (string, int)[] GetLemonadeStandCounts()
    {
        return lemonadeStandCounts;
    }
    // Set lemonade stand counts
    public void SetLemonadeStandCounts((string, int)[] roundCounts)
    {
        lemonadeStandCounts = roundCounts;
    }
}
