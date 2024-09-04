using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerFSM
{
    [SerializeField] InputActionAsset actionAsset;
    protected override void Awake()
    {
        base.Awake();

        // 初始化输入控制
        InputActionMap actionMap = actionAsset.FindActionMap("Player");

        InputAction move = actionMap.FindAction("Move");
        move.performed += Move;
        move.canceled += StopMove;

        InputAction jump = actionMap.FindAction("Jump");
        jump.started += Jump;
        jump.canceled += StopJump;

        InputAction meleeAttack = actionMap.FindAction("MeleeAttack");
        meleeAttack.started += MeleeAttack;
        // inputSystem.Player.MeleeAttack.canceled += StopMeleeAttack;

        InputAction dash = actionMap.FindAction("Dash");
        dash.started += Dash;
        dash.canceled += StopDash;

        SwitchActionMap(actionMap); // 切换到游戏操作的输入映射
    }

    void OnDisable()
    {
        // 禁用所有输入
        actionAsset.Disable();
    }

    // 切换操作映射
    public void SwitchActionMap(InputActionMap actionMap)
    {
        actionAsset.Disable(); // 禁用当前的输入映射
        actionMap.Enable(); // 启用新的输入映射
    }

    //移动
    public void Move(InputAction.CallbackContext context)
    {
        parameter.inputDirection = context.ReadValue<Vector2>();
    }

    //停止移动
    public void StopMove(InputAction.CallbackContext context)
    {
        parameter.inputDirection = Vector2.zero;
    }

    // 跳跃
    public void Jump(InputAction.CallbackContext context)
    {
        parameter.isClickJump = true;
        parameter.isClickStopJump = false;
        //预输入计时
        StopCoroutine(PreInputExitTime());
        StartCoroutine(PreInputExitTime());
    }

    IEnumerator PreInputExitTime()
    {
        parameter.HasJumpInputBuffer = true;
        yield return new WaitForSeconds(parameter.waitJumpInputBufferTime); // 等待
        parameter.HasJumpInputBuffer = false;
    }

    //停止移动
    public void StopJump(InputAction.CallbackContext context)
    {
        parameter.isClickStopJump = true;
        parameter.isClickJump = false;
    }

    //近战攻击
    public void MeleeAttack(InputAction.CallbackContext context)
    {
        parameter.isClickMeleeAttack = true;
    }
    private void Dash(InputAction.CallbackContext context)
    {
        parameter.isClickDash = true;
    }

    private void StopDash(InputAction.CallbackContext context)
    {
        parameter.isClickDash = false;
    }
}
