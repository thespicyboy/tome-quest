using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class update_position : MonoBehaviour
{

    private Player_combat player_combat;
    private InputAction action_perform;
    Vector2 joystick;
    public Image this_object;


    private void Awake()
    {
        player_combat = new Player_combat();
    }


    private void OnEnable()
    {
        action_perform = player_combat.Player.action_perform;
        player_combat.Enable();
    }


    private void OnDisable()
    {
        player_combat = new Player_combat();
        player_combat.Disable();
    }



    private void FixedUpdate()
    {

        joystick = action_perform.ReadValue<Vector2>();
        //print(joystick);
        GetComponent<RectTransform>().anchoredPosition = new Vector2 (joystick.x * GetComponentInParent<RectTransform>().rect.width/2 , joystick.y * GetComponentInParent<RectTransform>().rect.height/2) ;

    
       
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
