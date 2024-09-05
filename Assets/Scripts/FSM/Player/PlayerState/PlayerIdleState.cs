using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
        parameter.isClickMeleeAttack = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (parameter.isDash)
        {
            manager.TransitionState(StateType.Dash);
        }
        if (parameter.isMove)
        {
            manager.TransitionState(StateType.Move);
        }
        if (parameter.isJump)
        {
            manager.TransitionState(StateType.Jump);
        }
        if (parameter.isClickMeleeAttack)
        {
            manager.TransitionState(StateType.MeleeAttack1);
        }

        // todo ?? 为什么逻辑要写在这里
        parameter.currentSpeed = Mathf.MoveTowards(parameter.currentSpeed, 0f, parameter.deceleration * Time.deltaTime);
    }

    public override void OnFixedUpdate() { 
        base.OnFixedUpdate();
        SetVelocity(parameter.currentSpeed * parameter.facingDirection, parameter.rb.velocity.y);//减速
    }

    public override void OnExit() { 
        base.OnExit(); 
    }
}
