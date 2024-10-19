using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    Animator animator;
    Vector3 oldPosition;

    public float threshold = 1f / 50f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementDistance = Vector3.Distance(oldPosition, transform.position);
        if ((movementDistance > threshold))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
