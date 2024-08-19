using UnityEngine;

// 检测脚本
public class PhysicsCheck2D : MonoBehaviour
{
    [Header("地面检测")]
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchGround;

    [Header("墙壁检测")]
    public Transform wallCheckPoint;
    public float wallCheckLength;
    public LayerMask wallLayer;
    public bool isTouchWall;

    [Header("攀爬检测")]
    public Transform climbCheckPoint;
    public float climbCheckLength;
    public bool isCheckClimb;

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        // 检测是否接触地面
        isTouchGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        // 检测是否接触墙壁
        isTouchWall = Physics2D.Raycast(wallCheckPoint.position, transform.right * transform.localScale.x, wallCheckLength, wallLayer);
        // 攀爬检测
        bool isClimbTouchWall = Physics2D.Raycast(climbCheckPoint.position, transform.right * transform.localScale.x, climbCheckLength, wallLayer);
        if (!isClimbTouchWall && isTouchWall)
        {
            isCheckClimb = true;
        }
        else
        {
            isCheckClimb = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // 在 Scene 视图中绘制检测范围
        Gizmos.DrawWireSphere((Vector2)groundCheckPoint.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheckPoint.position, wallCheckPoint.position + Vector3.right * transform.localScale.x * wallCheckLength);
        Gizmos.DrawLine(climbCheckPoint.position, climbCheckPoint.position + Vector3.right * transform.localScale.x * climbCheckLength);
    }
}