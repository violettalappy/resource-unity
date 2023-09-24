using UnityEngine;

public class State_Wander : FSMStateV5
{
    [Header("State Settings")]
    public float wanderSpeed = 10.0f;
    public float wanderRadius = 10.0f;
    public float wanderTime = 10.0f;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Play animation at the start
        fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        #region ACTIONS
        //Enemy wander around
        enemyCore.Wander(wanderSpeed, wanderRadius);
        #endregion ACTIONS

        #region CONDITION SWITCH STATE
        //Check condition and transit to next state        
        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInAttackRange))
        {
            //Change to next state
            fsmStateManager.TransitionToState(nextState);
        }

        else if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInLOS))
        {
            //Change to next state
            fsmStateManager.TransitionToState(nextState);
        }

        else if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsWaitTimeExceed, wanderTime))
        {
            //Change to flee from player state
            fsmStateManager.TransitionToState(nextState);
        }
        #endregion CONDITION SWITCH STATE
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }
}
