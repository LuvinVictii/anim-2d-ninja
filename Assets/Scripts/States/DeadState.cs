using UnityEngine;

public class DeadState : PlayerState
{
    public DeadState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        animator.Play("Dead");
    }
}