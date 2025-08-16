using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void CheckExitState(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.chaseState);
    }

    public override void EnterState(EnemyStateManager enemy)
    {

    }

    public override void ExitState(EnemyStateManager enemy)
    {

    }

    public override void PhysicsUpdateState(EnemyStateManager enemy)
    {

    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }
}
