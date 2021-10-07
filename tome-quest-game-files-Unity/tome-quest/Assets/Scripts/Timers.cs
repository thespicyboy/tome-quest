using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    public float time;
    public float max_time;
    public bool action;
    public float variable_time = 0.1f;
    
    void Start()
    {
        time = max_time;
        action = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time >=  0 && action == false)
        {
            time -= (0.02f);
            print(time);
            
            
        }
    }
}
