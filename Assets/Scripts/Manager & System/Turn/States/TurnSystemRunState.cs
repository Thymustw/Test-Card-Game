using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystemRunState : ITurnSystemState
{
    private TurnSystemFSM Manager;
    private TurnSystemParameter Parameter;
    
    public TurnSystemRunState(TurnSystemFSM manager)
    {
        Manager = manager;
        Parameter = manager.parameter;
    }
    public void OnEnter()
    {
     
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        if(Parameter.playerBar.IsArrivedDist)
        {
            Parameter.currentBar = Parameter.playerBar;
            Manager.TransitionState(TurnSystemStateType.Player);
        }

        // Update all run.
        Parameter.playerBar.Run();
        // foreach(RunBar enemyBar in Parameter.enemyBars)
        // {
        //     enemyBar.Run();
        // }
    }
}
