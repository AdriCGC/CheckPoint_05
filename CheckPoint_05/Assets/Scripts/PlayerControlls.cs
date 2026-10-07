using Unity.VisualScripting;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{

    [Header("Move Parameters")]

    [SerializeField] private float MoveSpeed;
    private Vector2 Direction;

    [Header("Jump Parameters")]

    [SerializeField] private float JumpForce;
    [SerializeField] private float MaxJumpTime;
    private float JumpActualTime;


    [Header("References")]

    [SerializeField] private Transform SensorGround;
    [SerializeField] private Vector3 SensorSize;
    [SerializeField] private LayerMask GroundLayer;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();

     
    }

    void FixedUpdate()
    {
        OnMove();
        OnJump();
    }

    // Movimentação//

    void Move()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, Input.GetAxisRaw("Vertical"));
        if (Direction.x > 0)
        {
            sr.flipX = false;
        }
        else if (Direction.x < 0)
        {
            sr.flipX = true;
        }
    }
    void OnMove()
    {
        rb.linearVelocity = new Vector2(Direction.x, rb.linearVelocityY);
    }

    //Salto//

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            JumpActualTime = MaxJumpTime;
        }
        else if (Input.GetButton("Jump") && JumpActualTime > 0)
        {
            JumpActualTime -= Time.deltaTime;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            JumpActualTime = 0;
        }
    }

    void OnJump()
    {
        if (JumpActualTime > 0)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    //Referencias//


    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(SensorGround.position, SensorSize, 0, GroundLayer);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(SensorGround.position, SensorSize);
    }

    public int MoveDirection ()
    {
        return (int)Direction.x;
    }
    public int JumpDirection()
    {
        return (int)rb.linearVelocityY;
    }
}
