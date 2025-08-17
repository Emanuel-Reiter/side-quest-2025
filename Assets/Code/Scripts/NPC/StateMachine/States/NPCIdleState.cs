using UnityEngine;

public class NPCIdleState : NPCBaseState
{
    public override void CheckExitState(NPCStateManager npc)
    {
        npc.SwitchState(npc.chaseState);
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

    }
}
