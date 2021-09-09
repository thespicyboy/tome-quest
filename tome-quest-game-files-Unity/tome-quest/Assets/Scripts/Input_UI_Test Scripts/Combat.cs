using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public bool opening_cinematic;
    public float intro_on;
    public Text this_text;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        opening_cinematic = GetComponentInParent<timer_start>().intro_timer;





        if (opening_cinematic == false)
        {

            this_text.CrossFadeAlpha(0f,0.2f, false);
           
           

        }

    }
}
