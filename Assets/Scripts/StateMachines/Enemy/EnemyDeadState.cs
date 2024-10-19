using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine){  }

    public override void Enter()
    {
        stateMachine.Ragdoll.ToggleRagdoll(true);

        stateMachine.Weapon.gameObject.SetActive(false);
        CombatManager.Instance.RemoveEnemy(stateMachine.gameObject);
        GameObject.Destroy(stateMachine.Target);

    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("In DeadState");
    }

    public override void Exit()
    {
        
    }

   
}
