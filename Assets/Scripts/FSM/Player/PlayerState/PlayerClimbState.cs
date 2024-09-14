public class PlayerClimbingState : PlayerState
{
    public PlayerClimbingState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
        parameter.isClimbing = true;
        parameter.rb.gravityScale = 0;
        SetVelocity(0, 0);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        //按下掉落
        if (parameter.inputDirection.y < 0)
        {
            manager.TransitionState(StateType.WallSlide);
        }
        //按上
        if (parameter.inputDirection.y > 0)
        {
            parameter.isClickStopJump = false;//保证执行完整的长跳
            manager.TransitionState(StateType.Jump);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
        parameter.rb.gravityScale = parameter.Gravity;
        parameter.isClimbing = false;
    }
}
