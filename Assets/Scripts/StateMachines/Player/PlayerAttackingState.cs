using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private Attack attack;

    float previusFrameTime;

    bool alreadyAppliedForce = false;

    public PlayerAttackingState(PlayerStateMachine stateMachine, int AttackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[AttackIndex];
    }

    public override void Enter()
    {
        stateMachine.InputReader.DodgeEvent += OnDodge;
        stateMachine.WeaponDamage.SetAttack(attack.Damage, attack.Knockback);
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName,attack.TransitionDuration);
        
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        FaceTarget();

        float normalizedTime = GetNormalizedTime(stateMachine.Animator, "Attack");

        if(normalizedTime >= previusFrameTime && normalizedTime < 1f)
        {
            if(normalizedTime > attack.ForceTime)
            {
                TryApplyForce();
            }

            if (stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
                
            }
        }
        else
        {
            if(stateMachine.Targeter.CurrentTarget != null)
            {
                stateMachine.SwitchState(new PlayerTargetingState(stateMachine)); 
            }
            else
            {
                stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            }
        }
        

        previusFrameTime = normalizedTime;
    }

   
    public override void Exit()
    {
        stateMachine.InputReader.DodgeEvent -= OnDodge;
    }

    private void TryComboAttack(float normalizedTime)
    {
        if(attack.ComboStateIndex == -1){ return; }

        if(normalizedTime < attack.ComboAttackTime) { return; }

        stateMachine.SwitchState
            (
                new PlayerAttackingState(stateMachine, attack.ComboStateIndex)
            );

    }


    private void TryApplyForce()
    {
        if (alreadyAppliedForce) { return; }
        stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.Force);
        
        alreadyAppliedForce = true;
    }



    void OnDodge()
    {

        if (stateMachine.InputReader.MovementValue == Vector2.zero) { return; }

        stateMachine.SwitchState(new PlayerDodgingState(stateMachine, stateMachine.InputReader.MovementValue));

    }
    
}
