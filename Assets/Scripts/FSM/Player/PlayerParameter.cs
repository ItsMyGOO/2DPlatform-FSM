using UnityEngine;

public class PlayerParameter : Parameter
{
    [Header("移动")]
    public float normalSpeed = 6f; // 默认移动速度
    public float jumpSpeed = 4f; // 跳跃时的移动速度
    public float acceration = 40f;//加速过渡值
    public float deceleration = 40f;//减速过渡值
    [HideInInspector] public float Gravity;//重力
    [HideInInspector] public int facingDirection = 1; // 角色面向的方向，1右 -1左
    [HideInInspector] public Vector2 inputDirection; // 输入的移动方向
    [HideInInspector] public float currentSpeed; // 当前移动速度
    //如果不触壁有输入 或者 触墙反方向移动才可以移动
    public bool isMove => (check.isTouchWall && inputDirection.x == -facingDirection) ||
                        (!check.isTouchWall && inputDirection.x != 0);


    [Header("跳跃")]
    public float jumpForce;//跳跃力
    public int jumpNum = 1;//跳跃次数
    [HideInInspector] public int currentJumpNum;//当前跳跃次数
    public bool isClickJump;//是否按下跳跃
    public bool isJump => isClickJump && currentJumpNum < jumpNum;
    public bool isClickStopJump;
    public bool isFall => (rb.velocity.y < 0.1f && !check.isTouchGround) || (isClickStopJump && !check.isTouchGround);

    [Header("墙壁滑行")]
    public float wallSlideSpeed = -1f;//滑行速度
    public float wallSlideSpeedUp = -10f;//加速下滑
    public bool isWallSlide => check.isTouchWall && !check.isTouchGround && facingDirection == inputDirection.x;

    [Header("蹬墙跳")]
    public float wallJumpForce; // 蹬墙跳时施加的力

    [Header("近战攻击")]
    public Vector2 attackMovePostion;//移动补偿
    [HideInInspector] public bool isClickMeleeAttack;//是否点击近战攻击

    [Header("冲锋")]
    public Vector2 dashPostion;//冲锋速度
    public float dashTime = 0.5f; //冲锋时间
    public float dashCD = 1f; //冲锋CD
    public GameObject shadowPrefab; //冲锋残影
    [HideInInspector] public bool isClickDash;
    [HideInInspector] public bool isDashing;//是否正在冲锋
    [HideInInspector] public bool isWaitDash;//是否CD冷却
    public bool isDash => isClickDash && !isDashing && !isWaitDash;

    [Header("攀爬")]
    [HideInInspector] public bool isClimbing;
    public bool isClimb => check.isCheckClimb && inputDirection.y == 0;

    [Header("土狼时间")]
    public float coyoteTime = 0.1f;

    [Header("预输入")]
    public float waitJumpInputBufferTime = 0.2f;//跳跃输入缓冲时间
    public bool HasJumpInputBuffer;//是否存在跳跃缓冲
}
