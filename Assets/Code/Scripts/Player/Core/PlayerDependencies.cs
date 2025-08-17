using UnityEngine;

public class PlayerDependencies : MonoBehaviour
{
    [HideInInspector] public PlayerLocomotionParams locomotionParams;
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public PlayerInputManager input;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Camera playerCamera;

    private void Awake()
    {
        LoadReferences();
    }

    private void LoadReferences()
    {
        locomotionParams = GetComponent<PlayerLocomotionParams>();
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInputManager>();
        animator = GetComponent<Animator>();
        playerCamera = Camera.main;
    }
}
