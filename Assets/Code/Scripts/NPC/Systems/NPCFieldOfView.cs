using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPCFieldOfView : MonoBehaviour
{
    private NPCDependencies _dependecies;

    [SerializeField] private float viewRadius = 12.0f;
    [SerializeField] [Range(0, 360)] private float viewAngle = 90.0f;

    public LayerMask entityMask;
    public LayerMask lowHitMask;

    [HideInInspector] public List<Transform> visibleTargetsInRange = new List<Transform>();

    void Start()
    {
        _dependecies = GetComponent<NPCDependencies>();

        StartCoroutine(FindTargetsWithDelay(0.2f));
    }


    private IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargetsInRange.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, entityMask);

        foreach (Collider targetInViewRadius in targetsInViewRadius)
        {
            // Basic implementation needs rework
            bool isPlayer = targetInViewRadius.gameObject.CompareTag("Player");
            if (!isPlayer) continue;

            Transform target = targetInViewRadius.transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            bool isTargetInFOV = Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2.0f;
            if (isTargetInFOV)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                bool isViewObstructed = Physics.Raycast(transform.position, directionToTarget, distanceToTarget, lowHitMask);
                if (!isViewObstructed) visibleTargetsInRange.Add(target);
            }
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal) angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}

