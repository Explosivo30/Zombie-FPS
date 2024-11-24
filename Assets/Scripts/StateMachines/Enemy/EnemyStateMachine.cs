using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public WeaponDamage Weapon { get; private set; }

    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public Target Target { get; private set; }

    [field: SerializeField] public Ragdoll Ragdoll { get; private set; }

    [field: SerializeField] public float DodgeDuration { get; private set; }

    [field: SerializeField] public float DodgeLength { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }

    [field: SerializeField] public float PlayerChasingRange { get; private set; }

    [field: SerializeField] public float AttackRange { get; private set; }

    [field: SerializeField] public float AttackKnockback { get; private set; }

    [field: SerializeField] public int AttackDamage { get; private set; }

    public Health Player { get; private set; }

    public Races races;

    private void Awake()
    {
        //races = SpawnerManager.Instance.InitEnemy();
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        Agent.updatePosition = true;
        Agent.updateRotation = true;
        

        SwitchState(new EnemyIdleState(this));
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    void HandleTakeDamage()
    {
        SwitchState(new EnemyImpactState(this));
    }

    void HandleDie()
    {
        SwitchState(new EnemyDeadState(this));
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
    }
#endif

}
