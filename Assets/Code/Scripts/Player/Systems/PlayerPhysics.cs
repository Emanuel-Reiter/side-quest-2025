using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private PlayerDependencies _dependencies;
    private PlayerLocomotion _locomotion;

    [Header("Params")]
    [SerializeField] private float slopeDetectionsDistance = 0.25f;
    [SerializeField] private float slopeCollisionRadiusOffset = 0.0005f;
    [SerializeField] private LayerMask groundMask;

    private float groundSnapDistance = 0.25f;
    private float slopeForce = 5.0f;

    public bool isGroundSnapingActive { get; private set; } = true;

    public bool isGrounded {  get; private set; }

    private void Start()
    {
        _dependencies = GetComponent<PlayerDependencies>();
        _locomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        GroundCheck();

        if (isGroundSnapingActive) ApplyGroundSnaping();
    }

    public void GroundCheck()
    {
        Vector3 checkPosition = transform.position + Vector3.down * slopeDetectionsDistance;
        Physics.CheckSphere(checkPosition, (_dependencies.controller.radius - slopeCollisionRadiusOffset), groundMask);
    }

    public void CalculateSlopeMovement()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, slopeDetectionsDistance))
        {
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            if (slopeAngle > _dependencies.controller.slopeLimit)
            {
                // Apply downward force along slope normal
                float velocity = _locomotion.verticalVelocity + slopeForce * Mathf.Sin(slopeAngle * Mathf.Deg2Rad);
                _dependencies.controller.Move(Vector3.down * velocity);
            }
        }
    }

    private void ApplyGroundSnaping()
    {
        if (isGrounded) return;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundSnapDistance))
        {
            _dependencies.controller.Move(Vector3.down * hit.distance);
        }
    }
}
