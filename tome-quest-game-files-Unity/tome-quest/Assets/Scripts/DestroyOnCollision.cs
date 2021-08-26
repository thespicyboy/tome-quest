using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;

    [SerializeField]
    bool bDestroySelf = false;

    [SerializeField]
    bool bDestroyOther = false;
    
    // Destroy object on Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
        {
            if (bDestroySelf)
                Destroy(this.gameObject);

            if (bDestroyOther)
                Destroy(collision.gameObject);
        }
    }
}
