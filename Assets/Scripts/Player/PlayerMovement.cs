using System.Runtime.CompilerServices;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    private InputActions actions;
    private Rigidbody2D rigidBody2d;
    private Vector2 moveDirection;
    private Animator animator;
    
    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        

        if (moveDirection == Vector2.zero)
        {
            animator.SetBool("Moving", false);
            return;
        }

        animator.SetBool("Moving", true);
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);

    }

    private void Move()
    {
        rigidBody2d.MovePosition(rigidBody2d.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        actions = new InputActions();
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
    }
}
