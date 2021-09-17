using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameraWithButton : MonoBehaviour
{
    [SerializeField]
    KeyCode keyToggleCamera;

    public Camera primaryCamera;
    public Camera secondaryCamera;

    // 
    void Start()
    {
        primaryCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToggleCamera))
        {
            primaryCamera.enabled = !primaryCamera.enabled;
            secondaryCamera.enabled = !secondaryCamera.enabled;
        }
    }
}
