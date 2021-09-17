using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject goCreate; //Game Object to be spawned

    [SerializeField]
    float fTimeIntervals; //Time Interval of spawn

    [SerializeField]
    Vector3 v3SpawnPosJitter; //Magnitude of position randomness, from parent object in scene

    float fTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        fTimer = fTimeIntervals;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer -= Time.deltaTime; //reduce timer until next object spawn
        if (fTimer <= 0) //when timer counts down to zero...
        {
            fTimer = fTimeIntervals; //reset spawn timer

            Vector3 v3SpawnPos = transform.position;

            //randomize spawn position, scale of randomness is provided by v3SpawnPosJitter
            v3SpawnPos += Vector3.right * v3SpawnPosJitter.x * (Random.value - 0.5f);
            v3SpawnPos += Vector3.forward * v3SpawnPosJitter.z * (Random.value - 0.5f);
            v3SpawnPos += Vector3.up * v3SpawnPosJitter.y * (Random.value - 0.5f);

            //creates new instance of supplied game object with position and rotation
            Instantiate(goCreate, v3SpawnPos, Quaternion.identity);
        }
        
    }
}
