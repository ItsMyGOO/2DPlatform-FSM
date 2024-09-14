public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(PlayerFSM manager, string animationName) : base(manager, animationName) { }

    public override void OnEnter()
    {
        base.OnEnter();
        // parameter.isWallJump = true;
        // parameter.isClickJump = false;
        parameter.currentSpeed = parameter.normalSpeed;
        SetVelocity(parameter.wallJumpForce * -parameter.facingDirection, parameter.jumpForce);// 设置跳跃速度  
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (parameter.isDash)
        {
            manager.TransitionState(StateType.Dash);
        }
        if (parameter.isFall)
        {
            manager.TransitionState(StateType.Fall);
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        // 输入方向一定是面朝反方向才可控制方向，禁止单墙跳，且确保不输入可以从墙上弹开
        if (parameter.inputDirection.x == -parameter.facingDirection) Move();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}

