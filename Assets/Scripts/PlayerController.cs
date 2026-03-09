using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Animator;
    public float runSpeed = 5f;
    public float jumpForce = 5f;
    public float attackDash = 1f;
    public int health = 3;
    public bool isDead = false;
    public GameObject kunaiPrefab;

    [HideInInspector] public float MoveInput { get; private set; }
    [HideInInspector] public bool JumpPressed { get; private set; }
    [HideInInspector] public bool AttackPressed { get; private set; }
    [HideInInspector] public bool ThrowPressed { get; private set; }

    public bool isGrounded = true;
    public bool isRightFacing = true;

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

    void LateUpdate()
    {
        if (MoveInput != 0)
        {
            Move();
        }
        if (JumpPressed && isGrounded)
        {
            Jump();
        }
        if (AttackPressed)
        {
            Attack();
        }
        if (ThrowPressed)
        {
            Throw();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void ReadInput()
    {
        if (isDead) return;
        MoveInput = input.Player.Move.ReadValue<Vector2>().x;
        JumpPressed = input.Player.Jump.WasPressedThisFrame();
        AttackPressed = input.Player.Attack.WasPressedThisFrame();
        ThrowPressed = input.Player.Interact.WasPressedThisFrame();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            Debug.Log("Player has died!");
        }
    }

    void Flip()
    {
        isRightFacing = !isRightFacing;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Move()
    {
        if ((MoveInput > 0 && !isRightFacing) || (MoveInput < 0 && isRightFacing))
        {
            Flip();
        }
        transform.Translate(Vector2.right * MoveInput * Time.deltaTime * runSpeed);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, jumpForce);
    }

    void Attack()
    {
        transform.Translate(Vector2.right * (isRightFacing ? 1 : -1) * attackDash);
    }

    void Throw()
    {
        kunaiPrefab.GetComponent<Kunai>().kunaiInit(isRightFacing, true);
        Instantiate(kunaiPrefab, transform.position + new Vector3(transform.localScale.x * 0.5f, 0, 0), Quaternion.identity);
    }
}