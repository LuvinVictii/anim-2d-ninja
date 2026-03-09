public class JumpState : PlayerState
{
    float jumpTimer = 0.5f;

    public JumpState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        animator.Play("Jump");
    }

    public override void Update()
    {
        jumpTimer -= UnityEngine.Time.deltaTime;

        if (jumpTimer <= 0)
        {
            controller.StateMachine.ChangeState(new IdleState(controller));
        }
    }
}