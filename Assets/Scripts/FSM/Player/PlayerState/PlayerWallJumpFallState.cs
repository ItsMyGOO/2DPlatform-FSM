public class PlayerWallJumpFallState : PlayerState
{
    public PlayerWallJumpFallState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (parameter.isDash)
        {
            manager.TransitionState(StateType.Dash);
        }
        if (parameter.check.isTouchGround)
        {
            manager.TransitionState(StateType.Idle);
        }
        if (parameter.isWallSlide)
        {
            manager.TransitionState(StateType.WallSlide);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        //可以翻转
        manager.FlipTo();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
