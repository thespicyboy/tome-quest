using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pass_the_info : MonoBehaviour
{

    public static GameObject this_object;

    // Start is called before the first frame update
    public void Awake()
    {

        // Pre-fabs dont exactly exist in the scene as i understand it, so you need to store the gameobject during runtime...makes senes honestly
        this_object = this.gameObject;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
