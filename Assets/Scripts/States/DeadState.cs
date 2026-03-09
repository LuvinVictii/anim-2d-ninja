public class DeadState : PlayerState
{
    public DeadState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        animator.Play("Dead");
    }

    public override void Update()
    {
    }
}