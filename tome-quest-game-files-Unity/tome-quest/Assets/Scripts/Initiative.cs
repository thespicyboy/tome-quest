using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initiative : MonoBehaviour
{

    public float f_initiative;
    private Rect dimensions;
    private Vector3 p_initiative;
    public float max_action_time;
    public float action_time;

    void Start()
    {
        p_initiative = GetComponent<RectTransform>().anchoredPosition;
        dimensions = GetComponentInParent<stupid_dimensions>().bar_dimensions;
        p_initiative.x = ((f_initiative * dimensions.width ) / GetComponentInParent<Slider>().maxValue);
        GetComponent<RectTransform>().anchoredPosition = p_initiative;

      

        action_time = max_action_time;
        

    }

     void Update()
    {
        
        // if the turn bar reaches a players turn, stop the counter by setting action = true, also compensate for the rounding by seeting slider = f_initiative
        if ((int)GetComponentInParent<stupid_dimensions>().current_bar_position == f_initiative)
        {
            GetComponentInParent<Timers>().action = true;
            GetComponentInParent<Slider>().value = f_initiative;
            action_time = max_action_time;
        }

         // start the action timer 
        if (GetComponentInParent<Timers>().action == true)
        {
            if (action_time >= 0)
            {
                action_time -= Time.deltaTime;
                print(action_time);
            }
        }
        // if the action timer is done, restart the turn timer by setting action = false, and pushing the current_bar_position just a nudge  
        if (action_time < 0 && GetComponentInParent<Timers>().action == true)
        {
            GetComponentInParent<Timers>().action = false;
            //GetComponentInParent<stupid_dimensions>().current_bar_position = GetComponentInParent<stupid_dimensions>().current_bar_position + 1f;
        }

        print(GetComponentInParent<Timers>().action);
    }

}
