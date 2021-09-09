using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour 
{
    // This is a simple timer that we will use to define the shape of "Turn Order Bar"\\
           // Eventually Turn length will be the sum of each trun action\\
  
    public float turn_length;
    public float time_remaining;
    public bool timer_is_running = false;
    public Image this_object;

    public GameObject Opening_Cinematic_Timer;
    public bool timer_Start;


    void Start()
    {
        time_remaining = 0;
        timer_is_running = true;
        
        
    }

    
    
    void FixedUpdate()
    {
        timer_Start = Opening_Cinematic_Timer.GetComponent<timer_start>().intro_timer;
        //print(timer_Start);
        if (timer_Start == false)
        {


            if (timer_is_running == true)
            {
                if (time_remaining < turn_length)
                {
                    time_remaining += Time.deltaTime;
                }
            }

            //print(time_remaining);
        }

        if (GetComponentInParent<timer_start>().intro_timer == true)
        {
            this_object.CrossFadeAlpha(0f, 0.0f, false);
        }
        else
        {
            this_object.CrossFadeAlpha(1f, 0.0f, false);
        }


    }

}
