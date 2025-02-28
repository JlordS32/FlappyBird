using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float fallingSpeed = 1f;

    // Component References
    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }

    void Update()
    {
        if (rb.linearVelocityY < 0f)
        {
            rb.linearVelocity += fallingSpeed * Time.deltaTime * Vector2.down;
        }

        // Normalize velocity Y between 0 and 1
        float normalizedVelocityY = Mathf.Clamp(rb.linearVelocityY / 5f, -1f, 1f);

        anim.SetFloat("Direction", normalizedVelocityY);
        Debug.Log(normalizedVelocityY);
    }
}
