using UnityEngine;

public abstract class PlayerState
{
    protected PlayerController controller;
    protected Animator animator;

    public PlayerState(PlayerController controller)
    {
        this.controller = controller;
        this.animator = controller.Animator;
    }

    public virtual void Enter() { }

    public virtual void Update()
    {
        if (controller.isDead)
        {
            Debug.Log("Player is dead!");
            controller.StateMachine.ChangeState(new DeadState(controller));
            return;
        }
    }

    public virtual void Exit() { }
}