using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpAttackState : EnemyBaseState
{
    float cooldownToAttack;
    bool isActivated = false;

     private readonly int SwordSlideHash = Animator.StringToHash("GreatSwordSlide");

    private const float TransitionTime = 0.1f;

    public EnemyJumpAttackState(EnemyStateMachine stateMachine, float cooldownToAttack = 0.65f) : base(stateMachine)
    {
        this.cooldownToAttack = cooldownToAttack;
    }

    public override void Enter()
    {
        
    }

    

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        cooldownToAttack -= deltaTime;
        if (cooldownToAttack <= 0f && !isActivated)
        {
            stateMachine.Animator.CrossFadeInFixedTime(SwordSlideHash, TransitionTime);

            FacePlayer();

            stateMachine.ForceReceiver.AddForce((stateMachine.Player.transform.position - stateMachine.transform.position).normalized * 20);

            isActivated = true;
        }

        if (GetNormalizedTime(stateMachine.Animator, "GreatSwordSlide") >= 1f)
        {
            
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
        }

        
    }


    public override void Exit()
    {
        
    }
   
}
