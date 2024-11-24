using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void FacePlayer()
    {
        if (stateMachine.Player == null) { return; }

        Vector3 enemyDirection = (stateMachine.Player.transform.position - stateMachine.transform.position);

        enemyDirection.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(enemyDirection);

    }


    protected void TurnSlowlyTowardsTarget(Transform target)
    {
        

        Vector3 targetDirection = (target.transform.position - stateMachine.transform.position);

        targetDirection.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // Smoothly interpolate between the current rotation and the target rotation
        stateMachine.transform.rotation = Quaternion.Slerp(
            stateMachine.transform.rotation,
            targetRotation,
            Time.deltaTime * stateMachine.Agent.angularSpeed);
    }

    protected bool IsInChaseRange()
    {
        if (stateMachine.Player.IsDead) { return false; }

        float playerDistanceSqr =  (stateMachine.transform.position - stateMachine.Player.transform.position).sqrMagnitude;

        
        return playerDistanceSqr <= stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;
        
    }


    public bool IsInAttackRange()
    {
        if (stateMachine.Player.IsDead) { return false; }

        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;

    }



}
