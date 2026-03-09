using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;

    public float MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AttackPressed { get; private set; }

    public StateMachine StateMachine;

    PlayerInputActions input;

    void Awake()
    {
        StateMachine = new StateMachine();

        input = new PlayerInputActions();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        StateMachine.Initialize(new IdleState(this));
    }

    void Update()
    {
        ReadInput();
        StateMachine.Update();
    }

    void ReadInput()
    {
        MoveInput = input.Player.Move.ReadValue<Vector2>().x;

        JumpPressed = input.Player.Jump.WasPressedThisFrame();

        AttackPressed = input.Player.Attack.WasPressedThisFrame();
    }
}