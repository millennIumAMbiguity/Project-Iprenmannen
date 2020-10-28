using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Johan B.
[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Header("Character stats")]
    [Range(1f, 100f)]
    public float walkingSpeed = 7.5f;
    [Range(2f, 120f)]
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float lowJumpMultiplier = 2f;
    public float fallMultiplier = 5f;
    public float gravity = 20.0f;
    [Header("Camera")]
    public Transform playerCamera;
    public bool lockMouse = false;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    [Header("QoL Features")]
    [Tooltip("How long after button press a jump will go through.")]
    public float acceptableJumpTime = 1f;
    private bool jump = false;
    [Range(0.1f, 10f)]
    public float leanAngle = 0.5f;

    CharacterController characterController;
    Animator anim;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("MoveSpeed", characterController.velocity.magnitude);
        anim.SetBool("Grounded", characterController.isGrounded);

        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetButton("Sprint");
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jumped());
        }

        if (jump && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Lock cursor
        if (Input.GetButtonDown("Cancel"))
          lockMouse = !lockMouse;

        if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, -Input.GetAxis("Horizontal") * leanAngle);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        }
    }

    private IEnumerator Jumped()
    {
        jump = true;
        yield return new WaitForSeconds(acceptableJumpTime);
        jump = false;
    }
}
