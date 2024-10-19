using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgingState : PlayerBaseState
{
    private readonly int DodgeBlendTreeHash = Animator.StringToHash("DodgeBlendTree");

    private readonly int DodgeForwardHash = Animator.StringToHash("DodgeForward");

    private readonly int DodgeRightHash = Animator.StringToHash("DodgeRight");

    float remainingDodgeTime;

    Vector3 dodgingDirectionInput;

    const float CrossFadeDuration = 0.1f;
    bool usingCamera;

    public PlayerDodgingState(PlayerStateMachine stateMachine, Vector3 dodgingDirectionInput, bool camera = false) : base(stateMachine)
    { 
        this.dodgingDirectionInput = dodgingDirectionInput;
        usingCamera = camera;
    }

    public override void Enter()
    {
        remainingDodgeTime = stateMachine.DodgeDuration;

        stateMachine.Animator.SetFloat(DodgeForwardHash, dodgingDirectionInput.y);

        stateMachine.Animator.SetFloat(DodgeRightHash,dodgingDirectionInput.x);

        stateMachine.Animator.CrossFadeInFixedTime(DodgeBlendTreeHash, CrossFadeDuration);

        stateMachine.Health.SetInvulnerable(true);
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();

        movement += (usingCamera ? stateMachine.MainCameraTransform.right : stateMachine.transform.right) * dodgingDirectionInput.x * stateMachine.DodgeLength / stateMachine.DodgeDuration;
        movement += (usingCamera ? stateMachine.MainCameraTransform.forward: stateMachine.transform.forward) * dodgingDirectionInput.y * stateMachine.DodgeLength / stateMachine.DodgeDuration;

        Move(movement, deltaTime);

        FaceTarget();

        remainingDodgeTime -= deltaTime;

        if(remainingDodgeTime <= 0f)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        }
    }

    public override void Exit()
    {
        stateMachine.Health.SetInvulnerable(false);
    }
}
