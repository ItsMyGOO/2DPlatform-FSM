public class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
        parameter.currentSpeed = parameter.jumpSpeed;
        SetVelocity(parameter.rb.velocity.x, 0);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (parameter.isClimb)
        {
            manager.TransitionState(StateType.ClimbBegin);
        }
        if (parameter.isDash)
        {
            manager.TransitionState(StateType.Dash);
        }
        if (parameter.check.isTouchGround)
        {
            manager.TransitionState(StateType.Idle);
        }
        if (parameter.isJump)
        {
            manager.TransitionState(StateType.Jump);
        }
        if (parameter.isWallSlide)
        {
            manager.TransitionState(StateType.WallSlide);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        Move();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
