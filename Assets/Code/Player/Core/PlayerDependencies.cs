using UnityEngine;

public class PlayerDependencies : MonoBehaviour
{

    [HideInInspector] public PlayerLocomotionParams locomotionParams;
    private void Start()
    {
        LoadReferences();
    }

    private void LoadReferences()
    {
        locomotionParams = GetComponent<PlayerLocomotionParams>();
    }
}
