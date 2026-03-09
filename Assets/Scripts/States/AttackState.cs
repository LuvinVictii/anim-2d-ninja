public class AttackState : PlayerState
{
    float attackTimer = 0.4f;

    public AttackState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        animator.Play("Attack");
    }

    public override void Update()
    {
        base.Update();
        attackTimer -= UnityEngine.Time.deltaTime;

        if (attackTimer <= 0)
        {
            controller.StateMachine.ChangeState(new IdleState(controller));
        }
    }
}