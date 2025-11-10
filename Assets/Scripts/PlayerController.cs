using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movimiento y salto
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    //detector de piso
    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f; 
    public LayerMask groundLayer; 
    //fisicas
    private Rigidbody2D rb; 
    private float moveInput;
    private bool isGrounded; 
    //vamos a obtener el rb
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //asignamos eje
        moveInput = Input.GetAxis("Horizontal");
        //verificamos piso
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //mecanica salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    //fisica del movimiento
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}
