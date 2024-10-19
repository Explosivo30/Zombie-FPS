using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABehaviour : WeaponShooterBase
{
    [Header("Points Travel")]
    [SerializeField] Transform points;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    int count = 0;
    [SerializeField] float threshold = 0.2f;
    [Header("AttackPlayer")]
    [SerializeField] Transform target;
    EnemyFOV efov;
    float attackCooldownReset = 0.2f;
    [SerializeField] AudioSource audioPlay;

    [SerializeField] LayerMask layer;
    
    //[SerializeField] float enemyDamage = 5;
    [SerializeField] float attackCooldown = 2f;
    [SerializeField] float enemyHealth = 20;
    [SerializeField] Transform cannonBarrel;

    
    
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //inside = GetComponentInChildren<PlayerInside>();
        navMeshAgent.SetDestination(points.GetChild(count).transform.position);
        
        efov = GetComponent<EnemyFOV>();

    }

    private void FixedUpdate()
    {
        if (efov.playerInside == false)
        {
            MoveToPoints();
        }
        else
        {
            AttackRange();
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        attackCooldown = attackCooldown - Time.deltaTime;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    
    void AttackRange()
    {
        if (efov.playerInside == false)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = target.position;
        }
        else if (efov.playerInside == true)
        {
            navMeshAgent.isStopped = true;
            if (attackCooldown <= 0f)
            {
                RaycastHit hit;
                //Disparamos
                Vector3 playerDir = (efov.transform.position - transform.position).normalized;
                //Debug.Log("ShootOnce");
                if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit, 20f))
                {
                    //Debug.Log(hit.transform.gameObject.layer);
                    //Debug.Log(hit.transform.name);

                    //if (hit.transform.gameObject.layer == layer.value)
                    //This bitmask is not necesary but good to know
                    if ((layer.value & (1 << hit.transform.gameObject.layer)) > 0)
                    {


                        //Debug.DrawRay(transform.position,hit.point, Color.red, 5f);
                        Debug.Log("He atacado");
                        Attack();

                        //TargetBase target = hit.collider.GetComponent<TargetBase>();
                        if (target)
                        {
                            //target.NotifyShot();
                        }
                    }
                    

                }
            }

        }
    }
    void Attack()
    {
        transform.LookAt(target);
        ShootOnce();
        //anim.SetTrigger("Attacks");
        //pCombat.TakeDamage(enemyDamage);
        attackCooldown = attackCooldownReset;
        Debug.Log("Ataque");
    }

    public override void ShootOnce()
    {
        //base.ShootOnce();


        audioPlay.Play();


    
    }


    //public void EnemyTakeDamage(float damage)
    //{
    //    enemyHealth -= damage;
    //    Debug.Log("El enemigo tiene " + enemyHealth);
    //}


    public void MoveToPoints()
    {
        navMeshAgent.isStopped = false;
        //Debug.Log("He empezado el MovetoPoints");
        if (Vector3.Distance(transform.position, points.GetChild(count).transform.position) < threshold)
        {
            count++;
            if (count >= points.childCount)
            {
                count = 0;
            }
            //Debug.Log("Estoy buscando el numero de movetopoints");
        }
        //Debug.Log("He acabado el moveToPoints");
        navMeshAgent.SetDestination(points.GetChild(count).transform.position);
        //Debug.Log("The count is " + count);
    }

    private void OnParticleCollision(GameObject particles)
    {

        //Debug.Log("Particula Tocada");
        if (particles.tag == "Tornado")
        {
            //enemyHealth = enemyHealth - pCombat.tornadoDamage;
            //Debug.Log("Con el tornado tengo " + enemyHealth);
        }
    }
}
