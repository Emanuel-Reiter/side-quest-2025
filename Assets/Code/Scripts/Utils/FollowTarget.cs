using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _rotationOffset;

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(
            _target.transform.position.x + _positionOffset.x,
            _target.transform.position.y + _positionOffset.y,
            _target.transform.position.z + _positionOffset.z);

        Vector3 eulerAngles = new Vector3(
            _target.transform.eulerAngles.x + _rotationOffset.x,
            _target.transform.eulerAngles.y + _rotationOffset.y,
            _target.transform.eulerAngles.z + _rotationOffset.z);

        this.transform.position = newPosition;
        this.transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
