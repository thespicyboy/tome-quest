using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraTarget : MonoBehaviour
{
    public GameObject[] characterTargets;
    public float holdTimeSec = 3;
    public float targetHeight = 1.5f;

    public float rotateSpeed = 5;

    private float elapsedHoldTimeSec = 0;
    private int characterTargetIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        elapsedHoldTimeSec += Time.deltaTime;

        bool isTimeToMove = elapsedHoldTimeSec > holdTimeSec;
        if (isTimeToMove)
        {
            elapsedHoldTimeSec = 0;

            characterTargetIndex++;
            if (characterTargetIndex >= characterTargets.Length)
            {
                characterTargetIndex = 0;
            }

            GameObject nextCharacterTarget = characterTargets[characterTargetIndex];
            transform.position = nextCharacterTarget.transform.position;
            transform.Translate(0, targetHeight, 0);
        }

        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
