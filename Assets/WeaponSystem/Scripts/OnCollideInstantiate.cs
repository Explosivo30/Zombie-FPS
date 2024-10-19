using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideInstantiate : MonoBehaviour
{
    [SerializeField] GameObject prefabInstantiate;
    [SerializeField] bool destroyOnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(prefabInstantiate, transform.position, transform.rotation);
        if(destroyOnCollision)
        {
            Destroy(gameObject);
        }

    }
}
