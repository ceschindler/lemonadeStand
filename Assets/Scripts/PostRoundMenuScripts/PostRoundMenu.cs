using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostRoundMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PostRoundStats postRoundStats = (PostRoundStats) GameObject.Find("PostRoundStats").GetComponent<PostRoundStats>();
        Debug.Log(postRoundStats);
        foreach ((string, int) stat in postRoundStats.GetLemonadeStandCounts())
        {
            Debug.Log(stat.Item1 + " had " + stat.Item2 + " customers in the last round");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
