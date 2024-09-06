using System.Collections;
using UnityEngine;

public class PlayerFSM : FSM
{
    public PlayerParameter parameter;  // 状态机参数
    protected override void Awake()
    {
        parameter.rb = GetComponent<Rigidbody2D>();
        parameter.animator = GetComponent<Animator>();
        parameter.sr = GetComponent<SpriteRenderer>();
        parameter.check = GetComponent<PhysicsCheck2D>();

        parameter.Gravity = parameter.rb.gravityScale;

        // 初始化各个状态，并添加到状态字典中
        states.Add(StateType.Idle, new PlayerIdleState(this, "idle"));
        states.Add(StateType.Move, new PlayerMoveState(this, "run"));
        states.Add(StateType.Jump, new PlayerJumpState(this, "jump"));
        states.Add(StateType.Fall, new PlayerFallState(this, "fall"));
        states.Add(StateType.WallSlide, new PlayerWallSlideState(this, "wallSlide"));
        //states.Add(StateType.WallJump, new PlayerWallJumpState(this, "Jump"));
        //states.Add(StateType.WallJumpFall, new PlayerWallJumpFallState(this, "Fall"));
        //states.Add(StateType.MeleeAttack1, new PlayerMeleeAttack1State(this, "MeleeAttack1"));
        //states.Add(StateType.MeleeAttack2, new PlayerMeleeAttack2State(this, "MeleeAttack2"));
        states.Add(StateType.Dash, new PlayerDashState(this, "dash"));
        //states.Add(StateType.ClimbBegin, new PlayerClimbBeginState(this, "ClimbBegin"));
        //states.Add(StateType.Climbing, new PlayerClimbingState(this, "Climbing"));
        states.Add(StateType.CoyoteTime, new PlayerCoyoteTimeState(this, "fall"));

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    // 翻转角色
    public override void FlipTo()
    {
        if (parameter.inputDirection.x < 0)
        {
            parameter.facingDirection = -1;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (parameter.inputDirection.x > 0)
        {
            parameter.facingDirection = 1;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

    }

    public void OnStartCoroutine(IEnumerator name)
    {
        StartCoroutine(name);
    }
}
