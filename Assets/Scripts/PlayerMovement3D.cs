using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;          
    [SerializeField] private float groundDistance = 0.3f;    
    [SerializeField] private LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float move = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(move, 0, 0);
        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (move > 0) transform.rotation = Quaternion.Euler(0, 90, 0); // derecha
        else if (move < 0) transform.rotation = Quaternion.Euler(0, -90, 0); // izquierda

        anim.SetFloat("Speed", Mathf.Abs(move));

    }
}
