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
    private float fallSpeed;

    private float xVelocity;

    private bool isFalling;
    private bool atMaxSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isFalling)
            rb.AddForce(Vector3.down * fallSpeed);
        else
            rb.AddForce(Vector3.down * (fallSpeed / 2));
    }
    void Update()
    {
        xVelocity = rb.velocity.x;
        if (rb.velocity.y < 0 && GroundCheck())
            isFalling = true;
        else 
            isFalling = false;

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            atMaxSpeed = true;
        else
            atMaxSpeed = false;
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
        if (!GroundCheck())
        {
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            isFalling = false;
        }
    }
    bool GroundCheck()
    {
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y - 0.51f, transform.position.z), Vector3.down * 0.2f);
        if (Physics.Raycast(ray))
            return true;
        else
            return false;
    }
}
