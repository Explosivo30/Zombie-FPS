using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] float detectionRadious = 10f;
    [SerializeField] float detectionAngle = 90f;
    [SerializeField] Transform pou;
    public bool playerInside = false;
    IABehaviour ia;

    private void Awake()
    {
        ia = GetComponent<IABehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        LookForPlayer();
        
    }


    private void LookForPlayer()
    {
        Vector3 enemyPos = transform.position;
        Vector3 toPlayer = pou.transform.position - enemyPos;
        toPlayer.y = 0;
        if(toPlayer.magnitude <= detectionRadious)
        {
            //Debug.Log("Player is Nearby");
            //Lo siguiente significa"Esta dentro del triangulo de vision"
            if (Vector3.Dot(toPlayer.normalized, transform.forward) >
                     Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad))
            {
                //Debug.Log("Player detected inside");
                playerInside = true;
            }
            else
            {
                //playerInside = false;
                ia.MoveToPoints();
                Debug.Log("Esta fuera de rango");
            }
        }else
        {
            playerInside = false;
            ia.MoveToPoints();
            Debug.Log("Ya no lo veo");
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Color c = new Color(0.8f, 0, 0, 0.4f);
        UnityEditor.Handles.color = c;

        Vector3 rotatedFordward = Quaternion.Euler(0, -detectionAngle * 0.5f, 0) * transform.forward;

       UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, rotatedFordward, detectionAngle, detectionRadious);

    }

}
