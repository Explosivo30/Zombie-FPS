using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");

    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float CrossFadeDuration = 0.1f;

    private const float AnimatorDampTime = 0.1f;

    float timer = 5f;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine){}



    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
    }    

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        timer -= deltaTime;
        Debug.Log("Estoy en idle");
        /*
        if (timer <= 0)
        {
            //stateMachine.SwitchState(new EnemyJumpAttackState(stateMachine));
            stateMachine.SwitchState(new EnemyDodgeState(stateMachine));
        }
        */
        if (IsInChaseRange())
        {
            Debug.Log("In Range");
            
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            return;
        }

        //FacePlayer();
        

        stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() {  }


    

}
