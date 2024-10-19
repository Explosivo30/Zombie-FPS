using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]LayerMask layerMask;
    [SerializeField]private float radius;

    private void Start()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, radius, layerMask);
        //Todo: Perform Raycast to not affect colliders behind other
        // colliders

        foreach(Collider c in collidersInRange)
        {

            c.GetComponent<TargetBase>()?.NotifyExplosion(this);
        }
        Destroy(gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
