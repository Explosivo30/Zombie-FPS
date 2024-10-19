using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatWaitState : EnemyBaseState
{

    float remainingDodgeTime;
    bool moveRight;

    public EnemyCombatWaitState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        moveRight = Random.value > 0.5f;
    }

    public override void Tick(float deltaTime)
    {
        FacePlayer();

        stateMachine.ForceReceiver.AddForce((moveRight ? stateMachine.transform.right : -stateMachine.transform.right) * 5);
    }

    public override void Exit()
    {
        
    }


}
