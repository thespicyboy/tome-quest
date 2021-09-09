using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class is_visible : MonoBehaviour
{

    public Image this_object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
