using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GestureManager : MonoBehaviour
{
    public GameObject gestureTargetPrefab;
    public GameObject inputBackground;
    public GameObject inputCursor;
    public float targetTolerance = 5;

    private int currentTargetIndex = 0;
    private Vector2[] targetPositions;
    private List<GameObject> gestureTargets;
    private RectTransform cursorTransform;

    static Color yellowColor = Color.yellow;
    static Color pinkColor = new Color(1f, 0.38f, 0.56f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        cursorTransform = inputCursor.GetComponent<RectTransform>();

        float inputBackgroundWidth = inputBackground.GetComponent<RectTransform>().sizeDelta.x;
        float targetRadius = inputBackgroundWidth / 2;
        Vector2 targetCorner = targetRadius * Vector2.ClampMagnitude(new Vector2(1, 1), 1.0f);

        targetPositions = new Vector2[]
        {
            new Vector2(-targetRadius, 0),
            new Vector2(-targetCorner.x, -targetCorner.y),
            new Vector2(0, -targetRadius),
            new Vector2(targetCorner.x, -targetCorner.y),
            new Vector2(targetRadius, 0)
        };

        gestureTargets = new List<GameObject>();
        foreach (Vector2 targetPosition in targetPositions)
        {
            GameObject gestureTarget = Instantiate(
                gestureTargetPrefab, inputBackground.transform
            );
            gestureTargets.Add(gestureTarget);

            RectTransform rectTransform = gestureTarget.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(targetPosition.x, targetPosition.y);
        }

        SetTargetColors();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nextTargetPosition = targetPositions[currentTargetIndex];
        Vector2 inputCursorPosition = cursorTransform.anchoredPosition;

        float targetDistance = (nextTargetPosition - inputCursorPosition).magnitude;
        bool isCursorOnTarget = targetDistance < targetTolerance;
        if (isCursorOnTarget)
        {
            currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
        }
        SetTargetColors();
    }

    void SetTargetColors()
    {
        for (int targetIndex = 0; targetIndex < gestureTargets.Count; targetIndex++)
        {
            Color color;
            bool isCurrentTarget = targetIndex == currentTargetIndex;
            if (isCurrentTarget)
            {
                color = pinkColor;
            }
            else
            {
                color = yellowColor;
            }

            GameObject gestureTarget = gestureTargets[targetIndex];
            Image image = gestureTarget.GetComponent<Image>();
            image.color = color;   
        }
        
    }
}
