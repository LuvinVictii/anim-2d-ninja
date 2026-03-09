public class IdleState : PlayerState
{
    public IdleState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        animator.Play("Idle");
    }

    public override void Update()
    {
        base.Update();
        if (controller.MoveInput != 0)
        {
            controller.StateMachine.ChangeState(new RunState(controller));
            return;
        }

        if (!controller.isGrounded)
        {
            controller.StateMachine.ChangeState(new JumpState(controller));
            return;
        }

        if (controller.AttackPressed)
        {
            controller.StateMachine.ChangeState(new AttackState(controller));
            return;
        }

        if (controller.ThrowPressed)
        {
            controller.StateMachine.ChangeState(new ThrowState(controller));
            return;
        }
    }
}