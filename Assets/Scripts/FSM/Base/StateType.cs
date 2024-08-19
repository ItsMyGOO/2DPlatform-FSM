// 定义状态类型枚举
public enum StateType
{
    Idle, //待机
    Move, //移动
    Dash, //冲锋
    MeleeAttack, //近战攻击
    Hit, //受击
    Death,//死亡
    Jump,//跳跃
    Fall, //下落
    Land,//落地
    WallSlide,//墙壁滑行
    WallJump, //蹬墙跳
    WallJumpFall, //蹬墙跳下落状态
    MeleeAttack1,//一段近战攻击状态
    MeleeAttack2,//二段近战攻击状态
    ClimbBegin,//开始攀爬
    Climbing,//攀爬中
    ClimbEnd,//攀爬结束
    CoyoteTime,//土狼时间
}