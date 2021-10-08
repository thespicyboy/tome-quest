using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputCursor : MonoBehaviour
{
    public GameObject inputBackground;
    
    float targetRadius;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        float inputBackgroundWidth = inputBackground.GetComponent<RectTransform>().sizeDelta.x;
        targetRadius = inputBackgroundWidth / 2;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputCoord = new Vector2(horizontalInput, verticalInput);
        Vector2 clampedInputCoord = Vector2.ClampMagnitude(inputCoord, 1.0f);

        Vector2 inputPosition = clampedInputCoord * targetRadius;
        rectTransform.anchoredPosition = inputPosition;
    }
}
