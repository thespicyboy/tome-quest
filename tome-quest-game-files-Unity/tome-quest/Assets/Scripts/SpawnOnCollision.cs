using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;

    [SerializeField]
    bool bSpawnSelf = false;

    [SerializeField]
    bool bSpawnOther = false;
    
    [SerializeField]
    GameObject goCreate; //Game Object to be spawned

    // Destroy object on Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
        {
            if (bSpawnSelf)
                //creates new instance of supplied game object at this position
                Instantiate(goCreate, transform.position, Quaternion.identity);

            if (bSpawnOther)
                //creates new instance of supplied game object at that position
                Instantiate(goCreate, collision.transform.position, Quaternion.identity);
        }
    }
}
