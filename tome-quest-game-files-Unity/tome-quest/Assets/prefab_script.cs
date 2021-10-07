using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefab_script : MonoBehaviour
{
    public float initiative;
    private float current_time;
    private float max_time;
    private GameObject slider;


   


    void Start()
    {

        max_time = pass_the_info.this_object.GetComponent<Slider>().maxValue;


    }

    // Update is called once per frame
    void Update()
    {
        current_time = Turn_Manager.time;
        //print(current_time);

    }
}
