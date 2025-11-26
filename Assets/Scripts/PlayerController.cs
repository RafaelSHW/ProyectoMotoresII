using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float attackDuration = 1f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private Animator anim;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isAttacking)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                anim.SetTrigger("Salta");
            }

            UpdateAnimations();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        anim.SetBool("Ataque", true);

        StartCoroutine(ResetAttackAfterTime());
    }
    IEnumerator ResetAttackAfterTime()
    {
        yield return new WaitForSeconds(attackDuration);

        if (isAttacking)
        {
            FinalizarAtaque();
        }
    }

    public void FinalizarAtaque()
    {
        if (anim != null)
        {
            anim.SetBool("Ataque", false);
            isAttacking = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetFloat("Camina", Mathf.Abs(moveInput));
    }

    void FixedUpdate()
    {
        if (!isAttacking)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

            if (moveInput > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (moveInput < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}