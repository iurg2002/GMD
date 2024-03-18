
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private float wallJumpCooldown;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip the player sprite based on the direction they are moving
        if(horizontalInput > 0.01f)  
            transform.localScale = Vector3.one;
        else if(horizontalInput < 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);



        // Wall Jumping logic
        if(wallJumpCooldown < 0.2f)
        {
            if(Input.GetKey(KeyCode.Space) && isGrounded())
            {
                Jump();
            }

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
    }


    private void Jump()
    {
         body.velocity = new Vector2(body.velocity.x, speed);
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

        private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
