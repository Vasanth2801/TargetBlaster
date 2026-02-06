using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    PlayerController controller;
    [SerializeField] Camera cam;

    [Header("Inputs")]
    Vector2 moveInput;
    Vector2 mousePos;

    void Awake()
    {
        controller = new PlayerController();
        Movement();
    }

    void Movement()
    {
        controller.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controller.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable()
    {
        controller.Player.Enable();
    }

    void OnDisable()
    {
        controller.Player.Disable();
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Move();
        MouseLook();
    }

    void Move()
    {
        Vector2 move = (rb.position + moveInput * speed * Time.deltaTime);
        rb.MovePosition(move);
    }

    void MouseLook()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        rb.rotation = angle;
    }
}