using UnityEngine;

public class DeadState : PlayerState
{
    public DeadState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        Debug.Log("Player has entered DeadState.");
        animator.Play("Dead");
    }
}