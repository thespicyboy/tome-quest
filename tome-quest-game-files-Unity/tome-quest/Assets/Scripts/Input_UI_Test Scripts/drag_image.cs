using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class drag_image : MonoBehaviour, IDragHandler, IEndDragHandler

{

    public float nothing = (0.0f);
    public Image this_object;


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(150, -150);

    }

 

    void Update()
    {
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

