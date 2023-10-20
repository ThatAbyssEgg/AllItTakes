using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public float movementSpeed;
    public float sprintSpeed;

    public Transform camera;

    public float jumpHeight;
    public float gravity;

    private CharacterController characterController;
    private float smoothTurnTime = 0.1f;
    private float smoothTurnVelo;

    private float actualSpeed;
    private Vector2 movement;

    bool isGrounded;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        actualSpeed = movementSpeed;
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.35f, 1);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            actualSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            actualSpeed = movementSpeed;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelo, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * actualSpeed * Time.deltaTime);
        }

        // I swear to god, I was trying to make the playerController work, but it just didn't.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity); 
        }

        if (velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
