using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputCursor : MonoBehaviour
{
    public int displaySizePx = 500;

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        int halfDisplaySizePx = displaySizePx / 2;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputCoord = new Vector2(horizontalInput, verticalInput);
        Vector2 clampedInputCoord = Vector2.ClampMagnitude(inputCoord, 1.0f);

        Vector2 inputPosition = clampedInputCoord * halfDisplaySizePx;
        rectTransform.anchoredPosition = inputPosition;
    }
}
