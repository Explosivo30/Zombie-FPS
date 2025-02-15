using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("Attack");

    private const float TransitionDuration = 0.1f;

    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine){  }

    public override void Enter()
    {
        FacePlayer(); 

        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
        
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("AttackState");
        if(GetNormalizedTime(stateMachine.Animator, "Attack") >= 1)
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }

}
