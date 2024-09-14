public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
        parameter.rb.gravityScale = 0;
        SetVelocity(0, 0);//速度清0
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (parameter.isClimb)
        {
            manager.TransitionState(StateType.ClimbBegin);
        }
        if (parameter.check.isTouchGround)
        {
            manager.TransitionState(StateType.Idle);
        }
        if (parameter.isClickJump)
        {
            manager.TransitionState(StateType.WallJump);
        }
        if (!parameter.check.isTouchWall)
        {
            manager.TransitionState(StateType.WallJumpFall);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        //应用滑墙速度     按下加速下滑
        if (parameter.inputDirection.y < 0)
        {
            SetVelocity(0, parameter.wallSlideSpeedUp);// 限制垂直速度以应用墙壁滑行速度
        }
        else
        {
            SetVelocity(0, parameter.wallSlideSpeed);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        parameter.rb.gravityScale = parameter.Gravity;
    }
}
