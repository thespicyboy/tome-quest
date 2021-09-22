using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    public float time = 0f;
    public float max_time;
    public bool action;
    
    void Start()
    {
        time = max_time;
        action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >=  0 && action == false)
        {
            time -= (Time.deltaTime);
            
            
        }
    }
}
