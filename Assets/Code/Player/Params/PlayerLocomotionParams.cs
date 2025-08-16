using UnityEngine;

public class PlayerLocomotionParams : MonoBehaviour
{
    private PlayerPhysics _physics;

    [Header("Movement Speed")]
    [SerializeField] private float _baseSpeed = 7.0f;
    public float BaseSpeed => _baseSpeed;

    [SerializeField] private float _walkSpeedMultiplier = 1.0f;
    [SerializeField] private float _airSpeedMultiplier = 1.8f;

    [Header("Acceleration")]
    [SerializeField] private float _accelerationRate = 50.0f;
    public float AccelerationRate => _accelerationRate;

    [SerializeField] private float _decelerationRate = 50.0f;
    public float DecelerationRate => _decelerationRate;

    [Header("Gravity")]
    [SerializeField] private float _aerialGravityAcceleration = -50.0f;
    public float AerialGravityAcceleration => _aerialGravityAcceleration;

    [SerializeField] private float _groundedGravityAcceleration = -9.81f;
    public float GroundedGravityAcceleration => _groundedGravityAcceleration;

    [Header("Character Rotation")]

    [SerializeField] private float _directionChangeThreshold = 135.0f;
    public float DirectionChangeThreshold => _directionChangeThreshold;

    private void Start()
    {
        _physics = GetComponent<PlayerPhysics>();
    }

    public float GetCurrentSpeed()
    {
        float currentSpeed = 0.0f;

        if (_physics.isGrounded)
        {
            currentSpeed = _baseSpeed * _walkSpeedMultiplier;
        }
        else
        {
            currentSpeed = _baseSpeed * _airSpeedMultiplier;
        }

        return currentSpeed;
    }
}
