using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Transform startMarker; // starting spot
    public Transform endMarker; // ending spot
    public Transform target;
    public float speed = 1.0f;
    private float startTime; // starting time

    private float journeyLength; //distance between to points

    private GameObject tempMarker; //temp location marker for paning



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target 1").transform;

        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        
        
    }

    // Update is called once per frame
    void Update()
    {

        RotateAroundTarget(target);
     
    }

    public void UpdateCameraPostion()
    {
        startMarker = gameObject.transform; //resests the starting location to current location
    }

    public void ZoomCamera(Vector3 start, Vector3 end) //move a bit each frame
    {
        float distCovered = (Time.time - startTime) * speed;

        float fractionofJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(start, end, fractionofJourney);
    }

    public void PanCamera(int distance, bool direction) //true = right //creates a temp obj to slowly move to
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

    public void RotateAroundTarget(Transform target)
    {

        transform.LookAt(target);
        transform.Translate((Vector3.right * speed) * Time.deltaTime);
    }

}


