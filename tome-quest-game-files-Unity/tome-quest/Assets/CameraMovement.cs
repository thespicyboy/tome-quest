using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0f;
    private float startTime;

    private float journeyLength;

    private GameObject tempMarker;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        PanCamera(25, true);
    }

    // Update is called once per frame
    void Update()
    {

        // ZoomCamera(startMarker.position, endMarker.position);
        ZoomCamera(startMarker.position, tempMarker.transform.position);
    }

    public void UpdateCameraPostion()
    {
        startMarker = gameObject.transform;
    }

    public void ZoomCamera(Vector3 start, Vector3 end)
    {
        float distCovered = (Time.time - startTime) * speed;

        float fractionofJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(start, end, fractionofJourney);
    }

    public void PanCamera(int distance, bool direction) //true = right
    {
        Vector3 tempPostion = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        if (direction == true)
        {
            tempPostion.x = gameObject.transform.position.x + distance;
        }
        else
        {
            tempPostion.x = gameObject.transform.position.x - distance;
        }




        tempMarker = new GameObject("tempMarker");

        tempMarker.transform.position = tempPostion;

        UpdateCameraPostion();
        ZoomCamera(startMarker.position, tempMarker.transform.position);





    }



}


