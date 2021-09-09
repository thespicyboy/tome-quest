using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Set_Bar_Position : MonoBehaviour
{

    public GameObject Turn_Order_Bar;
    public float action_position;
    public float action_turn_length;
    Vector3 current_state;
    public float current_x;
    public Image this_object;


    
    void Start()
    {
        current_state = new Vector3(0.0f, 50.0f, 0.0f);
    }

   
    void Update()
    {
        action_position = Turn_Order_Bar.GetComponent<timer>().time_remaining;
        action_turn_length = Turn_Order_Bar.GetComponent<timer>().turn_length;



        current_x = 1 - (action_position / action_turn_length);
        current_state.x = -current_x;
        print(current_x);
        GetComponent<Image>().fillAmount = current_x;

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
