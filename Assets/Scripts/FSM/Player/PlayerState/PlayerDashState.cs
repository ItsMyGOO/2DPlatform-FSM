using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
        // parameter.isDashing = true;
        parameter.isWaitDash = true;
        manager.OnStartCoroutine(DashExitTime());
        manager.OnStartCoroutine(DashWaitTime());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (parameter.isWallSlide)
        {
            manager.TransitionState(StateType.WallSlide);
        }

    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        SetVelocity(parameter.dashPostion.x * parameter.facingDirection, parameter.dashPostion.y);
    }

    public override void OnExit()
    {
        base.OnExit();
        // parameter.isDashing = false;
    }

    IEnumerator DashExitTime()
    {
        yield return new WaitForSeconds(parameter.dashTime); // 等待
        manager.TransitionState(StateType.Idle);
    }

    IEnumerator DashWaitTime()
    {
        yield return new WaitForSeconds(parameter.dashCD); // 等待
        parameter.isWaitDash = false;
    }
}
