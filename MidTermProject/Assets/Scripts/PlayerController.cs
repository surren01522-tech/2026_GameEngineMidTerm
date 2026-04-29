using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;

    private bool isInvicible = false;

    private float moveInput;

    float score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
        score = 0f;
    } 

    // Update is called once per frame
    private void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);



        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Respawn"))
            {
                if (isInvicible) return;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (collision.CompareTag("Finish"))
            {
                HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
                collision.GetComponent<LevelObject>().MoveToNextLevel();
            }

            if (collision.CompareTag("Enemy"))
            {
                if (isInvicible) return;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (collision.CompareTag("InvincibleItem"))
            {
            score += 10f;
            isInvicible = true;
            Destroy(collision.gameObject);
            Invoke("Invicible", 3f);
            }

            if(collision.CompareTag("Item"))
            {
            }
    }

    void InvicibleDisable()
    {
        isInvicible = false;
    }
}