using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Ссылка на туториал: https://www.youtube.com/watch?v=2FTDa14nryI&list=PLfhbBaEcybmgidDH3RX_qzFM0mIxWJa21
    // Как по мне, самый лучший и понятный туториал ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    // https://www.youtube.com/watch?v=xAtoU-FnC7o&list=PLDyJYA6aTY1k_-3fFiMVoYY04jCr-QY55
    // https://www.youtube.com/watch?v=2o3D9RlBeJE (полезно для анимаций)
    // https://www.youtube.com/watch?v=KM3Q8RUlBdE
    // https://www.youtube.com/watch?v=CmsnhUatf_s
    // https://www.youtube.com/watch?v=f473C43s8nE

    // Доделать: Чтоб при причедании моделька игрока тоже уменьшалась
    // При Esc прЕкол с курсором

    public bool PlayerCanMove {  get; private set; } = true;
    private bool IsSprinting => canSprint && Input.GetKey(sprintKey);
    private bool ShouldJump => Input.GetKey(jumpKey) && characterController.isGrounded; // Если надо при НАЖАТИИ а не при ЗАЖАТИИ, то на GetKeyDown поменять
    private bool ShouldCrouch => Input.GetKeyDown(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;

    [Header("Fuctional options")]
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canCrouch = true;

    [Header("Controls")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode crouchKey = KeyCode.C;

    [Header("Movement parameters")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintSpeed = 9.0f;
    [SerializeField] private float crouchSpeed = 1.5f;

    [Header("Jumping parameters")]
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float gravity = 30.0f;

    [Header("Crouch parameters")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool IsCrouching;
    private bool duringCrouchAnimation;

    [Header("Look parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCanMove)
        {
            HandleMovementInput();
            HandleMouseLook();

            if (canJump)
                HandleJump();

            if (canCrouch) 
                HandleCrouch();

            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2((IsCrouching ? crouchSpeed : IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), (IsCrouching ? crouchSpeed : IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleJump() 
    {
        if (ShouldJump)
            moveDirection.y = jumpForce;
    }

    private void HandleCrouch()
    {
        if (ShouldCrouch)
            StartCoroutine(CrouchStand());
    }

    private void HandleMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private IEnumerator CrouchStand()
    {
        if (IsCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
            yield break;

        duringCrouchAnimation = true;

        float timeElapsed = 0;
        float targetHeight = IsCrouching ? standingHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = IsCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = characterController.center;

        while (timeElapsed < timeToCrouch) 
        { 
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed / timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        characterController.height  = targetHeight;
        characterController.center = targetCenter;

        IsCrouching = !IsCrouching;

        duringCrouchAnimation = false;
    }
}
