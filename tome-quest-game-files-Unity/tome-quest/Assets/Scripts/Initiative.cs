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
    private float action_time;
    public float time_variable = 0.5f;
    private bool turn_has_started = false;

    void Start()
    {
        p_initiative = GetComponent<RectTransform>().anchoredPosition;
        dimensions = GetComponentInParent<stupid_dimensions>().bar_dimensions;
        p_initiative.x = ((f_initiative * dimensions.width) / GetComponentInParent<Slider>().maxValue);
        GetComponent<RectTransform>().anchoredPosition = p_initiative;
        print(GetComponentInParent<Slider>().maxValue);

        action_time = max_action_time;


    }

    void Update()
    {
        {
            print(turn_has_started);
            // if the turn bar reaches a players turn, stop the counter by setting action = true, also compensate for the rounding by seeting slider = f_initiative
            if (GetComponentInParent<stupid_dimensions>().current_bar_position <= f_initiative && turn_has_started == false)
            {
                GetComponentInParent<Timers>().action = true;
                GetComponentInParent<Slider>().value = f_initiative;
                action_time = max_action_time;
                turn_has_started = true;
            }

            // start the action timer 
            if (GetComponentInParent<Timers>().action == true)
            {
                if (action_time >= 0)
                {
                    action_time -= Time.deltaTime * time_variable;
                    //print(action_time);
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
}