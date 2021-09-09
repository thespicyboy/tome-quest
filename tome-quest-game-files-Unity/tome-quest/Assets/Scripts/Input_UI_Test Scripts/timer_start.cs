using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer_start : MonoBehaviour
{
    [SerializeField]
    private float intro_length;
    private float time_remaining;
    public bool timer_is_running = false;



    public bool intro_timer = true;

    // Start is called before the first frame update
    void Start()
    {
        time_remaining = 0;
        timer_is_running = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            if (timer_is_running == true)
            {
                if (time_remaining < intro_length)
                {
                    time_remaining += Time.deltaTime;
                }
            }

            if (time_remaining >= intro_length)
        {
            
            intro_timer = false;
        }


       //print(time_remaining);
       //print(intro_timer);



    }
}
