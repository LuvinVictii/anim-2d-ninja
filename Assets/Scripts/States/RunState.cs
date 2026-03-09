public class RunState : PlayerState
{
    public RunState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        animator.Play("Run");
    }

    public override void Update()
    {
        if (controller.MoveInput == 0)
        {
            controller.StateMachine.ChangeState(new IdleState(controller));
            return;
        }

        if (controller.JumpPressed)
        {
            controller.StateMachine.ChangeState(new JumpState(controller));
            return;
        }

        if (controller.AttackPressed)
        {
            controller.StateMachine.ChangeState(new AttackState(controller));
            return;
        }
    }
}