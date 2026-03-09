public class ThrowState : PlayerState
{
    float throwTimer = 0.3f;

    public ThrowState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        animator.Play("Throw");
    }

    public override void Update()
    {
        throwTimer -= UnityEngine.Time.deltaTime;

        if (throwTimer <= 0)
        {
            controller.StateMachine.ChangeState(new IdleState(controller));
        }
    }
}