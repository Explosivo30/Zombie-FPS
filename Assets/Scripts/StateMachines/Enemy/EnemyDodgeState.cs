using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeState : EnemyBaseState
{
    float remainingDodgeTime;

    public EnemyDodgeState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        remainingDodgeTime = stateMachine.DodgeDuration;
    }


    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();

        Vector3 jumpBehind = stateMachine.transform.position - stateMachine.Player.transform.position;

        jumpBehind.Normalize();

        movement +=  jumpBehind * stateMachine.DodgeLength / stateMachine.DodgeDuration;
        //movement += stateMachine.transform.forward * dodgingDirectionInput.y * stateMachine.DodgeLength / stateMachine.DodgeDuration;

        Move(movement, deltaTime);

        FacePlayer();


        remainingDodgeTime -= deltaTime;

        if (remainingDodgeTime <= 0f)
        {
            stateMachine.SwitchState(new EnemyJumpAttackState(stateMachine));
        }

    }


    public override void Exit()
    {
        //stateMachine.SwitchState(new EnemyIdleState(stateMachine));
    }
}
