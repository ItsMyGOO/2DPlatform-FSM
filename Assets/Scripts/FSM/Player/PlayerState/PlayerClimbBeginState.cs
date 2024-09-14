public class PlayerClimbBeginState : PlayerState
{
    public PlayerClimbBeginState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
        parameter.rb.gravityScale = 0;
        SetVelocity(0, 0);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (PlayComplete())
        {
            manager.TransitionState(StateType.Climbing);
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
    }
}
