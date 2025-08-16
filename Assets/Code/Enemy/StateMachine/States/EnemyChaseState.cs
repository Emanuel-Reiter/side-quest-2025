using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void CheckExitState(EnemyStateManager enemy)
    {
    
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
        enemy._dependencies.agent.SetDestination(enemy._dependencies.player.position);
    }
}
