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

    public virtual void Update() { }

    public virtual void Exit() { }
}