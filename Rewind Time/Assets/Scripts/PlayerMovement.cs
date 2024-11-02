using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    private float sidewaysForce;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float fallGravity;
    [SerializeField]
    private float airGravity;
    [SerializeField] 
    private float groundGravity;


    [SerializeField]
    private Transform GroundCheckPos;

    private bool isFalling;
    private bool atMaxSpeed;
    private bool isGrounded;

    private float yVelocity;

    public Rigidbody2D rb;

    void FixedUpdate()
    {
        if (isGrounded)
            rb.AddForce(Vector3.down * groundGravity);
        else if (isFalling)
            rb.AddForce(Vector3.down * fallGravity);
        else
            rb.AddForce(Vector3.down * airGravity);
    }

    void Update()
    {
        if (rb.velocity.y < 0 && GroundCheck())
        {
            isFalling = false;
            isGrounded = true;
            rb.velocity.Set(rb.velocity.x, 0);
        }
        else
        {
            isFalling = (rb.velocity.y >= 0) ? false : true;
            isGrounded = (GroundCheck()) ? true : false;
        }

        atMaxSpeed = (Mathf.Abs(rb.velocity.x) > maxSpeed) ? true : false;
    }


    public void Move(Direction direction)
    {
        if (atMaxSpeed)
        {
            if (rb.velocity.x < 0)
                if (direction == Direction.right)
                    rb.AddForce(sidewaysForce * Vector2.right, 0);

            if (rb.velocity.x > 0)
                if (direction == Direction.left)
                    rb.AddForce(sidewaysForce * Vector2.left, 0);
            return;
        }

        if (direction == Direction.left)
            rb.AddForce(sidewaysForce * Vector2.left, 0);
        else if (direction == Direction.right)
            rb.AddForce(sidewaysForce * Vector2.right, 0);
    }

    public void TryJump()
    {
        if (GroundCheck())
        {
            rb.velocity.Set(rb.velocity.x, 0);
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            isFalling = false;
            isGrounded = false;
        }
        else
        {
            isGrounded = false;
            
            if (rb.velocity.x < 0)
                isFalling = true;
        }
    }

    bool GroundCheck()
    {
        if (Physics2D.Raycast(new Vector2(GroundCheckPos.position.x, GroundCheckPos.position.y), Vector2.down, 0.2f))
            return true;
        else
            return false;
    }
}
