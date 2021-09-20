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

        Vector2 position = new Vector2(
            horizontalInput * halfDisplaySizePx,
            verticalInput * halfDisplaySizePx
        );

        rectTransform.anchoredPosition = position;
    }
}
