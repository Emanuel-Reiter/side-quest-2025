using UnityEngine;

public abstract class NPCBaseState
{
    public abstract void CheckExitState(NPCStateManager npc);
    public abstract void EnterState(NPCStateManager npc);
    public abstract void UpdateState(NPCStateManager npc);
    public abstract void PhysicsUpdateState(NPCStateManager npc);
    public abstract void ExitState(NPCStateManager npc);
}
