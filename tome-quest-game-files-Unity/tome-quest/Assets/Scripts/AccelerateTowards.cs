using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateTowards : MonoBehaviour
{
    [SerializeField]
    Transform transTowards;

    [SerializeField]
    float fSpeed;

    Rigidbody rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if (transTowards == null)
        {
            //search for first transform of Game Object with PlayerControlledVelocity script attached to it
            transTowards = FindObjectOfType<AddPlayerControlledVelocity>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //apply acceleration towards target
        rigid.velocity += (transTowards.position - transform.position).normalized * fSpeed * Time.deltaTime;
    }
}
