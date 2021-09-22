using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class stupid_dimensions : MonoBehaviour
{
    public Rect bar_dimensions;
    public float current_bar_position;



    // Start is called before the first frame update
    void Start()
    {
        bar_dimensions = GetComponent<RectTransform>().rect;
        current_bar_position = GetComponent<Slider>().maxValue;
        GetComponent<Slider>().value = current_bar_position;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        current_bar_position = GetComponentInParent<Timers>().time * GetComponentInParent<Slider>().maxValue / GetComponentInParent<Timers>().max_time;
        GetComponent<Slider>().value = Mathf.Round(current_bar_position * 100.0f) *0.01f;
        

    }
}
