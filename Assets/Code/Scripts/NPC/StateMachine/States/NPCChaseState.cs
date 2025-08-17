using UnityEngine;

public class NPCChaseState : NPCBaseState
{
    public override void CheckExitState(NPCStateManager npc)
    {
    
    }

    public override void EnterState(NPCStateManager npc)
    {

    }

    public override void ExitState(NPCStateManager npc)
    {

    }

    public override void PhysicsUpdateState(NPCStateManager npc)
    {

    }

    public override void UpdateState(NPCStateManager npc)
    {
        npc._dependencies.agent.SetDestination(npc._dependencies.player.position);
    }
}
