using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [Header("Enemy states")]
    [HideInInspector] public EnemyIdleState idleState = new EnemyIdleState();
    [HideInInspector] public EnemyPatrolState patrolState = new EnemyPatrolState();
    [HideInInspector] public EnemyChaseState chaseState = new EnemyChaseState();
    [HideInInspector] public EnemyStaggerState staggerState = new EnemyStaggerState();

    [Header("State management")]
    public EnemyBaseState currentState { get; private set; }
    public EnemyBaseState previousState { get; private set; }

    [Header("Other references")]
    [HideInInspector] public EnemyDependencies _dependencies;

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

    public void SwitchState(EnemyBaseState newState)
    {
        currentState.ExitState(this);
        previousState = currentState;

        currentState = newState;
        currentState.EnterState(this);
    }

    private void InitalizeReferences()
    {
        _dependencies = GetComponent<EnemyDependencies>();
    }
}
