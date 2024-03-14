public abstract class BaseState
{
    public Ancient ancient;

    public StateMachine stateMachine;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}
