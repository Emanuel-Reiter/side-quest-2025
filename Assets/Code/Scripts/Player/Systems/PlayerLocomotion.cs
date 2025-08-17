    using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(CharacterController))]
public class PlayerLocomotion : MonoBehaviour
{
    private PlayerDependencies _dependencies;
    private PlayerLocomotionParams _locomotionParams;
    private PlayerPhysics _physics;

    public Vector3 horizontalVelocity { get; private set; } = Vector3.zero;
    public float verticalVelocity { get; private set; } = 0.0f;

    
    private void Start()
    {
        _dependencies = GetComponent<PlayerDependencies>();
        _locomotionParams = GetComponent<PlayerLocomotionParams>();
        _physics = GetComponent<PlayerPhysics>();
    }

    private void Update()
    {
        CalculateHorizontalMovement();
        CalculateVerticalMovement();
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        Vector3 finalMovement = horizontalVelocity + (Vector3.up * verticalVelocity);
        _dependencies.controller.Move(finalMovement * Time.deltaTime);
    }

    #region Movement calculation
    public void CalculateHorizontalMovement()
    {
        Vector2 inputVector = _dependencies.input.movementDirection;
        Vector3 moveDirection = GetCameraRelativeDirection(inputVector);

        if (inputVector.magnitude > 0.1f)
        {
            Vector3 targetVelocity = moveDirection * _locomotionParams.GetCurrentSpeed();
            HandleAcceleration(targetVelocity, moveDirection);
        }
        else
        {
            Decelerate();
        }
    }

    public void CalculateVerticalMovement()
    {
        // NOTE: add jump check when jump mechanic is implemented
        if (_physics.isGrounded)
        {
            verticalVelocity = _locomotionParams.GroundedGravityAcceleration;
            if (_physics.isGroundSnapingActive) _physics.CalculateSlopeMovement();
        }
        else
        {
            verticalVelocity = verticalVelocity + (_locomotionParams.AerialGravityAcceleration * Time.deltaTime);
        }
    }
    #endregion

    #region Acceleration
    public void HandleAcceleration(Vector3 targetVelocity, Vector3 moveDirection)
    {
        if (ClaculateGreatDifferenceInMovementDirection(moveDirection)) Decelerate();
        else Accelerate(targetVelocity);
    }

    public void Accelerate(Vector3 targetVelocity)
    {
        horizontalVelocity = (Vector3.MoveTowards(horizontalVelocity, targetVelocity, _locomotionParams.AccelerationRate * Time.deltaTime));
    }

    public void Decelerate()
    {
        horizontalVelocity = (Vector3.MoveTowards(horizontalVelocity, Vector3.zero, _locomotionParams.DecelerationRate * Time.deltaTime));
    }
    #endregion


    #region Helper methods
    public bool ClaculateGreatDifferenceInMovementDirection(Vector3 moveDirection)
    {
        if (horizontalVelocity.magnitude < Mathf.Epsilon) return false;

        float dotProduct = Vector3.Dot(horizontalVelocity.normalized, moveDirection.normalized);
        float directionThreshold = Mathf.Cos(_locomotionParams.DirectionChangeThreshold * Mathf.Deg2Rad);
        return dotProduct < directionThreshold;
    }

    public Vector3 GetCameraRelativeDirection(Vector2 input)
    {
        // Calculate the facing vector of the camera
        Vector3 forward = _dependencies.playerCamera.transform.forward;
        Vector3 right = _dependencies.playerCamera.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        return (forward.normalized * input.y + right.normalized * input.x).normalized;
    }
    #endregion
}
