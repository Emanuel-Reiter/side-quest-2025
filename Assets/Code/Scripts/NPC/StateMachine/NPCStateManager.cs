using UnityEngine;

public class NPCStateManager : MonoBehaviour
{
    [Header("Enemy states")]
    [HideInInspector] public NPCIdleState idleState = new NPCIdleState();
    [HideInInspector] public NPCPatrolState patrolState = new NPCPatrolState();
    [HideInInspector] public NPCChaseState chaseState = new NPCChaseState();
    [HideInInspector] public NPCStaggerState staggerState = new NPCStaggerState();

    [Header("State management")]
    public NPCBaseState currentState { get; private set; }
    public NPCBaseState previousState { get; private set; }

    [Header("Other references")]
    [HideInInspector] public NPCDependencies _dependencies;

    private void Start()
    {
        currentState = idleState;
        previousState = currentState;

        InitalizeReferences();
    }

    private void Update()
    {
        currentState.CheckExitState(this);
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.PhysicsUpdateState(this);
    }

    public void SwitchState(NPCBaseState newState)
    {
        currentState.ExitState(this);
        previousState = currentState;

        currentState = newState;
        currentState.EnterState(this);
    }

    private void InitalizeReferences()
    {
        _dependencies = GetComponent<NPCDependencies>();
    }
}
