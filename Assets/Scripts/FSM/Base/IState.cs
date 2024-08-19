//抽象基类，定义了所有状态类的基本结构
public interface IState
{
    void OnEnter();// 进入状态时的方法
    void OnUpdate();// 更新方法
    void OnFixedUpdate();// 固定更新方法
    void OnExit();// 退出状态时的方法
}