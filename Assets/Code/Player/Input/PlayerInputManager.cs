using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{

    // Input Actions
    private PlayerInputActions playerInputActions;

    // Movement
    public Vector2 movementDirection { get; private set; } = Vector2.zero;
    public bool isJumpPressed { get; private set; } = false;
    public bool isSprintPressed { get; private set; } = false;

    // Camera
    public Vector2 cameraLookDirection { get; private set; } = Vector2.zero;

    // Attack
    public bool isAttackLightPressed { get; private set; } = false;

    // Other
    public bool isInteractPressed { get; private set; } = false;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Default.Enable();
        SubscribeToAllActions();
    }

    private void OnDestroy()
    {
        UnsubscribeFromAllActions();
        playerInputActions?.Default.Disable();
        playerInputActions?.Dispose();
    }

    private void Update()
    {
        ProcessMovementDirectionInput();
        ProcessCameraDirectionInput();
    }

    private void SubscribeToAllActions()
    {
        // Jump
        playerInputActions.Default.Jump.started += ProcessPerformedJumpInput;
        playerInputActions.Default.Jump.canceled += ProcessCanceledJumpInput;

        // Sprint (Hold)
        playerInputActions.Default.Sprint.performed += ProcessPerformedSprintInput;
        playerInputActions.Default.Sprint.canceled += ProcessCanceledSprintInput;


        // Attack Light
        playerInputActions.Default.AttackLight.started += ProcessPerformedAttackLightInput;
        playerInputActions.Default.AttackLight.canceled += ProcessCanceledAttackLightInput;

        // Interact
        playerInputActions.Default.Interact.started += ProcessPerformedInteractInput;
        playerInputActions.Default.Interact.canceled += ProcessCanceledInteractInput;
    }

    private void UnsubscribeFromAllActions()
    {
        // Jump
        playerInputActions.Default.Jump.started -= ProcessPerformedJumpInput;
        playerInputActions.Default.Jump.canceled -= ProcessCanceledJumpInput;

        // Sprint
        playerInputActions.Default.Sprint.performed -= ProcessPerformedSprintInput;
        playerInputActions.Default.Sprint.canceled -= ProcessCanceledSprintInput;


        // Attack Light
        playerInputActions.Default.AttackLight.started -= ProcessPerformedAttackLightInput;
        playerInputActions.Default.AttackLight.canceled -= ProcessCanceledAttackLightInput;

        // Interact
        playerInputActions.Default.Interact.started -= ProcessPerformedInteractInput;
        playerInputActions.Default.Interact.canceled -= ProcessCanceledInteractInput;
    }

    // Jump
    private void ProcessPerformedJumpInput(InputAction.CallbackContext context) { StartCoroutine(ProcessPerformedJumpInputCoroutine()); }
    private void ProcessCanceledJumpInput(InputAction.CallbackContext context) { isJumpPressed = false; }

    // Sprint 
    private void ProcessPerformedSprintInput(InputAction.CallbackContext context) { isSprintPressed = true; }
    private void ProcessCanceledSprintInput(InputAction.CallbackContext context) { isSprintPressed = false; }


    // Attack Light
    private void ProcessPerformedAttackLightInput(InputAction.CallbackContext context) { StartCoroutine(ProcessPerformedAttackLightInputtCoroutine()); }
    private void ProcessCanceledAttackLightInput(InputAction.CallbackContext context) { isAttackLightPressed = false; }

    // Interact
    private void ProcessPerformedInteractInput(InputAction.CallbackContext context) { StartCoroutine(ProcessPerformedInteractInputCoroutine()); }
    private void ProcessCanceledInteractInput(InputAction.CallbackContext context) { isInteractPressed = false; }

    // Movement Direction
    private void ProcessMovementDirectionInput()
    {
        movementDirection = playerInputActions.Default.Move.ReadValue<Vector2>();
    }

    // Camera Look
    private void ProcessCameraDirectionInput()
    {
        cameraLookDirection = playerInputActions.Default.Look.ReadValue<Vector2>();
    }

    // Coroutines

    // Jump
    private IEnumerator ProcessPerformedJumpInputCoroutine()
    {
        isJumpPressed = true;
        yield return null;
        // Check if object still exists
        if (this != null)
        {
            isJumpPressed = false;
        }
    }

    // Attack Light
    private IEnumerator ProcessPerformedAttackLightInputtCoroutine()
    {
        isAttackLightPressed = true;
        yield return null;
        if (this != null) isAttackLightPressed = false;
    }

    // Interact
    private IEnumerator ProcessPerformedInteractInputCoroutine()
    {
        isInteractPressed = true;
        yield return null;
        if (this != null) isInteractPressed = false;
    }
}
